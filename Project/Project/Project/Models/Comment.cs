using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class AuthorChannelId
    {

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Snippet
    {

        [JsonProperty("authorDisplayName")]
        public string AuthorName { get; set; }

        [JsonProperty("authorProfileImageUrl")]
        public string AuthorProfileImage { get; set; }

        [JsonProperty("authorChannelUrl")]
        public string AuthorUrl { get; set; }

        [JsonProperty("authorChannelId")]
        public AuthorChannelId AuthorChannelID { get; set; }

        [JsonProperty("videoId")]
        public string VideoID { get; set; }

        [JsonProperty("textDisplay")]
        public string TextDisplay { get; set; }

        [JsonProperty("textOriginal")]
        public string TextOriginal { get; set; }

        [JsonProperty("canRate")]
        public bool CanRate { get; set; }

        [JsonProperty("viewerRating")]
        public string ViewerRating { get; set; }

        [JsonProperty("likeCount")]
        public int LikesAmount { get; set; }

        [JsonProperty("publishedAt")]
        public DateTime PublishedDate { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedDate { get; set; }
    }

    public class TopLevelComment
    {

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("snippet")]
        public Snippet Snippet { get; set; }
    }

    public class Snip
    {

        [JsonProperty("topLevelComment")]
        public TopLevelComment Top { get; set; }
    }

    public class Item
    {

        [JsonProperty("snippet")]
        public Snip Snip { get; set; }
    }

    public class Comment
    {

        [JsonProperty("items")]
        public IList<Item> Items { get; set; }
    }


}