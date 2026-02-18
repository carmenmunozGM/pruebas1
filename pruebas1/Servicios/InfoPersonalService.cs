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
                var token = Preferences.Get("token", "");
                if (!string.IsNullOrEmpty(token))
                {
                    _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
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
        public async Task<List<VacacionesDTO>> GetVacacionesTodos()
        {
            try
            {
                // Eliminamos la lógica del token para probar si es libre como el de cumpleaños
                return await _http.GetFromJsonAsync<List<VacacionesDTO>>($"{_baseApi}/infoPersonal/personal/todos-vacaciones")
                       ?? new List<VacacionesDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Vacaciones: {ex.Message}");
                return new List<VacacionesDTO>();
            }
        }
        public async Task<List<VacacionesDTO>> GetMisVacaciones()
        {
            try
            {
                var token = Preferences.Get("token", "");
                if (!string.IsNullOrEmpty(token))
                {
                    _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                string url = $"{_baseApi}/infoPersonal/personal/vacaciones";
                var opciones = new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var respuesta = await _http.GetFromJsonAsync<List<VacacionesDTO>>(url, opciones);

                return respuesta ?? new List<VacacionesDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Vacaciones: {ex.Message}");
                return new List<VacacionesDTO>();
            }
        }
    }
}