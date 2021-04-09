using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCitasDoctores.Models
{
    class Enfermo
    {
        [JsonProperty("INSCRIPCION")]
        public int inscripcion { get; set; }
        [JsonProperty("APELLIDO")]
        public String apellido { get; set; }
        [JsonProperty("DIRECCION")]
        public String direccion { get; set; }
        [JsonProperty("SEXO")]
        public String sexo { get; set; }
        [JsonProperty("NSS")]
        public int nss { get; set; }

    }
}
