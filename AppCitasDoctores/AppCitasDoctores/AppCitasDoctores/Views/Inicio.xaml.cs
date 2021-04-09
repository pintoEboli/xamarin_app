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
    public partial class Inicio : ContentPage
    {
        //TodosDoctoresEspView todosDocEspView = new TodosDoctoresEspView();
        BuscarPacienteView todosPacienteView = new BuscarPacienteView();
        InsertarDoctorView todosDoctorView = new InsertarDoctorView();


        public Inicio()
        {
            InitializeComponent();
            this.btnCitas.Clicked += Botoninsertar_ClickedAsync;
            this.btnDoctores.Clicked += BotonInsertarDoctores_Clicked;
        }


        private void Botoninsertar_ClickedAsync(object sender, EventArgs e)
        {
            //todosDocEspView.inscripcion = "38702";
            //await Navigation.PushModalAsync(todosDocEspView);
            Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(todosPacienteView));
        }

        private void BotonInsertarDoctores_Clicked(object sender, EventArgs e)
        {
            
            Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(todosDoctorView));
        }
    }
}