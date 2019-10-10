using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class PageInfo
    {

        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }

        [JsonProperty("resultsPerPage")]
        public int ResultsPerPage { get; set; }
    }

    public class Default
    {

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public class Medium
    {

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public class High
    {

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public class Standard
    {

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public class Maxres
    {

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public class Thumbnails
    {

        [JsonProperty("default")]
        public Default Default { get; set; }

        [JsonProperty("medium")]
        public Medium Medium { get; set; }

        [JsonProperty("high")]
        public High High { get; set; }

        [JsonProperty("standard")]
        public Standard Standard { get; set; }

        [JsonProperty("maxres")]
        public Maxres Maxres { get; set; }
    }

    public class Localized
    {

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class VideoSnippet
    {

        [JsonProperty("publishedAt")]
        public DateTime PublishedAt { get; set; }

        [JsonProperty("channelId")]
        public string ChannelId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("thumbnails")]
        public Thumbnails Thumbnails { get; set; }

        [JsonProperty("channelTitle")]
        public string ChannelTitle { get; set; }

        [JsonProperty("tags")]
        public IList<string> Tags { get; set; }

        [JsonProperty("categoryId")]
        public string CategoryId { get; set; }

        [JsonProperty("liveBroadcastContent")]
        public string LiveBroadcastContent { get; set; }

        [JsonProperty("defaultLanguage")]
        public string DefaultLanguage { get; set; }

        [JsonProperty("localized")]
        public Localized Localized { get; set; }

        [JsonProperty("defaultAudioLanguage")]
        public string DefaultAudioLanguage { get; set; }
    }

    public class ContentDetails
    {

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("dimension")]
        public string Dimension { get; set; }

        [JsonProperty("definition")]
        public string Definition { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("licensedContent")]
        public bool LicensedContent { get; set; }

        [JsonProperty("projection")]
        public string Projection { get; set; }
    }

    public class Statistics
    {

        [JsonProperty("viewCount")]
        public string ViewCount { get; set; }

        [JsonProperty("likeCount")]
        public string LikeCount { get; set; }

        [JsonProperty("dislikeCount")]
        public string DislikeCount { get; set; }

        [JsonProperty("favoriteCount")]
        public string FavoriteCount { get; set; }

        [JsonProperty("commentCount")]
        public string CommentCount { get; set; }
    }

    public class Player
    {

        [JsonProperty("embedHtml")]
        public string EmbedHtml { get; set; }
    }

    public class VideoItem
    {

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("snippet")]
        public VideoSnippet Snippet { get; set; }

        [JsonProperty("contentDetails")]
        public ContentDetails ContentDetails { get; set; }

        [JsonProperty("statistics")]
        public Statistics Statistics { get; set; }

        [JsonProperty("player")]
        public Player Player { get; set; }
    }

    public class VideoResponse
    {

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("nextPageToken")]
        public string NextPageToken { get; set; }

        [JsonProperty("pageInfo")]
        public PageInfo PageInfo { get; set; }

        [JsonProperty("items")]
        public IList<VideoItem> Items { get; set; }
    }
}
