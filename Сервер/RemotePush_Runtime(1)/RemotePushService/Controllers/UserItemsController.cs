using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using System.Web.Http.Description;
using RemotePushService.DataObjects;
using RemotePushService.Models;

namespace RemotePushService.Controllers
{
    [MobileAppController]
    public class UserItemsController : ApiController
    {
        private RemotePushContext db = new RemotePushContext();

        // GET: api/UserItems
        [AllowAnonymous]
        [HttpGet, Route("api/UserItems")]
        public IQueryable<UserItem> GetUserItems()
        {
            return db.UserItems;
        }

        // GET: api/UserItems/5
        [ResponseType(typeof(UserItem))]
        public IHttpActionResult GetUserItem(string id)
        {
            UserItem userItem = db.UserItems.Find(id);
            if (userItem == null)
            {
                return NotFound();
            }

            return Ok(userItem);
        }

        // PUT: api/UserItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserItem(string id, UserItem userItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userItem.Id)
            {
                return BadRequest();
            }

            db.Entry(userItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UserItems
        [ResponseType(typeof(UserItem))]
        public IHttpActionResult PostUserItem(UserItem userItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserItems.Add(userItem);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserItemExists(userItem.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userItem.Id }, userItem);
        }

        // DELETE: api/UserItems/5
        [ResponseType(typeof(UserItem))]
        public IHttpActionResult DeleteUserItem(string id)
        {
            UserItem userItem = db.UserItems.Find(id);
            if (userItem == null)
            {
                return NotFound();
            }

            db.UserItems.Remove(userItem);
            db.SaveChanges();

            return Ok(userItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserItemExists(string id)
        {
            return db.UserItems.Count(e => e.Id == id) > 0;
        }
    }
}