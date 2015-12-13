using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VKTestApp.DTO
{
    public class GroupDTO
    {
        [JsonProperty("gid")]
        public int Gid { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }
        [JsonProperty("is_closed")]
        public bool IsClosed { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("is_admin")]
        public bool IsAdmin { get; set; }
        [JsonProperty("is_member")]
        public bool IsMember { get; set; }
        [JsonProperty("photo")]
        public string Photo { get; set; }
        [JsonProperty("photo_medium")]
        public string PhotoMedium { get; set; }

        [JsonProperty("photo_big")]
        public string PhotoBig { get; set; }

    }
    
    
}
