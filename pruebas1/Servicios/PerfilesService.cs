using APIProyectoSPEC.DTOs;
using pruebas1.Components.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Servicios
{
    public class PerfilesService
    {
        private readonly HttpClient _http;

        public PerfilesService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<PerfilesDTO>> GetPerfiles()
        {
            var respuesta = await _http.GetFromJsonAsync<List<PerfilesDTO>>(
                $"/perfiles/Obtener");

            return respuesta ?? new List<PerfilesDTO>();
        }

        public async Task<List<EmpleadoPerfilDTO>> GetEmpleadosPerfiles()
        {
            var respuesta = await _http.GetFromJsonAsync<List<EmpleadoPerfilDTO>>(
                $"/perfiles/ObtenerPerfiles");

            return respuesta ?? new List<EmpleadoPerfilDTO>();
        }

        public async Task<bool> GuardarPerfiles(List<EditarPerfilDTO> cambios)
        {
            var response = await _http.PostAsJsonAsync(
                $"/perfiles/GuardarPerfiles",
                cambios);

            return response.IsSuccessStatusCode;
        }

        public async Task<PermisosDTO> GetPermisos()
        {
            var respuesta = await _http.GetFromJsonAsync<PermisosDTO>(
                $"/empleado/permisos");

            return respuesta ?? new PermisosDTO();
        }

        // --- PERMISOS DE DASHBOARD ---

        public async Task<bool> GetMiAccesoDashboard()
        {
            return await _http.GetFromJsonAsync<bool>(
                "/api/permisos-dashboard/mi-acceso");
        }

        public async Task<List<PermisoDashboardDTO>> GetPermisosDashboard()
        {
            var respuesta = await _http.GetFromJsonAsync<List<PermisoDashboardDTO>>(
                "/api/permisos-dashboard/todos");

            return respuesta ?? new List<PermisoDashboardDTO>();
        }

        public async Task<bool> GuardarPermisoDashboard(UpsertPermisoDashboardDTO dto)
        {
            System.Diagnostics.Debug.WriteLine(
                $"[Dashboard PUT] BaseAddress={_http.BaseAddress} | ClavePuesto={dto.ClavePuesto} | Visualizar={dto.VisualizarDashboard}");

            var response = await _http.PutAsJsonAsync(
                "/api/permisos-dashboard/upsert",
                dto);

            System.Diagnostics.Debug.WriteLine(
                $"[Dashboard PUT] StatusCode={(int)response.StatusCode} ({response.StatusCode})");

            if (!response.IsSuccessStatusCode)
            {
                var detalle = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine($"Error GuardarPermisoDashboard: {detalle}");
            }

            return response.IsSuccessStatusCode;
        }
    }
}