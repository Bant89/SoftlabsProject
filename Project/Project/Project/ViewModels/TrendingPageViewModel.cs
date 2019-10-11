using Prism.AppModel;
using Prism.Navigation;
using Project.Models;
using Project.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    class TrendingPageViewModel : BaseViewModel, IPageLifecycleAware, INotifyPropertyChanged
    {
        public List<VideoItem> MusicVideos { get; set; }
        public List<VideoItem> TechVideos { get; set; }
        public List<VideoItem> FilmVideos { get; set; }
        public List<VideoItem> AnimalsVideos { get; set; }
        public List<VideoItem> SportsVideos { get; set; }
        public List<VideoItem> ToDisplayVideos { get; set; }
        private INavigationService _navigationService;
        private VideoItem getID;
        public VideoItem VideoGetID
        {
            get => getID;
            set
            {
                getID = value;
                if (getID == null)
                {
                    return;
                }
                SelectedID(getID);
                VideoGetID = null;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void SelectedID(VideoItem ID)
        {
            string _videoID = ID.Id;
            var navigationparams = new NavigationParameters();
            navigationparams.Add("videoId", _videoID);
            await _navigationService.NavigateAsync(new Uri(Constants.Navigation.ToVideoPage, UriKind.Relative), navigationparams);
        }
        public TrendingPageViewModel(INavigationService navigationService)
        {
             PageName = "Trending Page";
            _navigationService = navigationService;
        }

        public async void OnAppearing()
        {
          await GetTrendingVideos();
        }

        public async Task GetTrendingVideos()
        {
            Random random = new Random();
            var apiResponse = RestService.For<IYoutubeAPI>(Constants.BaseApi);
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

            
        }

        public void OnDisappearing()
        {
            
        }
        
    }
}
