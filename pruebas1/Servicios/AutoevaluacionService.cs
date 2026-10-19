using APIProyectoSPEC.DTOs;
using pruebas1.Components.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace pruebas1.Servicios
{
    public class AutoevaluacionService
    {
        private readonly HttpClient _http;
        private readonly string _baseApi;

        public AutoevaluacionService(HttpClient http)
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

        // ------------------------------------------
        // GET - Autoevaluación por mes y año
        // ------------------------------------------
        public async Task<List<AutoevaluacionDTO>>
            ObtenerAutoevaluacionMesAnio(int mes, int anio)
        {
            try
            {
                string url =
                    $"{_baseApi}/vistaAutoevaluacion/vista-autoevaluacion/AutoevalacionMesAnio" +
                    $"?mes={mes}&anio={anio}";

                var result =
                    await _http.GetFromJsonAsync<List<AutoevaluacionDTO>>(url);

                return result ?? new List<AutoevaluacionDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"[AutoevaluacionService] ObtenerAutoevaluacionMesAnio: {ex.Message}");

                return new List<AutoevaluacionDTO>();
            }
        }

        // ------------------------------------------
        // GET - Autoevaluación general del empleado
        // ------------------------------------------
        public async Task<List<AutoevaluacionDTO>> ObtenerAutoevaluacion()
        {
            try
            {
                string url =
                    $"{_baseApi}/vistaAutoevaluacion/vista-autoevaluacion/MiAutoevaluacion";

                var result =
                    await _http.GetFromJsonAsync<List<AutoevaluacionDTO>>(url);

                return result ?? new List<AutoevaluacionDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"[AutoevaluacionService] ObtenerAutoevaluacion: {ex.Message}");

                return new List<AutoevaluacionDTO>();
            }
        }

        // ------------------------------------------
        // GET - Autoevaluación diaria
        // ------------------------------------------
        public async Task<List<AutoevaluacionDTO>> ObtenerAutoevaluacionDiaria()
        {
            try
            {
                string url =
                    $"{_baseApi}/vistaAutoevaluacion/vista-autoevaluacion/AutoevaluacionPorFecha";

                var result =
                    await _http.GetFromJsonAsync<List<AutoevaluacionDTO>>(url);

                return result ?? new List<AutoevaluacionDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"[AutoevaluacionService] ObtenerAutoevaluacionDiaria: {ex.Message}");

                return new List<AutoevaluacionDTO>();
            }
        }

        // ------------------------------------------
        // POST - Guardar autoevaluación
        // ------------------------------------------
        public async Task<bool> GuardarAutoevaluacion(
            GuardarAutoevaluacionEmpleadoDTO dto)
        {
            string url =
                $"{_baseApi}/vistaAutoevaluacion/vista-autoevaluacion/guardar";

            var resp = await _http.PostAsJsonAsync(url, dto);

            if (!resp.IsSuccessStatusCode)
            {
                var error = await resp.Content.ReadAsStringAsync();
                throw new Exception(error);
            }

            return true;
        }

        // ------------------------------------------
        // POST - Guardar autoevaluación con cancelación
        // ------------------------------------------
        public async Task<bool> GuardarAutoevaluacion(
            GuardarAutoevaluacionEmpleadoDTO dto,
            CancellationToken cancellationToken)
        {
            string url =
                $"{_baseApi}/vistaAutoevaluacion/vista-autoevaluacion/guardar";

            var resp = await _http.PostAsJsonAsync(
                url, dto, cancellationToken);

            if (!resp.IsSuccessStatusCode)
            {
                var error =
                    await resp.Content.ReadAsStringAsync(cancellationToken);

                throw new Exception(error);
            }

            return true;
        }

        // ------------------------------------------
        // PUT - Marcar registro como realizado
        // ------------------------------------------
        public async Task<bool> MarcarRegistroRealizadoAsync(
            int idRegistro, bool realizado)
        {
            try
            {
                string url =
                    $"{_baseApi}/vistaAutoevaluacion/vista-autoevaluacion/dia/realizado";

                var payload = new
                {
                    idRegistro,
                    realizado
                };

                var response = await _http.PutAsJsonAsync(url, payload);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();

                    Console.WriteLine(
                        $"[AutoevaluacionService] PUT error: {error}");

                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"[AutoevaluacionService] Exception PUT: {ex.Message}");

                return false;
            }
        }

        // ------------------------------------------
        // GET - Resumen general del dashboard
        // ------------------------------------------
        public async Task<AutoevaluacionResumenDTO?>
            ObtenerResumenAutoevaluacionAsync()
        {
            try
            {
                string url =
                    $"{_baseApi}/autoevaluacionesdash/api/autoevaluaciones/resumen";

                return await _http
                    .GetFromJsonAsync<AutoevaluacionResumenDTO>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"[AutoevaluacionService] Error en resumen: {ex.Message}");

                return null;
            }
        }

        // ------------------------------------------
        // GET - Resumen del dashboard por periodo
        // ------------------------------------------
        public async Task<AutoevaluacionResumenDTO?>
            ObtenerResumenAutoevaluacionAsync(
                DateTime desde, DateTime hasta)
        {
            try
            {
                string url =
                    $"{_baseApi}/autoevaluacionesdash/api/autoevaluaciones/resumen" +
                    $"?desde={desde:yyyy-MM-dd}&hasta={hasta:yyyy-MM-dd}";

                return await _http
                    .GetFromJsonAsync<AutoevaluacionResumenDTO>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"[AutoevaluacionService] Error en resumen por periodo: {ex.Message}");

                return null;
            }
        }

        // ------------------------------------------
        // GET - Detalle individual general
        // Compatible con las llamadas sin parámetros
        // ------------------------------------------
        public async Task<List<TotalAutoevaluacionesDTO>>
            ObtenerDetalleIndividualAsync()
        {
            try
            {
                string url =
                    $"{_baseApi}/autoevaluacionesdash/api/autoevaluaciones/detalle-individual";

                var resultado =
                    await _http.GetFromJsonAsync<List<TotalAutoevaluacionesDTO>>(url);

                return resultado ?? new List<TotalAutoevaluacionesDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"[AutoevaluacionService] Error en detalle individual: {ex.Message}");

                return new List<TotalAutoevaluacionesDTO>();
            }
        }

        // ------------------------------------------
        // GET - Detalle individual por periodo
        // ------------------------------------------
        public async Task<List<TotalAutoevaluacionesDTO>>
            ObtenerDetalleIndividualAsync(DateTime desde, DateTime hasta)
        {
            try
            {
                string url =
                    $"{_baseApi}/autoevaluacionesdash/api/autoevaluaciones/detalle-individual" +
                    $"?desde={desde:yyyy-MM-dd}&hasta={hasta:yyyy-MM-dd}";

                var resultado =
                    await _http.GetFromJsonAsync<List<TotalAutoevaluacionesDTO>>(url);

                return resultado ?? new List<TotalAutoevaluacionesDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"[AutoevaluacionService] Error en detalle por periodo: {ex.Message}");

                return new List<TotalAutoevaluacionesDTO>();
            }
        }
    }
}