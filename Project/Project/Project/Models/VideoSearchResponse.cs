using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
        public class VideoSearchPageInfo
        {

            [JsonProperty("totalResults")]
            public int TotalResults { get; set; }

            [JsonProperty("resultsPerPage")]
            public int ResultsPerPage { get; set; }
        }

        public class Id
        {

            [JsonProperty("kind")]
            public string Kind { get; set; }

            [JsonProperty("videoId")]
            public string VideoId { get; set; }
        }

        public class VideoSearchDefault
        {

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("width")]
            public int Width { get; set; }

            [JsonProperty("height")]
            public int Height { get; set; }
        }

        public class VideoSearchMedium
        {

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("width")]
            public int Width { get; set; }

            [JsonProperty("height")]
            public int Height { get; set; }
        }

        public class VideoSearchHigh
        {

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("width")]
            public int Width { get; set; }

            [JsonProperty("height")]
            public int Height { get; set; }
        }

        public class VideoSearchThumbnails
        {

            [JsonProperty("default")]
            public VideoSearchDefault Default { get; set; }

            [JsonProperty("medium")]
            public VideoSearchMedium Medium { get; set; }

            [JsonProperty("high")]
            public VideoSearchHigh High { get; set; }
        }

        public class VideoSearchSnippet
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
            public VideoSearchThumbnails Thumbnails { get; set; }

            [JsonProperty("channelTitle")]
            public string ChannelTitle { get; set; }

            [JsonProperty("liveBroadcastContent")]
            public string LiveBroadcastContent { get; set; }
        }

        public class VideoSearchItem
        {

            [JsonProperty("kind")]
            public string Kind { get; set; }

            [JsonProperty("etag")]
            public string Etag { get; set; }

            [JsonProperty("id")]
            public Id Id { get; set; }

            [JsonProperty("snippet")]
            public VideoSearchSnippet Snippet { get; set; }
        }

        public class VideoSearchResponse
        {

            [JsonProperty("kind")]
            public string Kind { get; set; }

            [JsonProperty("etag")]
            public string Etag { get; set; }

            [JsonProperty("nextPageToken")]
            public string NextPageToken { get; set; }

            [JsonProperty("regionCode")]
            public string RegionCode { get; set; }

            [JsonProperty("pageInfo")]
            public PageInfo PageInfo { get; set; }

            [JsonProperty("items")]
            public IList<VideoSearchItem> Items { get; set; }
        }

}
