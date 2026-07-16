using pruebas1.Components.DTOs;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace pruebas1.Servicios
{
    public class ArchivoPermanenteService
    {
        private readonly HttpClient _http;

        public ArchivoPermanenteService(HttpClient http)
        {
            _http = http;
        }

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

        public async Task<bool> SubirArchivo(ArchivoPermanenteCrearFrontDTO dto)
        {
            using var form = new MultipartFormDataContent();

            form.Add(
                new StringContent(dto.IdCarpetaPadre),
                "idCarpetaPadre");

            if (!string.IsNullOrWhiteSpace(dto.NombreCarpeta))
            {
                form.Add(
                    new StringContent(dto.NombreCarpeta),
                    "nombreCarpeta");
            }

            foreach (var archivo in dto.Archivos)
            {
                var contenido = new StreamContent(
                    archivo.OpenReadStream(100 * 1024 * 1024));

                contenido.Headers.ContentType =
                    new MediaTypeHeaderValue(archivo.ContentType);

                form.Add(
                    contenido,
                    "archivos",
                    archivo.Name);
            }

            var response = await _http.PostAsync(
                "/archivoPermanente/archivo-permanente/subir",
                form);

            return response.IsSuccessStatusCode;
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