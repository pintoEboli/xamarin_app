using AppCitasDoctores.Helpers;
using AppCitasDoctores.Models;
using AppCitasDoctores.ViewsModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCitasDoctores.ViewsModels
{
    class DoctorViewModel : ViewModelBase
    {
        private HelperDoctorAzure helper;
        private Doctor _Doctor;
        public DoctorViewModel()
        {
            this.helper = new HelperDoctorAzure();
        }
        public Doctor Doctor
        {
            get { return this._Doctor; }
            set
            {
                this._Doctor = value;
                OnPropertyChanged("Doctor");
            }
        }


        public async Task<bool> insertarDoc(Doctor doc)
        {
            Boolean resul = false;
            helper = new HelperDoctorAzure();
             await Task.Run(async () => {
                resul =  await helper.InsertarDoctor(doc);
            });

            return resul;
        }

        public Command InsertarDoctor
        {
            get
            {
                return new Command(async () => {
                    await helper.InsertarDoctor(Doctor);
                });
            }
        }





    }
}
