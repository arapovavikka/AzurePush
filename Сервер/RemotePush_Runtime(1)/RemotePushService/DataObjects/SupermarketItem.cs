using Microsoft.Azure.Mobile.Server;

namespace RemotePushService.DataObjects
{
    public class SupermarketItem : EntityData
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}