using Newtonsoft.Json;

namespace Shared.Twitter
{
    public class UserMention
    {
        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }

        [JsonProperty("indices")]
        public int[] Indices { get; set; }
    }
}
