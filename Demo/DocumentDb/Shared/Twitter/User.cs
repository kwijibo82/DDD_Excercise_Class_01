﻿using System;
using Newtonsoft.Json;
using Shared.Util;

namespace Shared.Twitter
{
    public class User
    {
        [JsonProperty("id")]
        public long UserId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }

        [JsonProperty("created_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }

        [JsonProperty("friends_count")]
        public int FriendsCount { get; set; }

        [JsonProperty("favourites_count")]
        public int FavouritesCount { get; set; }
    }
}
