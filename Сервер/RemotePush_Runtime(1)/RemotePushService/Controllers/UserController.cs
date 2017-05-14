using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.NotificationHubs;
using System.Collections.Generic;
using Microsoft.Azure.Mobile.Server;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using RemotePushService.DataObjects;
using RemotePushService.Models;
using Microsoft.Azure.Mobile.Server.Config;

namespace RemotePushService.Controllers
{
    public class UserController : TableController<UserItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            RemotePushContext context = new RemotePushContext();
            DomainManager = new EntityDomainManager<UserItem>(context, Request);
        }

        // GET tables/UserItem
        public IQueryable<UserItem> GetAllTodoItems()
        {
            return Query();
        }

        // GET tables/UserItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<UserItem> GetTodoItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/UserItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<UserItem> PatchTodoItem(string id, Delta<UserItem> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/UserItem
        public async Task<IHttpActionResult> PostTodoItem(UserItem item)
        {
            UserItem current = await InsertAsync(item);

            //// Get the settings for the server project.
            HttpConfiguration config = this.Configuration;
            MobileAppSettingsDictionary settings =
                this.Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings();

            //// Get the Notification Hubs credentials for the Mobile App.
            string notificationHubName = settings.NotificationHubName;
            string notificationHubConnection = settings
                .Connections[MobileAppSettingsKeys.NotificationHubConnectionString].ConnectionString;

            //// Create a new Notification Hub client.
            NotificationHubClient hub = NotificationHubClient
            .CreateClientFromConnectionString(notificationHubConnection, notificationHubName);

            //// Sending the message so that all template registrations that contain "messageParam"
            //// will receive the notifications. This includes APNS, GCM, WNS, and MPNS template registrations.
            Dictionary<string, string> templateParams = new Dictionary<string, string>();
            templateParams["messageParam"] = item.Name + " was added to the user list.";

            try
            {
                // Send the push notification and log the results.
                var result = await hub.SendTemplateNotificationAsync(templateParams);

                // Write the success result to the logs.
                config.Services.GetTraceWriter().Info(result.State.ToString());
            }
            catch (System.Exception ex)
            {
                // Write the failure result to the logs.
                config.Services.GetTraceWriter()
                    .Error(ex.Message, null, "Push.SendAsync Error");
            }

            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/UserItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTodoItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}
