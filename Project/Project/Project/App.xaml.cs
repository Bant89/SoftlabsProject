using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Project.Services;
using Project.ViewModels;
using Project.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project
{
    public partial class App : PrismApplication
    {
        static IApiService<IYoutubeApi> myApi = new ApiService<IYoutubeApi>(Config.ApiUrl);
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            System.Diagnostics.Debug.WriteLine("INICIALIZANDO CUSTOMTABBED");
            NavigationService.NavigateAsync(new System.Uri("/CustomTabbedPage", System.UriKind.Absolute));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Registering instances
            containerRegistry.RegisterInstance(myApi);
            containerRegistry.RegisterInstance(CrossConnectivity.Current);

            // Registering types
            containerRegistry.RegisterSingleton<IApiManager, ApiManager>();


            containerRegistry.RegisterForNavigation<FavoritesPage, FavoritesPageViewModel>();
            containerRegistry.RegisterForNavigation<ProfilePage, ProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<SearchPage, SearchPageViewModel>();
            containerRegistry.RegisterForNavigation<CustomTabbedPage>();
            containerRegistry.RegisterForNavigation<TrendingPage, TrendingPageViewModel>();
            containerRegistry.RegisterForNavigation<VideoPage, VideoPageViewModel>();
        }

    }
}
