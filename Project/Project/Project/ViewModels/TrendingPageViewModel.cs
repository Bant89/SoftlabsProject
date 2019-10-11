using Prism.AppModel;
using Project.Models;
using Project.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    class TrendingPageViewModel : BaseViewModel, IPageLifecycleAware
    {
        public List<VideoItem> MusicVideos { get; set; }
        public List<VideoItem> TechVideos { get; set; }
        public List<VideoItem> FilmVideos { get; set; }
        public List<VideoItem> AnimalsVideos { get; set; }
        public List<VideoItem> SportsVideos { get; set; }
        public List<VideoItem> ToDisplayVideos { get; set; }

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
            Random random = new Random();
            var apiResponse = RestService.For<IYoutubeAPI>("https://www.googleapis.com/youtube/v3");
            VideoResponse videos = await apiResponse.GetTrendingVideos(Constants.VideoCategories.Music,Constants.APIKey);
            MusicVideos = new List<VideoItem>(videos.Items);

             videos = await apiResponse.GetTrendingVideos(Constants.VideoCategories.Technology, Constants.APIKey);
            TechVideos = new List<VideoItem>(videos.Items);

             videos = await apiResponse.GetTrendingVideos(Constants.VideoCategories.Film, Constants.APIKey);
            FilmVideos = new List<VideoItem>(videos.Items);

             videos = await apiResponse.GetTrendingVideos(Constants.VideoCategories.Animals, Constants.APIKey);
            AnimalsVideos = new List<VideoItem>(videos.Items);

            videos = await apiResponse.GetTrendingVideos(Constants.VideoCategories.Sports, Constants.APIKey);
            SportsVideos = new List<VideoItem>(videos.Items);


            List<VideoItem> GetToDisplay = new List<VideoItem>();
            GetToDisplay.Add(MusicVideos[random.Next(MusicVideos.Count)]);
            GetToDisplay.Add(TechVideos[random.Next(TechVideos.Count)]);
            GetToDisplay.Add(FilmVideos[random.Next(FilmVideos.Count)]);
            GetToDisplay.Add(AnimalsVideos[random.Next(AnimalsVideos.Count)]);
            GetToDisplay.Add(SportsVideos[random.Next(SportsVideos.Count)]);

            this.ToDisplayVideos = GetToDisplay;

            System.Diagnostics.Debug.Write("Probando");
        }

        public void OnDisappearing()
        {
            System.Diagnostics.Debug.WriteLine("Just to stop throwing exceptions");
        }
        
    }
}
