using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Project
{
    public static class Config
    {

        public static string ApiUrl = "https://www.googleapis.com/youtube/v3";


        public static string ApiHostName
        {
            get
            {
                var apiHostName = Regex.Replace(ApiUrl, @"^(?:http(?:s)?://)?(?:www(?:[0-9]+)?\.)?", string.Empty, RegexOptions.IgnoreCase)
                                   .Replace("/", string.Empty);
                return apiHostName;
            }
        }
    }
}
