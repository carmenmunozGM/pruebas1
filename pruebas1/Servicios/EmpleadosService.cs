using pruebas1.Components.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Servicios
{
    public class EmpleadosService
    {
        private readonly HttpClient _http;

        public EmpleadosService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<EmpleadoDTO>> GetPendientes()
        {
            var respuesta = await _http.GetFromJsonAsync<List<EmpleadoDTO>>(
                "/empleado/pendientes");

            return respuesta ?? new();
        }

        public async Task<List<EmpleadoDTO>> GetFiltrados()
        {
            var respuesta = await _http.GetFromJsonAsync<List<EmpleadoDTO>>(
                "/empleado/filtrados");

            return respuesta ?? new();
        }
    }
}
