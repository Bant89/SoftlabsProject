using Plugin.Connectivity;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Project.Services;
using Project.ViewModels;
using Project.Views;

namespace Project
{
    public partial class App : PrismApplication
    {
        public static IApiService<IYoutubeApi> myApi = new ApiService<IYoutubeApi>(Config.ApiUrl);
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            //NavigationService.NavigateAsync(new System.Uri(Utils.NavigationConstants.MainPage, System.UriKind.Absolute));
            NavigationService.NavigateAsync(new System.Uri("/NavigationPage/CustomTabbedPage?selectedTab=FavoritesPage", System.UriKind.Absolute));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Registering instances
            containerRegistry.RegisterInstance(myApi);
            containerRegistry.RegisterInstance(CrossConnectivity.Current);

            // Registering types
            containerRegistry.RegisterSingleton<IApiManager, ApiManager>();


            containerRegistry.RegisterForNavigation<CustomTabbedPage>();
            containerRegistry.RegisterForNavigation<FavoritesPage, FavoritesPageViewModel>();
            containerRegistry.RegisterForNavigation<ProfilePage, ProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<SearchPage, SearchPageViewModel>();
            containerRegistry.RegisterForNavigation<TrendingPage, TrendingPageViewModel>();
            containerRegistry.RegisterForNavigation<VideoPage, VideoPageViewModel>();
        }

    }
}
