using System;
using Newtonsoft.Json;

namespace RemotePush
{
    public class UserItem
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "surname")]
        public string Surname { get; set; }
    }

    public class UserItemWrapper : Java.Lang.Object
    {
        public UserItemWrapper(UserItem item)
        {
            UserItem = item;
        }

        public UserItem UserItem { get; private set; }
    }
}