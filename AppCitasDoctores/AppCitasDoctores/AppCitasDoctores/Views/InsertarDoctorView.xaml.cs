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
    public partial class InsertarDoctorView : ContentPage
    {
        DoctorViewModel dvm = new DoctorViewModel();
        public InsertarDoctorView()
        {
            InitializeComponent();
            this.btninsertdoc.Clicked += btnInsertarDoc_Clicked;
            //layoutDoctor.BindingContext = dvm;
            
        }
        private async void btnInsertarDoc_Clicked(object sender, EventArgs e) {
            //Boolean resultado = false;
            Doctor d = new Doctor();
            //d.DoctorNo = int.Parse(input_DoctorNo.Text);
            d.Apellido = input_Apellido.Text;
            d.HospitalCod = int.Parse(input_HospitalCod.Text);
            d.Especialidad = input_Especialidad.Text;
            d.Salario = int.Parse(input_Salario.Text);
            var resultado =  await dvm.insertarDoc(d);

            if (resultado)
            {
                lbl_resultado.Text = "Doctor Insertado correctamente";
                lbl_resultado.TextColor = Color.Blue;
            }
            else {
                lbl_resultado.Text = "Problemas al insertar doctor. ";
                lbl_resultado.TextColor = Color.Red;
            }
            //BindingContext = dvm;

        }

    }
}