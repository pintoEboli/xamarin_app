using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AppCitasDoctores.Models;

namespace AppCitasDoctores.Helpers
{
    class HelperCitasAzures
    {

        private const string DireccionApi = "https://apirestcitas.azurewebsites.net/";
        public static CitaConsultada citaConsultada {get;set;}

        private HttpClient CrearCliente()
        {
            HttpClient clientehttp = new HttpClient();
            clientehttp.DefaultRequestHeaders.Accept.Clear();
            clientehttp.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return clientehttp;
        }

        public async Task<Citas> BuscarCita(int citas_cod)
        {
            Citas cita = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/citas/" + citas_cod;
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                cita = JsonConvert.DeserializeObject<Citas>(contenido);
            }
            return cita;
        }

        public async Task<Citas> BuscarUltimaCita()
        {
            Citas cita = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/citas/ultima";
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                cita = JsonConvert.DeserializeObject<Citas>(contenido);
            }
            return cita;
        }

        public async Task<CitaConsultada> BuscarCitaDetalle(int citas_cod)
        {
            CitaConsultada citaC = new CitaConsultada();
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/citas/detalle/" + citas_cod;
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                CitaConsultada citaD = JsonConvert.DeserializeObject<CitaConsultada>(contenido);
                citaC.citas_cod = citaD.citas_cod;
                citaC.doctor_no = citaD.doctor_no;
                citaC.especialidad = citaD.especialidad;
                citaC.fecha = citaD.fecha;
                citaC.hora = citaD.hora;
                citaC.inscripcion = citaD.inscripcion;
                citaC.nombredoc = citaD.nombredoc;
                citaC.nombrePaciente = citaD.nombrePaciente; 

            }
            return citaC;
        }

        public async Task<List<Citas>> GetCitas()
        {
            List<Citas> listadatos = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/citas";
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                listadatos = JsonConvert.DeserializeObject<List<Citas>>(contenido);
            }
            return listadatos;
        }

        public async Task<bool> InsertarCitas(Citas cita)
        {
            //CONVERTIMOS EL OBJETO EN JSON
            string jsoncita = JsonConvert.SerializeObject(cita, Formatting.Indented);
            //PASAMOS SUS DATOS A BYTES
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsoncita);
            //CREAMOS UN CONTENIDO DE BYTES PARA ENVIAR
            //EN LA PETICION
            ByteArrayContent content = new ByteArrayContent(buffer);
            //INDICAMOS EN LA CABECERA EL TIPO DE CONTENIDO A ENVIAR
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //CREAMOS EL CLIENTE
            HttpClient client = CrearCliente();
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/citas";
            //REALIZAMOS LA LLAMADA AL API POST ENVIANDO EL CONTENIDO
            var respuesta = await client.PostAsync(peticion, content);
            if (respuesta.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
