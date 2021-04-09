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
    public partial class TodosDoctoresEspView : ContentPage
    {
       DoctoresViewModel dvm = new DoctoresViewModel();
       CitasViewModel cvm = new CitasViewModel();
       List<String> especialidades;
       public String inscripcion { get; set; }
       Citas citaNew { get; set; } 

        public TodosDoctoresEspView()
        {         
            InitializeComponent();
            citaNew = new Citas();
           
            //Llenamos el Picker
            this.especialidades = new List<string> {"Cardiologia","Cirugia","Digestivo","Ginecologia","Neurologia","Pediatria","Psiquiatria","Urologia","Endocrinologia","Nefrologia" };
            foreach (String esp in especialidades) {
                this.controlpicker.Items.Add(esp);
            }
            this.controlpicker.SelectedIndexChanged += (sender, args) =>
            {
                if (controlpicker.SelectedIndex == -1)
                {
                    this.inputDoc_no.Text = "Debe seleccionar una especialidad";
                }
                else
                {
                    this.inputDoc_no.Text = especialidades[controlpicker.SelectedIndex];
                }
            };

            this.buscarDatos.Clicked += btnCalcular_Clicked;
            this.btninsertcita.Clicked += btnInsertCita_Clicked;
            
        }

            private void btnCalcular_Clicked(object sender, EventArgs e)
        {
            
            if (inputDoc_no.Text == null) {
                inputDoc_no.IsVisible = true;
                inputDoc_no.IsEnabled = true;
                inputDoc_no.Text = "Debe seleccionar una especialidad";
                return;
            }
            else
            {
                inputDoc_no.IsVisible = false;
                inputDoc_no.IsEnabled = false;
                dvm.getDoctorEsp(inputDoc_no.Text);
                lblDoctores.IsVisible = true;
                BindingContext = dvm;
            }
        }

        private async void btnInsertCita_Clicked(object sender, EventArgs e)
        {
            //Terminamos de rellenar el objeto cita
            var valoresFechEntr = dataPicher.Date.ToString("dd/MM/yyyy");
            var valoresHoraEntr = timePicker.Time;
            citaNew.fecha = valoresFechEntr;
            citaNew.hora = valoresHoraEntr.ToString();
            citaNew.inscripcion = int.Parse(this.inscripcion);

            //Insertamos llamando al servicio web
            var insertado = await cvm.insertarCita(citaNew);
            if (insertado)
            {
                DetalleCitaView detalleC = new DetalleCitaView();
                Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(detalleC));
            }
            else {
                lblResult.TextColor = Color.Red;
                lblResult.FontSize = 18;
                lblResult.Text = "Problemas al insertar la cita, vuelva a intentarlo más tarde..!";
            }
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
          
            var elem = (Doctor)e.SelectedItem;
            String name = elem.Apellido;
            int doctor_no = elem.DoctorNo;
            //rellenamos el objeto citas que vamos a insertar
            citaNew.doctor_no = doctor_no;
            
            btninsertcita.IsEnabled = true;
            btninsertcita.IsVisible = true;
        }
    }
}
