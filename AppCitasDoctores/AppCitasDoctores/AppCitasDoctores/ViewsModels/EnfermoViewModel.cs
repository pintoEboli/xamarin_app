using AppCitasDoctores.Helpers;
using AppCitasDoctores.Models;
using AppCitasDoctores.ViewsModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace AppCitasDoctores.ViewsModels
{
    class EnfermoViewModel : ViewModelBase
    {
        HelperEnfermoAzures helper;

        public EnfermoViewModel() {
            
            helper = new HelperEnfermoAzures();
            Task.Run(async () => {
                List<Enfermo> lista = await helper.GetEnfermos();
                this.Enfermo = new ObservableCollection<Enfermo>(lista);
            });
            
        }

        private ObservableCollection<Enfermo> _Enfermo;

        public ObservableCollection<Enfermo> Enfermo
        {
            get { return this._Enfermo; }
            set
            {
                this._Enfermo = value;
                OnPropertyChanged("Enfermo");
            }
        }


        public void getEnfermoByApellido(String ape)
        {
            helper = new HelperEnfermoAzures();
            Task.Run(async () => {
                List<Enfermo> lista = await helper.GetEnfermoByName(ape);
                this.Enfermo = new ObservableCollection<Enfermo>(lista);
            });
        }

    }
}
