using pruebas1.Components.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Servicios
{
    public class AreasService
    {
        private readonly HttpClient httpClient;
        private readonly LoginService loginService;
        private int? selectedPrioridadId;
        private readonly HttpClient _http;

        public AreasService(HttpClient httpClient, LoginService loginService)
        {
            this.httpClient = httpClient;
            this.loginService = loginService;
            this.httpClient = httpClient;
            _http = httpClient;
        }

        // Lista de areas.
        public async Task<List<AreaDTO>> GetAreas()
        {
            var areas = await httpClient.GetFromJsonAsync<List<AreaDTO>>("area");
            return areas ?? new List<AreaDTO>();
        }

        // Lista de pustos.
        public async Task<List<PuestoDTO>> GetPuestos()
        {
            var puestos = await httpClient.GetFromJsonAsync<List<PuestoDTO>>("area/puestos");
            return puestos ?? new List<PuestoDTO>();
        }
    }
}
