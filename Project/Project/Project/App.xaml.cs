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
            NavigationService.NavigateAsync("FavoritesPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<FavoritesPage, FavoritesPageViewModel>();
        }

    }
}
