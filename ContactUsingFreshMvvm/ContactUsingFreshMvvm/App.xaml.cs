using System;
using ContactUsingFreshMvvm.Implementation;
using ContactUsingFreshMvvm.Interface;
using ContactUsingFreshMvvm.Model;
using ContactUsingFreshMvvm.PageModels;
using FreshMvvm;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace ContactUsingFreshMvvm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetupIOC();
            var page = FreshPageModelResolver.ResolvePageModel<ContactListPageModel>();
            var basicNavContainer = new FreshNavigationContainer(page);
            MainPage = basicNavContainer;
        }

        void SetupIOC()
        {
            FreshIOC.Container.Register<IContactRepository, ContactRepo>();
        }
        protected override void OnStart()
        {
            // Handle when your app starts
         }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}