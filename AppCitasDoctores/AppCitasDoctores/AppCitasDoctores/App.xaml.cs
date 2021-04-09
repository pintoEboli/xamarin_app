using AppCitasDoctores.Views;
using AppCitasDoctores.ViewsModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCitasDoctores
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //NavigationPage main = new NavigationPage(new BuscarPacienteView());
            //MainPage = main;

            //MainPage = new BuscarPacienteView();            
            //MainPage = new Inicio();
            NavigationPage main = new NavigationPage(new Inicio());
            MainPage = main;
            //MainPage = new TodosDoctoresEspView();
            //MainPage = new TodosCitasView();
            //MainPage = new InsertarDoctorView();

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
