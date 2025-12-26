using pruebas1.Components.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Servicios
{
    public class CalendarioService
    {
        private readonly HttpClient _http;

        public CalendarioService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<DiaNoLaboralDto>> ObtenerDiasNoLaborales(int year, int month)
        {
            var url = $"https://redgm.site:9096/diasNoLaborables/{year}/{month}";
            return await _http.GetFromJsonAsync<List<DiaNoLaboralDto>>(url) ?? new();
        }
    }

}
