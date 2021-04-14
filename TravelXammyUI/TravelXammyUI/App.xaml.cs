using Prism;
using Prism.Ioc;
using System;
using System.Diagnostics;
using TravelXammyUI.ViewModels;
using TravelXammyUI.Views;
using Xamarin.Essentials;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace TravelXammyUI
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            AppActions.OnAppAction += AppActions_OnAppAction;

            await NavigationService.NavigateAsync("NavigationPage/TravelHome");
        }

        private void AppActions_OnAppAction(object sender, AppActionEventArgs e)
        {
            if (Application.Current != this && Application.Current is App app)
            {
                AppActions.OnAppAction -= app.AppActions_OnAppAction;
                return;
            }
            Device.BeginInvokeOnMainThread(() =>
            {
                var page = e.AppAction.Id;
                switch (page)
                {
                    case "Option1":
                        NavigationService.NavigateAsync("NavigationPage/TravelHome");
                        break;
                    case "Option2":
                        NavigationService.NavigateAsync("NavigationPage/MainPage");
                        break;
                }

            });
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<TravelHome, TravelHomeViewModel>();
        }
        async protected override void OnStart()
        {
            try
            {
                await AppActions.SetAsync
                (
                   new AppAction("Option1", "1. Book App"),
                   new AppAction("Option2", "2. Book App")
                );
            }
            catch (FeatureNotSupportedException ex)
            {
                Debug.WriteLine("App Actions not supported");
            }
        }
    }
}
