using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCitasDoctores.Models
{
  public  class Doctor
    {
        [JsonProperty("DOCTOR_NO")]       
        public int DoctorNo { get; set; }
        [JsonProperty("HOSPITAL_COD")]
        public int HospitalCod { get; set; }
        [JsonProperty("APELLIDO")]
        public String Apellido { get; set; }
        [JsonProperty("ESPECIALIDAD")]
        public String Especialidad { get; set; }
        [JsonProperty("SALARIO")]
        public int Salario { get; set; }
       

    }
}
