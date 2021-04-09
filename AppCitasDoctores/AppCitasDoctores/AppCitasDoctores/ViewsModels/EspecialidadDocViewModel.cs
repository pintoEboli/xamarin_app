using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using AppCitasDoctores.ViewsModels.Base;
using AppCitasDoctores.Helpers;
using AppCitasDoctores.Models;

namespace AppCitasDoctores.ViewsModels
{
    class EspecialidadDocViewModel : ViewModelBase
    {
        HelperDoctorAzure helper;



        public EspecialidadDocViewModel()
        {

            //getDoctores();
        }

        public void getDoctores() { 
        helper = new HelperDoctorAzure();
        Task.Run(async () => {
                List<Doctor> lista = await helper.GetDoctores();
                this.Doctores = new ObservableCollection<Doctor>(lista);
            });
        }

        private ObservableCollection<Doctor> _Doctores;

        public ObservableCollection<Doctor> Doctores
        {
            get { return this._Doctores; }
            set
            {
                this._Doctores = value;
                OnPropertyChanged("Doctores");
            }
        }

    }
}
