using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AppApuestasFutbol.Models;
using AppApuestasFutbol.Repositories;
using AppApuestasFutbol.ViewModels.Base;
using AppApuestasFutbol.Views;
using Xamarin.Forms;

namespace AppApuestasFutbol.ViewModels
{
    public class ApuestaModel : ViewModelBase
    {
        RepositoryRealm repo;
        //public String ApuestaUser { get; set; }

        public ApuestaModel() {
            this.repo = new RepositoryRealm();
            this.Apuesta = new Apuesta();
            List<Apuesta> lista = this.repo.GetApuestas();
            this.Apuestas = new ObservableCollection<Apuesta>(lista);

            //InsertarApuesta objInsert = new InsertarApuesta();
            //this.ApuestaUser = objInsert.getApuestaUser();

        }

        //PROPIEDAD DEL OBJETO APUESTA QUE MOSTRAREMOS
        private Apuesta _Apuesta;
        public Apuesta Apuesta
        {
            get { return this._Apuesta; }
            set
            {
                this._Apuesta = value;
                OnPropertyChanged("Departamento");
            }
        }

        //PROPIEDAD PARA MOSTRAR LOS RESULTADOS DE LAS ACCIONES 
        private String _Mensaje;
        public String Mensaje
        {
            get { return this._Mensaje; }
            set
            {
                this._Mensaje = value;
                OnPropertyChanged("Mensaje");
            }
        }

        //Funcion para insertar en Realms
        public Command InsertarDatoApuesta
        {
            get
            {
                return new Command(() => {
                    
                    //this.Apuesta.Fecha = "18-03-2021"; 
                    this.repo.InsertarApuesta(this.Apuesta);
                    this.Mensaje = "Dato insertado";
                });
            }
        }

        private ObservableCollection<Apuesta> _Apuestas;
        public ObservableCollection<Apuesta> Apuestas
        {
            get { return this._Apuestas; }
            set
            {
                this._Apuestas = value;
                OnPropertyChanged("Apuestas");
            }
        }


    }
}
