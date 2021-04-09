using AppCitasDoctores.ViewsModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using AppCitasDoctores.Helpers;
using AppCitasDoctores.Models;

namespace AppCitasDoctores.ViewsModels
{
    class CitasViewModel : ViewModelBase
    {
        HelperCitasAzures helper;

        public CitasViewModel() {
            helper = new HelperCitasAzures();
            Task.Run(async () => {
                List<Citas> lista = await helper.GetCitas();
                this.Citas = new ObservableCollection<Citas>(lista);
            });
        }

        private ObservableCollection<Citas> _Citas;

        public ObservableCollection<Citas> Citas
        {
            get { return this._Citas; }
            set
            {
                this._Citas = value;
                OnPropertyChanged("Citas");
            }
        }

        public async Task<bool> insertarCita(Citas cita)
        {
            Boolean insertado = false;
            helper = new HelperCitasAzures();
            await Task.Run(async () => {
             insertado = await helper.InsertarCitas(cita);
            });

            return insertado;
        }


        public async Task<CitaConsultada> getCitaDetalle(int cita_cod)
        {
            CitaConsultada citaC = new CitaConsultada();
            helper = new HelperCitasAzures();
              await  Task.Run(async () => {
                    //await helper.BuscarCitaDetalle(cita_cod);
                    CitaConsultada citaRecibida = await helper.BuscarCitaDetalle(cita_cod);
                    citaC.citas_cod = citaRecibida.citas_cod;
                    citaC.doctor_no = citaRecibida.doctor_no;
                    citaC.hora = citaRecibida.hora;
                    citaC.fecha = citaRecibida.fecha;
                    citaC.especialidad = citaRecibida.especialidad;
                    citaC.nombredoc = citaRecibida.nombredoc;
                    citaC.nombrePaciente = citaRecibida.nombrePaciente;
                    citaC.inscripcion = citaRecibida.inscripcion;
                });
            return citaC;
        }

        public async Task<Citas> getUltimaCita()
        {
            Citas ultimacita = new Citas();
            helper = new HelperCitasAzures();
            await Task.Run(async () => {
            ultimacita = await helper.BuscarUltimaCita();});
            return ultimacita;
        }

    }
}
