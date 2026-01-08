using System.Net.Http.Json;
using pruebas1.Components.DTOs;

namespace pruebas1.Servicios
{
    public class ServicioClienteService
    {
        private readonly HttpClient _http;

        public ServicioClienteService(HttpClient http)
        {
            _http = http;
        }

        public async Task<EmpresasAsignadasDTO> ObtenerMisEmpresas()
        {
            return await _http.GetFromJsonAsync<EmpresasAsignadasDTO>(
                "entidadAgenda/empresasAsignadas"
            ) ?? new EmpresasAsignadasDTO();
        }

        public async Task<ActividadesEmpresaDTO?> ObtenerActividadesEmpresa(int idUsuarioEntidadAgenda)
        {
            return await _http.GetFromJsonAsync<ActividadesEmpresaDTO>(
                $"entidadAgenda/actividades/{idUsuarioEntidadAgenda}"
            );
        }

        public async Task GuardarFechaYMinutaAsync(HorasProgramaTrabajoUpsertDTO dto)
        {
            var response = await _http.PostAsJsonAsync(
                "entidadAgenda/actividades/horas",
                dto
            );

            response.EnsureSuccessStatusCode();
        }
        public async Task GuardarObservacionesAsync(
            int idChecklistAsignacion,
            string? observaciones)
        {
            var dto = new ObservacionesDTO
            {
                Observaciones = observaciones
            };

            var response = await _http.PatchAsJsonAsync(
                $"entidadAgenda/actividades/{idChecklistAsignacion}/observaciones",
                dto
            );

            response.EnsureSuccessStatusCode();
        }

        public async Task CrearHistorialFechaAsync(HistorialFechaCreateDTO dto)
        {
            await _http.PostAsJsonAsync("entidadAgenda/historial-fecha", dto);
        }

        public async Task<List<HistorialItemDTO>> ObtenerHistorialFechasAsync(int idHoras)
        {
            return await _http.GetFromJsonAsync<List<HistorialItemDTO>>(
                $"entidadAgenda/historial-fecha/{idHoras}"
            ) ?? new();
        }

        public async Task<List<ServicioClienteAgendaDTO>> ObtenerAgendaServicioCliente()
        {
            return await _http.GetFromJsonAsync<List<ServicioClienteAgendaDTO>>(
                "entidadAgenda/mostrarDias"
            ) ?? new();
        }

    }


}
