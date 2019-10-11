using Prism;
using Prism.Ioc;
using Prism.Unity;
using Project.ViewModels;
using Project.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync(new System.Uri("/CustomTabbedPage", System.UriKind.Absolute));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
            containerRegistry.RegisterForNavigation<SearchPage, SearchPageViewModel>();
            containerRegistry.RegisterForNavigation<CustomTabbedPage>();
            containerRegistry.RegisterForNavigation<TrendingPage, TrendingPageViewModel>();
            containerRegistry.RegisterForNavigation<VideoPage, VideoPageViewModel>();
        }

    }
}
