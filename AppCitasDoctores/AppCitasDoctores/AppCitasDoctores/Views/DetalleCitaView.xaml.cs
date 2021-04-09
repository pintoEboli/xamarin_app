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
    public partial class DetalleCitaView : ContentPage
    {
        CitasViewModel cvm = new CitasViewModel();
        CitaConsultada citaDetalle { get; set; }
        public int cita_cod { get; set; }
        

        public DetalleCitaView()
        {
            InitializeComponent();
            getDetalle(cita_cod);  
            
            
        }

        /****************************************************************************************
         *  Hay que hacer el metodo asyncrono para que de tiempo de lleguen los datos para poder cargarlos, 
         *  si no los muestra vacios 
         *
         **********************************************************************************************/
        private async void getDetalle(int cita_cod) {
           
            var ultCita = await cvm.getUltimaCita();
            int cita_cod_ult = ultCita.citas_cod;

            var citaDetalle = await cvm.getCitaDetalle(cita_cod_ult);
            // Enviamos los datos al Formulario
            lblCitaCod.Text = citaDetalle.citas_cod.ToString();
            lblCitaEspecialidad.Text = citaDetalle.especialidad;
            lblCitaFecha.Text = citaDetalle.fecha;
            lblCitaHora.Text = citaDetalle.hora;
            lblCitaPaciente.Text = citaDetalle.nombrePaciente;
            lblCitaDoctor.Text = citaDetalle.nombredoc;
        } 



    }
}