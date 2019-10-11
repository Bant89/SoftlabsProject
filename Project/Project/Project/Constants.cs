using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public static class Constants
    {
        public static class Navigation
        {
            public static string ToVideoPage { get; set; } = "/VideoPage";
            public static string ToTabbedPage { get; set; } = "/CustomTabbedPage";
        }

        public static string APIKey { get; set; } = "AIzaSyDb0fEgyMvxmhIJO8kzR6AuOPcQak45ees";
        public static string BaseUrlVideo { get; set; } = "https://www.youtube.com/embed/";
        public static string BaseApi { get; set; } ="https://www.googleapis.com/youtube/v3";
        public static class VideoCategories
        {
            public static string Technology { get; set; } = "28";
            public static string Travel { get; set; } = "19";
            public static string Animals { get; set; } = "15";
            public static string Film { get; set; } = "1";
            public static string Music { get; set; } = "10";
            public static string Sports { get; set; } = "17";
        }
    }
}
