using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AppApuestasFutbol.Views
{
    public partial class InsertarApuesta : ContentPage
    {

        public String lblapuesta { get; set; }

        public InsertarApuesta()
        {
            InitializeComponent();
            controlstepperIzq.ValueChanged += OnValueChangedIzq;
            controlstepperDer.ValueChanged += OnValueChangedDer;
            
        }

        private void OnValueChangedIzq(object sender, ValueChangedEventArgs e)
        {
            this.lblvalorIzq.Text = "" + e.NewValue;
            this.txtresultado.Text = (this.lblvalorIzq.Text) + "-" +(this.lblvalorDer.Text);
        }

        private void OnValueChangedDer(object sender, ValueChangedEventArgs e)
        {
            this.lblvalorDer.Text = "" + e.NewValue;
            this.txtresultado.Text = (this.lblvalorIzq.Text) + "-" +(this.lblvalorDer.Text);
        }

        public String getApuestaUser() {
            return (this.lblvalorIzq.Text + " - " + this.lblvalorDer.Text);
        }
    }
}
