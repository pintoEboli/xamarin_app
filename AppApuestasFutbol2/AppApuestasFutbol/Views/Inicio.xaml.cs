using System;
using System.Collections.Generic;
using AppApuestasFutbol.Repositories;
using Xamarin.Forms;

namespace AppApuestasFutbol.Views
{
    public partial class Inicio : ContentPage
    {
        RepositoryRealm repo;

        public Inicio()
        {
            InitializeComponent();
            this.botoninsertar.Clicked += Botoninsertar_ClickedAsync;
            this.botonmostrarregistros.Clicked += Botonmostrarregistros_ClickedAsync;
        }

        private void Botoninsertar_ClickedAsync(object sender, EventArgs e)
        {
            InsertarApuesta insertview = new InsertarApuesta();
            //await Navigation.PushModalAsync(insertview);
            Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(insertview));
        }

        private void Botonmostrarregistros_ClickedAsync(object sender, EventArgs e)
        {
            Apuestas listaview = new Apuestas();
            //await Navigation.PushModalAsync(listaview);
            Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(listaview));
        }
    }
}
