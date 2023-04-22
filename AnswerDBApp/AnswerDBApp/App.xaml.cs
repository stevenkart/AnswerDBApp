using AnswerDBApp.Services;
using AnswerDBApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnswerDBApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //MainPage = new MainPage();

            MainPage = new NavigationPage(new BienvenidaPage());
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
