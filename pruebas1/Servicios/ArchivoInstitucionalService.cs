using System.Net.Http.Json;
using AgendaFront.DTOs;

namespace AgendaFront.Services
{
    public class ArchivoInstitucionalService
    {
        private readonly HttpClient _httpClient;

        public ArchivoInstitucionalService(
            HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> SincronizarEstructuraAsync()
        {
            const string endpoint =
                "archivoPermanente/archivo-permanente/sincronizar-institucional";

            var response =
                await _httpClient.PostAsync(endpoint, null);

            if (!response.IsSuccessStatusCode)
            {
                var detalle = await response.Content.ReadAsStringAsync();

                throw new Exception(
                    $"Error HTTP {(int)response.StatusCode}: {detalle}");
            }

            return true;
        }
        public async Task<List<ArchivoInstitucionalNodoDTO>>
            ObtenerArbolAsync()
        {
            const string endpoint =
                "archivoPermanente/archivo-permanente/arbol?tipoUbicacion=INSTITUCIONAL";

            var response =
                await _httpClient.GetAsync(endpoint);

            response.EnsureSuccessStatusCode();

            return
                await response.Content.ReadFromJsonAsync<
                    List<ArchivoInstitucionalNodoDTO>>()
                ?? new List<ArchivoInstitucionalNodoDTO>();
        }
        public string ObtenerUrlVisualizacion(
            int idArchivo)
        {
            return
                $"{_httpClient.BaseAddress}" +
                $"archivoPermanente/archivo-permanente/visualizar/{idArchivo}";
        }
        public string ObtenerUrlArchivo(
            int idArchivo)
        {
            return
                $"{_httpClient.BaseAddress}" +
                $"archivoPermanente/archivo-permanente/descargar/{idArchivo}";
        }
    }
}