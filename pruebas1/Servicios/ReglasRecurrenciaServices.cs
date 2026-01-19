using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using pruebas1.Entidades;

namespace pruebas1.Servicios
{
    public class ReglasRecurrenciaServices
    {
        private readonly HttpClient httpClient;

        public ReglasRecurrenciaServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<PlantillaReglaRecurrencia>> GetPlantillaFrecuencia()
        {
            var respuesta = await httpClient.GetFromJsonAsync<List<PlantillaReglaRecurrencia>>($"/ReglasRecurrencia/ObtenerPlantillaFrecuencia");
            if (respuesta != null)
            {
                return respuesta;
            }
            return new List<PlantillaReglaRecurrencia>();
        }
        // Frecuencia
        public async Task<List<FrecuenciaRecurrencia>> GetFrecuencia()
        {
            var f = await httpClient.GetFromJsonAsync<List<FrecuenciaRecurrencia>>("FrecuenciaRecurrencia");
            return f ?? new List<FrecuenciaRecurrencia>();
        }

        public async Task<List<Prioridad>> GetPrioridad()
        {
            var respuesta = await httpClient.GetFromJsonAsync<List<Prioridad>>("prioridad");
            return respuesta ?? new List<Prioridad>();
        }
    }
}
