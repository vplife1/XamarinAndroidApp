
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinAndroidApp.Model;

namespace XamarinAndroidApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Dashboard());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
