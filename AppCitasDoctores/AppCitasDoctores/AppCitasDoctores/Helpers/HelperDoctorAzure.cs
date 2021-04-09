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
    class HelperDoctorAzure
    {
        private const string DireccionApi = "https://apirestcitas.azurewebsites.net/";


        private HttpClient CrearCliente()
        {
            HttpClient clientehttp = new HttpClient();
            clientehttp.DefaultRequestHeaders.Accept.Clear();
            clientehttp.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return clientehttp;
        }

        public async Task<List<Doctor>> GetDoctores()
        {

            List<Doctor> listadatos = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/doctores";
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                listadatos = JsonConvert.DeserializeObject<List<Doctor>>(contenido);
            }
            return listadatos;
        }

        public async Task<List<Doctor>> GetEspecialidades(String esp)
        {
            List<Doctor> listadatos = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + $"api/doctores/especialidad/{esp}";
            //String peticion = DireccionApi + "api/doctores/especialidad/Cardiologia";
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                listadatos = JsonConvert.DeserializeObject<List<Doctor>>(contenido);
            }
            return listadatos;
        }

        public async Task<bool> InsertarDoctor(Doctor doc)
        {
            //CONVERTIMOS EL OBJETO EN JSON
            string jsondoctor = JsonConvert.SerializeObject(doc, Formatting.Indented);
            //PASAMOS SUS DATOS A BYTES
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsondoctor);
            //CREAMOS UN CONTENIDO DE BYTES PARA ENVIAR
            //EN LA PETICION
            ByteArrayContent content = new ByteArrayContent(buffer);
            //INDICAMOS EN LA CABECERA EL TIPO DE CONTENIDO A ENVIAR
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //CREAMOS EL CLIENTE
            HttpClient client = CrearCliente();
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/doctores";
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
