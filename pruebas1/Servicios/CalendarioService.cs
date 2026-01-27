using pruebas1.Components.DTOs;
using pruebas1.Entidades;
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

        public async Task<List<DiaNoLaboralDto>> ObtenerPorAnio(int year)
        {
            var url = $"https://redgm.site:9096/diasNoLaborables/{year}";
                      //$"http://localhost:5231/diasNoLaborables/2026";
            return await _http.GetFromJsonAsync<List<DiaNoLaboralDto>>(url) ?? new();
        }

        public async Task<DiaNoLaboralDto?> Crear(DiaNoLaboral dia)
        {
            var url = "https://redgm.site:9096/diasNoLaborables/crear";
                      //"http://localhost:5231/diasNoLaborables/crear";

            var response = await _http.PostAsJsonAsync(url, dia
            );

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<DiaNoLaboralDto>()
                   ?? throw new Exception("Respuesta vacía del servidor");
        }

        public async Task Eliminar(int id)
        {
            var url = $"https://redgm.site:9096/diasNoLaborables/Borrar/{id}";
                      //$"http://localhost:5231/diasNoLaborables/Borrar/{id}";

            var response = await _http.DeleteAsync(url);

            response.EnsureSuccessStatusCode();
        }
    }

}
