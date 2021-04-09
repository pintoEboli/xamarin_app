using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCitasDoctores.Models
{
    class Cita
    {
        [JsonProperty("CITAS_COD")]
        public int citas_cod { get; set; }
        [JsonProperty("HORA")]
        public String hora { get; set; }
        [JsonProperty("FECHA")]
        public String fecha { get; set; }
        [JsonProperty("INSCRIPCION")]
        public int inscripcion { get; set; }
        [JsonProperty("DOCTOR_NO")]
        public int doctor_no { get; set; }
    }
}
