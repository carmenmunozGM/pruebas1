using pruebas1.Components.DTOs;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.JSInterop;

namespace pruebas1.Servicios
{
    public class InfoPersonalService
    {
        private readonly HttpClient _http;
        private readonly string _baseApi;

        public InfoPersonalService(HttpClient http)
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


        //public async Task<CumpleaniosDTO?> GetMiCumpleanios()
        //{
        //    try
        //    {
        //        var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        //        return await _http.GetFromJsonAsync<CumpleaniosDTO>($"{_baseApi}/api/personal/cumpleanios", opciones);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Esto lanzará el error REAL a la consola del navegador (F12)
        //        Console.WriteLine($"[CUMPLE ERROR]: {ex.Message}");
        //        return null;
        //    }
        //}
        public async Task<CumpleaniosDTO?> GetMiCumpleanios()
        {
            try
            {
                // Usamos la misma Key que tu LoginService ("token")
                var token = Preferences.Get("token", "");
                if (!string.IsNullOrEmpty(token))
                {
                    _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                // La ruta debe llevar /personal/cumpleanios
                return await _http.GetFromJsonAsync<CumpleaniosDTO>($"{_baseApi}/infoPersonal/personal/cumpleanios", opciones);
            }

            catch (Exception ex)
            {
                Console.WriteLine($"[CUMPLE ERROR]: {ex.Message}");
                return null;
            }
        }
        public async Task<List<CumpleaniosDTO>> GetTodosLosCumpleanios()
        {
            try
            {
                return await _http.GetFromJsonAsync<List<CumpleaniosDTO>>($"{_baseApi}/infoPersonal/personal/todos-cumpleanios")
              
                       ?? new List<CumpleaniosDTO>();
            }
            catch { return new List<CumpleaniosDTO>(); }
        }
        public async Task<List<VacacionesDTO>> GetMisVacaciones()
        {
            try
            {
                string url = $"{_baseApi}/infoPersonal/personal/vacaciones";
            

                // Agregamos esta configuración mágica:
                var opciones = new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return await _http.GetFromJsonAsync<List<VacacionesDTO>>(url, opciones)
                       ?? new List<VacacionesDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<VacacionesDTO>();
            }
        }
    }
}