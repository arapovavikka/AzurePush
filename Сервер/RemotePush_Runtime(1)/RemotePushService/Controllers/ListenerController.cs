using System;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using System.Web.Http.Tracing;
using Microsoft.Azure.NotificationHubs;
using Microsoft.Azure.Mobile.Server;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using RemotePushService.DataObjects;
using RemotePushService.Models;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;


namespace RemotePushService.Controllers
{
    [MobileAppController]
    public class ListenerController : ApiController
    {
        // GET api/testpm
        [AllowAnonymous]
        [HttpGet, Route("api/testpm")]
        public UserItem Get()
        {
            using (var connection = new SqlConnection(@"Server = tcp:bargains.database.windows.net,1433; Initial Catalog = bargains; Persist Security Info = False; User ID =lavenderist; Password =tangorn04!; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;"))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"select * from useritems";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new UserItem()
                            {
                                Id = reader.GetString(reader.GetOrdinal("id")),
                                Name = reader.GetString(reader.GetOrdinal("name")),
                                Surname = reader.GetString(reader.GetOrdinal("surname"))
                            };
                        }
                    }
                }
            }
            return new UserItem();
        }


        // POST api/messaging
        [AllowAnonymous]
        [HttpPost, Route("api/messaging")]
        public void Post()
        {
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
            templateParams["messageParam"] = "Got question from client app";

            try
            {
                // Send the push notification and log the results.
                var result = hub.SendTemplateNotificationAsync(templateParams);

                // Write the success result to the logs.
                config.Services.GetTraceWriter().Info(result.ToString());
            }
            catch (System.Exception ex)
            {
                // Write the failure result to the logs.
                config.Services.GetTraceWriter()
                    .Error(ex.Message, null, "Push.SendAsync Error");
            }        }
    }
}
