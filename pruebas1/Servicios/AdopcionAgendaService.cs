
using pruebas1.Components.DTOs;
using System.Net.Http.Json;

namespace pruebas1.Servicios
{
    public class AdopcionAgendaService
    {
        private readonly HttpClient _http;

        public AdopcionAgendaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<AdopcionAgendaDTO> ObtenerAdopcionAsync(
            int anio,
            int mesDesde,
            int mesHasta,
            string? area = null,
            string? persona = null)
        {
            var url =
                $"adopcionAgenda?anio={anio}" +
                $"&mesDesde={mesDesde}" +
                $"&mesHasta={mesHasta}";

            if (!string.IsNullOrWhiteSpace(area))
            {
                url += $"&area={Uri.EscapeDataString(area)}";
            }

            if (!string.IsNullOrWhiteSpace(persona))
            {
                url += $"&persona={Uri.EscapeDataString(persona)}";
            }

            var respuesta =
                await _http.GetFromJsonAsync<AdopcionAgendaDTO>(url);

            return respuesta ?? new AdopcionAgendaDTO();
        }
    }
}