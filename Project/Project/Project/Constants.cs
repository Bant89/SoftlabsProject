using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public static class Constants
    {
        public static class Navigation
        {
        }

        public static string APIKey { get; set; } = "Enter Api key";
        public static string BaseUrlVideo { get; set; } = "https://www.youtube.com/embed/";
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
