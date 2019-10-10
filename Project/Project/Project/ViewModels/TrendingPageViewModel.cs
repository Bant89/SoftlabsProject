using Prism.AppModel;
using Prism.Ioc;
using Project.Models;
using Project.Services;
using Project.Views;
using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    class TrendingPageViewModel : BaseViewModel, IPageLifecycleAware
    {
        public List<VideoItem> MusicVideos { get; set; }
        public List<VideoItem> TechVideos { get; set; }
        public TrendingPageViewModel()
        {
             PageName = "Trending Page";
        }

        public async void OnAppearing()
        {
          await GetTrendingVideos();
        }

        public async Task GetTrendingVideos()
        {
            var apiResponse = RestService.For<IYoutubeAPI>("https://www.googleapis.com/youtube/v3");
            var videos = await apiResponse.GetTrendingVideos();
            System.Diagnostics.Debug.Write("Probando");
        }

        public void OnDisappearing()
        {
            System.Diagnostics.Debug.WriteLine("Just to stop throwing exceptions");
        }
        
    }
}
