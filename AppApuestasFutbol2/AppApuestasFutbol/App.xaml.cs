using System;
using AppApuestasFutbol.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppApuestasFutbol
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            NavigationPage inicio = new NavigationPage(new Inicio());
            MainPage = inicio;

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
