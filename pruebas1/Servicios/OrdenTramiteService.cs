using pruebas1.Components.DTOs;
using System.Net.Http.Json;

namespace pruebas1.Servicios
{
    public class OrdenTramiteService
    {
        private readonly HttpClient _http;
        private readonly string _baseApi;

        public OrdenTramiteService(HttpClient http)
        {
            _http = http;

            // Detectar si estás en LOCAL automáticamente
            var host = http.BaseAddress?.Host?.ToLower() ?? "";

            if (host == "localhost" || host == "127.0.0.1")
            {
                _baseApi = "http://localhost:5231";   
            }
            else
            {
                _baseApi = "https://redgm.site:9096"; 
            }
        }

        // 🔵 ORDEN DE TRÁMITE (DATOS GENERALES + TABLA)
        public async Task<OrdenTramiteDTO?> GetDetalle(int idOrden)
        {
            try
            {
                string url = $"{_baseApi}/ordenTramite/{idOrden}";
                return await _http.GetFromJsonAsync<OrdenTramiteDTO>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[OrdenTramiteService] GetDetalle: {ex.Message}");
                return null;
            }
        }

        // 🟣 TRÁMITE INDIVIDUAL (DETALLE + TAREAS)
        public async Task<TramiteIndividualDTO?> GetTramiteDetalle(int idTramite)
        {
            try
            {
                string url = $"{_baseApi}/ordenTramite/tramite/{idTramite}";
                return await _http.GetFromJsonAsync<TramiteIndividualDTO>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[OrdenTramiteService] GetTramiteDetalle: {ex.Message}");
                return null;
            }
        }

        public async Task<List<OrdenTramiteDTO>> GetVencidas()
        {
            try
            {
                string url = $"{_baseApi}/ordenTramite/vencidas";
                return await _http.GetFromJsonAsync<List<OrdenTramiteDTO>>(url)
                       ?? new List<OrdenTramiteDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[OrdenTramiteService] GetVencidas: {ex.Message}");
                return new List<OrdenTramiteDTO>();
            }
        }

        public async Task<List<OrdenTramiteDTO>> GetProximas()
        {
            try
            {
                string url = $"{_baseApi}/ordenTramite/proximas";
                return await _http.GetFromJsonAsync<List<OrdenTramiteDTO>>(url)
                       ?? new List<OrdenTramiteDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[OrdenTramiteService] GetProximas: {ex.Message}");
                return new List<OrdenTramiteDTO>();
            }
        }

        public async Task<List<OrdenTramiteDTO>> GetHoy()
        {
            try
            {
                string url = $"{_baseApi}/ordenTramite/hoy";
                return await _http.GetFromJsonAsync<List<OrdenTramiteDTO>>(url)
                       ?? new List<OrdenTramiteDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[OrdenTramiteService] GetHoy: {ex.Message}");
                return new List<OrdenTramiteDTO>();
            }
        }

        public async Task<List<OrdenTramiteDTO>> GetPendientes()
        {
            try
            {
                string url = $"{_baseApi}/ordenTramite";
                return await _http.GetFromJsonAsync<List<OrdenTramiteDTO>>(url)
                       ?? new List<OrdenTramiteDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[OrdenTramiteService] GetPendientes: {ex.Message}");
                return new List<OrdenTramiteDTO>();
            }
        }
    }
}
