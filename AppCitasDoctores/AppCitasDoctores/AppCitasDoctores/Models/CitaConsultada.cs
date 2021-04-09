using System;
using System.Collections.Generic;
using System.Text;

namespace AppCitasDoctores.Models
{
    class CitaConsultada
    {
        public int citas_cod { get; set; }
        public String hora { get; set; }
        public String fecha { get; set; }
        public int inscripcion { get; set; }
        public String nombrePaciente { get; set; }
        public int doctor_no { get; set; }
        public String nombredoc { get; set; }
        public String especialidad { get; set; }

        public CitaConsultada()
        {
        }
    }
}
