using System;
using Realms;

namespace AppApuestasFutbol.Models
{
    public class Apuesta : RealmObject
    {
        public int IdApuesta { get; set; }
        public String Usuario { get; set; }
        public String Resultado { get; set; }
        public String Fecha { get; set; }
    }
}
