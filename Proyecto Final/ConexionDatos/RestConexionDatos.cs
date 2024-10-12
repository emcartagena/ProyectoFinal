using Proyecto_Final.Modelo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Proyecto_Final.ConexionDatos
{
    public class RestConexionDatos : IRestConexionDatos
    {
        public readonly HttpClient httpClient;
        private readonly string dominio;
        private readonly string url;
        private readonly JsonSerializerOptions opcionesJson;

        public RestConexionDatos()
        { 
            httpClient = new HttpClient();
            dominio = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:7195" : "https://localhost:7195";
            //dominio = "https://localhost:7195" Esto es para Dispositivo fisico
            url = $"{dominio}/api";
            opcionesJson = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }
        public async Task AddPlatoAsync(Plato plato)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("[RED] Sin Acceso a Internet");
                return;
            }
            try 
            { 
                //Serializamos el Objeto
                string platoSer = JsonSerializer.Serialize<Plato>(plato, opcionesJson);
                StringContent contenido = new StringContent(platoSer,Encoding.UTF8,"application/json");
                HttpResponseMessage response = await httpClient.PostAsync($"{url}/plato", contenido);
                if (response.IsSuccessStatusCode)
                    Debug.WriteLine("[RED] Se Registro Correctamente");
                else
                    Debug.WriteLine("[RED] No Se Registro Correctamente");
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERROR] {e.Message}");
            }
        }

        public async Task DeletePlatoAsync(int id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("[RED] Sin Acceso a Internet");
                return;
            }
            try
            {
                
                HttpResponseMessage response = await httpClient.DeleteAsync($"{url}/plato/{id}");
                if (response.IsSuccessStatusCode)
                    Debug.WriteLine("[RED] Se Eliminó Correctamente");
                else
                    Debug.WriteLine("[RED] No Se Eliminó Correctamente");
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERROR] {e.Message}");
            }
        }

        public async Task<List<Plato>> GetPlatosAsync()
        {
            List<Plato> platos = new List<Plato>();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("[RED] Sin Acceso a Internet");
                return platos;
            }
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{url}/plato");
                if (response.IsSuccessStatusCode)
                {
                    //Deserializamos
                    var contenido = await response.Content.ReadAsStringAsync();
                    platos = JsonSerializer.Deserialize<List<Plato>>(contenido, opcionesJson);
                }
                else
                {
                    Debug.WriteLine("[RED] Sin Respuesta Favorable desde el Servidor API");

                }
            }
            catch (Exception e)
            { 
                Debug.WriteLine($"Error: {e.Message}");
            }
            return platos;
        }

        public async Task UpdatePlatoAsync(Plato plato)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("[RED] Sin Acceso a Internet");
                return;
            }
            try
            {
                //Serializamos el Objeto
                string platoSer = JsonSerializer.Serialize<Plato>(plato, opcionesJson);
                StringContent contenido = new StringContent(platoSer, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PutAsync($"{url}/plato/{plato.Id}", contenido);
                if (response.IsSuccessStatusCode)
                    Debug.WriteLine("[RED] Se Modificó Correctamente");
                else
                    Debug.WriteLine("[RED] No Se Modificó Correctamente");
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERROR] {e.Message}");
            }
        }
    }
}
