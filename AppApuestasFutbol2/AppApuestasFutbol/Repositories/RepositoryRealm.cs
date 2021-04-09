using System;
using System.Collections.Generic;
using System.Linq;
using AppApuestasFutbol.Models;
using AppApuestasFutbol.Views;
using Realms;

namespace AppApuestasFutbol.Repositories
{
    public class RepositoryRealm
    {
        
        private Realm conexionrealm;
        Transaction transaction;

        public RepositoryRealm()
        {
            // CREAMOS EL OBJETO QUE NOS PERMITIRA CONECTARNOS
            //CON REALM EN CADA DISPOSITIVO 
            this.conexionrealm = Realm.GetInstance();
            

        }


        //Para recoger la lista de apuestas
        public List<Apuesta> GetApuestas()
        {
            List<Apuesta> lista = this.conexionrealm.All<Apuesta>().ToList();
            return lista;
        }

        // Para insertar una nueva apuesta
        public void InsertarApuesta(Apuesta apuesta)
        {
            DateTime fecha = DateTime.Now;
            apuesta.Fecha = fecha.ToString("yyyy-MM-dd");
            transaction = conexionrealm.BeginWrite();
            var entry = conexionrealm.Add(apuesta);
            transaction.Commit();
        }



    }
}
