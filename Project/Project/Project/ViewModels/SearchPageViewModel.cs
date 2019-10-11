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
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Project.ViewModels
{
    public class SearchPageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public DelegateCommand SearchCommand { get; set; }
        
        public string Search { get; set; } = "When The Party Its over Billie Eilish";
        public List<VideoSearchItem> VideoSearchResults { get; set; }
        public SearchPageViewModel()
        {
            PageName = "Search Page";
         
            SearchCommand = new DelegateCommand(async () => await GetSearchVideos());
          
            
        }
        public async Task GetSearchVideos()
        {
            var apiResponse = RestService.For<IYoutubeAPI>("https://www.googleapis.com/youtube/v3");
            VideoSearchResponse searchedVideos = await apiResponse.GetSearchVideos(Search, Constants.APIKey);
            VideoSearchResults = new List<VideoSearchItem>(searchedVideos.Items);  

        }
        

    }
}
