using AppCitasDoctores.Models;
using AppCitasDoctores.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCitasDoctores.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuscarPacienteView : ContentPage
    {
        EnfermoViewModel evm = new EnfermoViewModel();
        TodosDoctoresEspView todosDocEspView;

        public BuscarPacienteView()
        {
            InitializeComponent();
            todosDocEspView = new TodosDoctoresEspView();
            btnBuscar.Clicked += buscarPaciente_Clicked;
            btnCrearCita.Clicked += crearCita_Clicked;
            BindingContext = evm;

        }

        private void buscarPaciente_Clicked(object sender, EventArgs e)
        {
                evm.getEnfermoByApellido(inputApellido.Text);
                BindingContext = evm;
        }


        private async void crearCita_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(todosDocEspView));

        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var elem = (Enfermo)e.SelectedItem;
            int inscripcion = elem.inscripcion;
            //asignamos el valor 
            todosDocEspView.inscripcion = inscripcion.ToString();

            btnCrearCita.IsEnabled = true;
            btnCrearCita.IsVisible = true;
        }
    }
}