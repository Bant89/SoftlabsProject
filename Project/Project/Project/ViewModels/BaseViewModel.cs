using Acr.UserDialogs;
using Prism.Mvvm;
using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class BaseViewModel : BindableBase
    {

        public IUserDialogs PageDialog = UserDialogs.Instance;
        public IApiManager ApiManager;
        IApiService<IYoutubeApi> youtubeApi = new ApiService<IYoutubeApi>(Config.ApiUrl);

        public bool IsBusy { get; set; }

        private string _PageName;
        public string PageName
        {
            get { return _PageName; }
            set { SetProperty(ref _PageName, value); }
        }

        public async Task RunSafe(Task task, bool ShowLoading = true, string loadingMessage = null)
        {
            try
            {
                if (IsBusy) return;

                IsBusy = true;

                if (ShowLoading) UserDialogs.Instance.ShowLoading(loadingMessage ?? "Loading");

                await task;
            }catch(Exception e)
            {
                IsBusy = false;
                UserDialogs.Instance.HideLoading();
                System.Diagnostics.Debug.WriteLine(e.ToString());
                await App.Current.MainPage.DisplayAlert("Error", "Check your internet connection", "Ok");
            }
            finally
            {
                IsBusy = false;
                if (ShowLoading) UserDialogs.Instance.HideLoading();
            }
        }

    }
}
