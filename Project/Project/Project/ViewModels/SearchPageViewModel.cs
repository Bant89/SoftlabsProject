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
           public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public List<VideoSearchItem> VideoSearchResults { get; set; }
        public SearchPageViewModel()
        {       
            PageName = "Search Page";
            
            SearchCommand = new DelegateCommand(async () => await GetSearchVideos());
        }
        public async Task GetSearchVideos()
        {
            string findVideo = Search.WordsForSearch;
            var apiResponse = RestService.For<IYoutubeAPI>("https://www.googleapis.com/youtube/v3");
            VideoSearchResponse searchedVideos = await apiResponse.GetSearchVideos(findVideo, Constants.APIKey);
            VideoSearchResults = new List<VideoSearchItem>(searchedVideos.Items);
            VideosResults = new ObservableCollection<VideoSearchItem>(VideoSearchResults);
            
        }
    

    }
}
