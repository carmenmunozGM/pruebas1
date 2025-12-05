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

        public async Task<List<OrdenTrabajoDTO>> GetOrdenesVencidas()
        {
            return await httpClient.GetFromJsonAsync<List<OrdenTrabajoDTO>>(
                "https://redgm.site:9096/ordenTrabajo/ordenTrabajo/vencidas");
        }

        public async Task<List<OrdenTrabajoDTO>> GetOrdenesProximas()
        {
            return await httpClient.GetFromJsonAsync<List<OrdenTrabajoDTO>>(
                "https://redgm.site:9096/ordenTrabajo/ordenTrabajo/proximas");
        }

        public async Task<List<OrdenTrabajoDTO>> GetOrdenesHoy()
        {
            return await httpClient.GetFromJsonAsync<List<OrdenTrabajoDTO>>(
                "https://redgm.site:9096/ordenTrabajo/ordenTrabajo/hoy");
        }
    }
}
