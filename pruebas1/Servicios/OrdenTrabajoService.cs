using pruebas1.Components.DTOs;
using System.Net.Http.Json;

namespace pruebas1.Servicios
{
    public class OrdenTrabajoService
    {
        private readonly HttpClient httpClient;

        public OrdenTrabajoService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<OrdenTrabajoDTO?> GetDetalle(int idOrden)
        {
            return await httpClient.GetFromJsonAsync<OrdenTrabajoDTO>(
                $"/ordenTrabajo/ordenTrabajo/orden/{idOrden}");
        }

        public async Task<List<OrdenTrabajoDTO>> GetOrdenesVencidas()
        {
            var respuesta = await httpClient.GetFromJsonAsync<List<OrdenTrabajoDTO>>(
                "/ordenTrabajo/ordenTrabajo/vencidas");

            return respuesta ?? new();
        }

        public async Task<List<OrdenTrabajoDTO>> GetOrdenesProximas()
        {
            var respuesta = await httpClient.GetFromJsonAsync<List<OrdenTrabajoDTO>>(
                "/ordenTrabajo/ordenTrabajo/proximas");

            return respuesta ?? new();
        }

        public async Task<List<OrdenTrabajoDTO>> GetOrdenesHoy()
        {
            var respuesta = await httpClient.GetFromJsonAsync<List<OrdenTrabajoDTO>>(
                "/ordenTrabajo/ordenTrabajo/hoy");

            return respuesta ?? new();
        }

        public async Task<List<OrdenTrabajoDTO>> GetOrdenesPendntes()
        {
            var respuesta = await httpClient.GetFromJsonAsync<List<OrdenTrabajoDTO>>(
                "/ordenTrabajo/ordenTrabajo/pendientes");

            return respuesta ?? new();
        }
    }
}