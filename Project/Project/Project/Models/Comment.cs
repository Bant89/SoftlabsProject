using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class AuthorChannelId
    {

        [JsonProperty("value")]
        public string value { get; set; }
    }

    public class Snippet
    {

        [JsonProperty("authorDisplayName")]
        public string authorDisplayName { get; set; }

        [JsonProperty("authorProfileImageUrl")]
        public string authorProfileImageUrl { get; set; }

        [JsonProperty("authorChannelUrl")]
        public string authorChannelUrl { get; set; }

        [JsonProperty("authorChannelId")]
        public AuthorChannelId authorChannelId { get; set; }

        [JsonProperty("videoId")]
        public string videoId { get; set; }

        [JsonProperty("textDisplay")]
        public string textDisplay { get; set; }

        [JsonProperty("textOriginal")]
        public string textOriginal { get; set; }

        [JsonProperty("canRate")]
        public bool canRate { get; set; }

        [JsonProperty("viewerRating")]
        public string viewerRating { get; set; }

        [JsonProperty("likeCount")]
        public int likeCount { get; set; }

        [JsonProperty("publishedAt")]
        public DateTime publishedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime updatedAt { get; set; }
    }

    public class TopLevelComment
    {

        [JsonProperty("kind")]
        public string kind { get; set; }

        [JsonProperty("etag")]
        public string etag { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("snippet")]
        public Snippet Snippet { get; set; }
    }

    public class snip
    {

        [JsonProperty("topLevelComment")]
        public TopLevelComment topLevelComment { get; set; }
    }

    public class Item
    {

        [JsonProperty("snippet")]
        public snip snip { get; set; }
    }

    public class Comment
    {

        [JsonProperty("items")]
        public IList<Item> items { get; set; }
    }


}
