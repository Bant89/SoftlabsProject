using Prism.AppModel;
using Prism.Commands;
using Prism.Ioc;
using Prism.Navigation;
using Project.Models;
using Project.Services;
using Project.Views;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Project.ViewModels
{
    public class SearchPageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private Search search = new Search();
        private INavigationService _navigationService;

        private VideoSearchItem getID;
        private VideoSearchItem VideoId { get; set; }
        public DelegateCommand SearchCommand { get; set; }
        public ObservableCollection<VideoSearchItem> VideosResults { get; set; }
        public Search Search
        {
            get { return search; }
            set
            {
                search = value;
                OnPropertyChanged();
            }
        }
        public VideoSearchItem VideoGetID
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

        private async void  SelectedID(VideoSearchItem ID)
        {
            string _videoID = ID.Id.VideoId;
            var navigationparams = new NavigationParameters();
            navigationparams.Add("videoId", _videoID);
            await _navigationService.NavigateAsync(new Uri(Constants.Navigation.ToVideoPage, UriKind.Relative), navigationparams);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public List<VideoSearchItem> VideoSearchResults { get; set; }
        public SearchPageViewModel(INavigationService navigationService)
        {       
            PageName = "Search Page";
            _navigationService = navigationService;
            
            SearchCommand = new DelegateCommand(async () => await GetSearchVideos());
        }
        public async Task GetSearchVideos()
        {
            string findVideo = Search.WordsForSearch;
            var apiResponse = RestService.For<IYoutubeAPI>(Constants.BaseApi);
            VideoSearchResponse searchedVideos = await apiResponse.GetSearchVideos(findVideo, Constants.APIKey);
            VideoSearchResults = new List<VideoSearchItem>(searchedVideos.Items);
            VideosResults = new ObservableCollection<VideoSearchItem>(VideoSearchResults);
        }

       
    }
}
