using Microsoft.Azure.Mobile.Server;

namespace RemotePushService.DataObjects
{
    public class ProductItem : EntityData
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int SupermarketId { get; set; }
    }
}