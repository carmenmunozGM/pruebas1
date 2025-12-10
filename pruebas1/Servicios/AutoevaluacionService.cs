using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using pruebas1.Components.DTOs;
using System.Net.Http.Json;

namespace pruebas1.Servicios
{
    public class AutoevaluacionService
    {
        private readonly HttpClient _http;
        private readonly string _baseApi;

        public AutoevaluacionService(HttpClient http)
        {
            _http = http;

            // Detectar si estás en LOCAL automáticamente
            var host = http.BaseAddress?.Host?.ToLower() ?? "";

            if (host == "localhost" || host == "127.0.0.1")
            {
                _baseApi = "http://localhost:5231";   // 👈 tu API local
            }
            else
            {
                _baseApi = "https://redgm.site:9096"; // 👈 tu servidor real
            }
        }

        // ------------------------------------------
        // GET - Obtener Autoevaluación del empleado
        // ------------------------------------------
        public async Task<List<AutoevaluacionDTO>> ObtenerAutoevaluacion()
        {
            string url = $"{_baseApi}/vistaAutoevaluacion/vista-autoevaluacion/MiAutoevaluacion";

            var result = await _http.GetFromJsonAsync<List<AutoevaluacionDTO>>(url);

            return result ?? new List<AutoevaluacionDTO>();
        }

        // ------------------------------------------
        // POST - Guardar autoevaluación completa
        // ------------------------------------------
        public async Task<bool> GuardarAutoevaluacion(GuardarAutoevaluacionEmpleadoDTO dto)
        {
            string url = $"{_baseApi}/vistaAutoevaluacion/vista-autoevaluacion/guardar";
            var resp = await _http.PostAsJsonAsync(url, dto);

            if (!resp.IsSuccessStatusCode)
            {
                var error = await resp.Content.ReadAsStringAsync();
                throw new Exception(error);   // 🔥 ERROR REAL DEL SERVIDOR
            }

            return true;
        }

    }
}
