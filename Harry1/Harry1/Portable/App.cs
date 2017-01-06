using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Portable
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            //InitializeComponent();
            MainPage = new NavigationPage(new listviewxaml());
        }
        protected override void OnStart()
        {
            //MainPage = new NavigationPage(new listviewxaml());
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
