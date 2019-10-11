using Prism.Commands;
using Prism.Navigation;
using Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Project.ViewModels
{
    public class VideoPageViewModel : BaseViewModel, INavigationAware
    {
       
        INavigationService _navigationService;
        public DelegateCommand BackCommand { get; private set; }
        public string Url { get; set; } 
        public VideoPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            BackCommand = new DelegateCommand(Back);

        }

        private async void Back()
        {
            await _navigationService.GoBackAsync();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("videoId"))
            {
                Url = Constants.BaseUrlVideo + parameters["videoId"];
            }
        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        
    }
}
