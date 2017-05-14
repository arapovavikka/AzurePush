using Microsoft.Azure.Mobile.Server;

namespace RemotePushService.DataObjects
{
    public class UserItem : EntityData
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }
}