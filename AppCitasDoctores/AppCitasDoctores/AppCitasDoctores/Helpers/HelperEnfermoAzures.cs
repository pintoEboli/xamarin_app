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
    class HelperEnfermoAzures
    {
        private const string DireccionApi = "https://apirestcitas.azurewebsites.net/";


        private HttpClient CrearCliente()
        {
            HttpClient clientehttp = new HttpClient();
            clientehttp.DefaultRequestHeaders.Accept.Clear();
            clientehttp.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return clientehttp;
        }


        public async Task<List<Enfermo>> GetEnfermos()
        {
            List<Enfermo> listadatos = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + "api/enfermos";
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                listadatos = JsonConvert.DeserializeObject<List<Enfermo>>(contenido);
            }
            return listadatos;
        }


        public async Task<List<Enfermo>> GetEnfermo(int inscripcion)
        {
            List<Enfermo> listadatos = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + $"api/enfermo/{inscripcion}";
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                listadatos = JsonConvert.DeserializeObject<List<Enfermo>>(contenido);
            }
            return listadatos;
        }

        public async Task<List<Enfermo>> GetEnfermoByName(String apellido)
        {
            List<Enfermo> listadatos = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + $"api/enfermos/lastname/{apellido}";
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                listadatos = JsonConvert.DeserializeObject<List<Enfermo>>(contenido);
            }
            return listadatos;
        }

    }
}
