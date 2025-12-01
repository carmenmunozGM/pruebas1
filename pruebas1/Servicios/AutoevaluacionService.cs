using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Servicios
{
    using pruebas1.Components.DTOs;
    using System.Net.Http.Json;

    public class AutoevaluacionService
    {
        private readonly HttpClient _http;

        public AutoevaluacionService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<AutoevaluacionDTO>> ObtenerAutoevaluacion()
        {
            // ← tu URL real
            string url = "https://redgm.site:9096/vistaAutoevaluacion/vista-autoevaluacion/MiAutoevaluacion";

            var result = await _http.GetFromJsonAsync<List<AutoevaluacionDTO>>(url);

            return result ?? new List<AutoevaluacionDTO>();
        }
    }

}
