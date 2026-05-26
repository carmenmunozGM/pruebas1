using pruebas1.Components.DTOs;
using System.Net.Http.Json;

namespace pruebas1.Servicios
{
    public class FichaPuestoService
    {
        private readonly HttpClient _http;

        public FichaPuestoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<FichaPuestoDTO?> GetFichaPuesto()
        {
            return await _http.GetFromJsonAsync<FichaPuestoDTO>(
                "fichasPuesto/sharepoint/fichaPuesto");
        }
    }
}