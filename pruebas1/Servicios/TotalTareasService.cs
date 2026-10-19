
using APIProyectoSPEC.DTOs;
using pruebas1.Components.DTOs;
using System.Globalization;
using System.Net.Http.Json;

namespace pruebas1.Servicios
{
    public class TotalTareasService
    {
        private readonly HttpClient _http;

        public TotalTareasService(HttpClient http)
        {
            _http = http;
        }

        private static string QueryFechas(DateTime desde, DateTime hasta)
        {
            return $"?desde={desde.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}" +
                   $"&hasta={hasta.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}";
        }

        public async Task<TotalTareasDTO> ObtenerTotalTareasAsync(
        DateTime? desde = null, DateTime? hasta = null)
        {
            var url = "totalTareas";
            var queryParams = new List<string>();

            if (desde.HasValue)
                queryParams.Add($"desde={desde.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}");

            if (hasta.HasValue)
                queryParams.Add($"hasta={hasta.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}");

            if (queryParams.Any())
                url += "?" + string.Join("&", queryParams);

            return await _http.GetFromJsonAsync<TotalTareasDTO>(url)
                   ?? new TotalTareasDTO();
        }

        public async Task<TareasPendientesDTO> ObtenerTotalPendientesAsync(
            DateTime? desde = null, DateTime? hasta = null)
        {
            var url = "tareasEstado/pendientes";

            if (desde.HasValue && hasta.HasValue)
                url += QueryFechas(desde.Value, hasta.Value);

            return await _http.GetFromJsonAsync<TareasPendientesDTO>(url)
                   ?? new TareasPendientesDTO();
        }

        public async Task<TareasCompletadasDTO> ObtenerTotalCompletadasAsync(
            DateTime? desde = null, DateTime? hasta = null)
        {
            var url = "tareasEstado/completadas";

            if (desde.HasValue && hasta.HasValue)
                url += QueryFechas(desde.Value, hasta.Value);

            return await _http.GetFromJsonAsync<TareasCompletadasDTO>(url)
                   ?? new TareasCompletadasDTO();
        }

        public async Task<TareasVencidasDTO> ObtenerTotalVencidasAsync(
            DateTime? desde = null, DateTime? hasta = null)
        {
            var url = "tareasEstado/vencidas";

            if (desde.HasValue && hasta.HasValue)
                url += QueryFechas(desde.Value, hasta.Value);

            return await _http.GetFromJsonAsync<TareasVencidasDTO>(url)
                   ?? new TareasVencidasDTO();
        }

        public async Task<List<EmpleadoDetalleDTO>> ObtenerDetalleEmpleadosAsync(
            DateTime? desde = null, DateTime? hasta = null)
        {
            var url = "tareas/detalle-empleados";

            if (desde.HasValue && hasta.HasValue)
                url += QueryFechas(desde.Value, hasta.Value);

            return await _http.GetFromJsonAsync<List<EmpleadoDetalleDTO>>(url)
                   ?? new List<EmpleadoDetalleDTO>();
        }
    }
}
