
using pruebas1.Components.DTOs;
using System.Net.Http.Json;
using System.Globalization;

namespace pruebas1.Servicios
{
    public class TareasDuracionService
    {
        private readonly HttpClient _http;

        public TareasDuracionService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<TareaDuracionDTO>> ObtenerDuracionTareas()
        {
            try
            {
                var respuesta =
                    await _http.GetFromJsonAsync<List<TareaDuracionDTO>>(
                        "/tareasRecorridas");

                return respuesta ?? new List<TareaDuracionDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener tareas: {ex.Message}");
                return Enumerable.Empty<TareaDuracionDTO>();
            }
        }

        public async Task<List<TareaDuracionDTO>> ObtenerDuracionTareasAsync(
            DateTime desde,
            DateTime hasta)
        {
            var tareas = await ObtenerDuracionTareas();

            return tareas
                .Where(t => t.FechaInicio.HasValue)
                .Where(t =>
                    t.FechaInicio!.Value >= desde &&
                    t.FechaInicio.Value < hasta)
                .ToList();
        }

        public async Task<int> ObtenerSumaDiasRecorridos()
        {
            try
            {
                return await _http.GetFromJsonAsync<int>(
                    "/tareasRecorridas/suma");
            }
            catch
            {
                return 0;
            }
        }

        public async Task<IEnumerable<EmpleadoDetalleDTO>>
            ObtenerDetalleIndividualEmpleados()
        {
            try
            {
                var respuesta =
                    await _http.GetFromJsonAsync<
                        IEnumerable<EmpleadoDetalleDTO>>(
                            "/tareasRecorridas/detalle-empleados");

                return respuesta ?? Enumerable.Empty<EmpleadoDetalleDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error al obtener detalle de empleados: {ex.Message}");

                return Enumerable.Empty<EmpleadoDetalleDTO>();
            }
        }
    }
}
