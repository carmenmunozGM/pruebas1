using pruebas1.Components.DTOs;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Diagnostics;

namespace pruebas1.Servicios
{
    public class ArchivoPermanenteService
    {
        private readonly HttpClient _http;

        public ArchivoPermanenteService(HttpClient http)
        {
            _http = http;
        }

        public string UrlBase => _http.BaseAddress!.ToString().TrimEnd('/');

        #region Sincronización

        public async Task<bool> InicializarEstructura()
        {
            var response = await _http.PostAsync("/archivoPermanente/archivo-permanente/inicializar", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> SincronizarDesdeSharePoint()
        {
            var response = await _http.PostAsync("/archivoPermanente/archivo-permanente/sincronizar", null);
            return response.IsSuccessStatusCode;
        }

        #endregion

        #region Árbol

        public async Task<List<ArchivoPermanenteNodoDTO>> ObtenerArbol()
        {
            return await _http.GetFromJsonAsync<List<ArchivoPermanenteNodoDTO>>(
                "/archivoPermanente/archivo-permanente/arbol")
                ?? new List<ArchivoPermanenteNodoDTO>();
        }

        #endregion

        #region Carpetas

        public async Task<bool> CrearCarpeta(CrearCarpetaDTO dto)
        {
            var response = await _http.PostAsJsonAsync(
                "/archivoPermanente/archivo-permanente/carpeta",
                dto);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EliminarCarpeta(int idUbicacion)
        {
            var response = await _http.DeleteAsync(
                $"/archivoPermanente/archivo-permanente/carpeta/{idUbicacion}");

            return response.IsSuccessStatusCode;
        }

        #endregion

        #region Archivos

        public async Task SubirArchivoAsync(ArchivoPermanenteCrearDTO dto)
        {
            using var content = new MultipartFormDataContent();

            // --- DEBUG EN EL FRONT-END ---
            Debug.WriteLine("=== DEBUG SUBIDA DE ARCHIVOS ===");
            Debug.WriteLine($"IdCarpetaPadre enviado: '{dto.IdCarpetaPadre}'");
            Debug.WriteLine($"NombreCarpeta enviado: '{dto.NombreCarpeta}'");

            content.Add(new StringContent(dto.IdCarpetaPadre ?? string.Empty), nameof(dto.IdCarpetaPadre));

            if (!string.IsNullOrEmpty(dto.NombreCarpeta))
            {
                content.Add(new StringContent(dto.NombreCarpeta), nameof(dto.NombreCarpeta));
            }

            if (dto.Archivos != null)
            {
                foreach (var archivo in dto.Archivos)
                {
                    Debug.WriteLine($"Archivo adjunto: {archivo.Name} ({archivo.Size} bytes, tipo: {archivo.ContentType})");

                    var stream = archivo.OpenReadStream();
                    var streamContent = new StreamContent(stream);

                    streamContent.Headers.ContentType = new MediaTypeHeaderValue(archivo.ContentType);
                    content.Add(streamContent, "Archivos", archivo.Name);
                }
            }
            else
            {
                Debug.WriteLine("⚠️ Alerta: dto.Archivos viene nulo o vacío.");
            }

            Debug.WriteLine($"URL de destino: {_http.BaseAddress}archivoPermanente/archivo-permanente/subir");
            Debug.WriteLine("================================");
            // -----------------------------

            var response = await _http.PostAsync("/archivoPermanente/archivo-permanente/subir", content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error del servidor: {error}");
            }
        }

        public async Task<Stream?> DescargarArchivo(int idArchivo)
        {
            var response = await _http.GetAsync(
                $"/archivoPermanente/archivo-permanente/descargar/{idArchivo}");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadAsStreamAsync();
        }

        public async Task<bool> EliminarArchivo(int idArchivo)
        {
            var response = await _http.DeleteAsync(
                $"/archivoPermanente/archivo-permanente/archivo/{idArchivo}");

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> MoverArchivo(int idArchivo, int idUbicacionDestino)
        {
            var response = await _http.PutAsync(
                $"/archivoPermanente/archivo-permanente/mover?idArchivo={idArchivo}&idUbicacionDestino={idUbicacionDestino}",
                null);

            return response.IsSuccessStatusCode;
        }

        public string ObtenerUrlDescarga(int idArchivo)
        {
            return $"{UrlBase}/archivoPermanente/archivo-permanente/descargar/{idArchivo}";
        }
        #endregion

        #region Ubicaciones
        public async Task<List<UbicacionDTO>> ObtenerUbicaciones()
        {
            return await _http.GetFromJsonAsync<List<UbicacionDTO>>(
                "/archivoPermanente/archivo-permanente/ubicaciones")
                ?? new List<UbicacionDTO>();
        }
        #endregion
    }
}