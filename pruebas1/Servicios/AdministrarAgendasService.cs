using pruebas1.Components.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Servicios
{
    public class AdministrarAgendasService
    {
        private readonly LoginService loginService;
        private int? selectedPrioridadId;
        private readonly HttpClient _http;

        public AdministrarAgendasService(HttpClient httpClient, LoginService loginService)
        {
            this.loginService = loginService;
            _http = httpClient;
        }

        public async Task<int?> PostAgendaNueva(int clavePersonal, int clavePuesto, int realizadoPor)
        {
            var dto = new CrearAgendaRequestDTO
            {
                ClavePersonal = clavePersonal,
                ClavePuesto = clavePuesto,
                RealizadoPor = realizadoPor
            };

            var response = await _http.PostAsJsonAsync("/asignacionUsuarioAgenda/crear", dto);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<bool> PutReasignarAgenda(int clavePersonal, int clavePuesto, int agendaId, int realizadoPor)
        {
            var dto = new ReasignarAgendaRequestDTO
            {
                ClavePersonal = clavePersonal,
                ClavePuesto = clavePuesto,
                AgendaId = agendaId,
                RealizadoPor = realizadoPor
            };

            var response = await _http.PutAsJsonAsync("/asignacionUsuarioAgenda/resignar", dto);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PutDesvincularAgenda(int agendaId)
        {
            var response = await _http.PutAsync($"/asignacionUsuarioAgenda/desvincular/{agendaId}", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<AgendaAdminDTO>> GetAgendasPorPuesto(int clavePuesto)
        {
            var agendas = await _http.GetFromJsonAsync<List<AgendaAdminDTO>>(
                $"/asignacionUsuarioAgenda/puesto/{clavePuesto}");

            return agendas ?? new List<AgendaAdminDTO>();
        }
    }
}
