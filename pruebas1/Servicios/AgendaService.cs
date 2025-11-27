using pruebas1.Components;
using pruebas1.Components.DTOs;
using pruebas1.Entidades;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;
using System.Diagnostics;

namespace pruebas1.Servicios
{
    public class AgendaService
    {
        private readonly HttpClient httpClient;
        private readonly LoginService loginService;

        public AgendaService(HttpClient httpClient, LoginService loginService)
        {
            this.httpClient = httpClient;
            this.loginService = loginService;
        }

        // CREAR TAREA
        public async Task<bool> CrearTareaApi(TareaCreada tarea)
        {
            var usuario = loginService.obtenerUsuarioLogueado();

            int idAgenda = usuario.IdAgendasAsignadas.FirstOrDefault();
            int idCreador = usuario.IdUsuario;

            var dto = new
            {
                idAgenda = idAgenda,
                titulo = tarea.Titulo,
                descripcion = tarea.Descripcion,
                fechaInicio = tarea.FechaInicio,
                fechaFin = tarea.FechaFin,
                esRecurrente = false,
                reglaRecurrencia = "",
                todoElDia = true,
                idPrioridad = 1,
                idCreador = idCreador,
                subTareas = tarea.Subtareas.Select((s, i) => new
                {
                    id = 0,
                    titulo = s,
                    completada = false,
                    fechaCompletada = (DateTime?)null,
                    orden = i
                }).ToList()
            };

            var response = await httpClient.PostAsJsonAsync("tareas/crear", dto);
            return response.IsSuccessStatusCode;
        }

        // CREAR EVENTO
        public async Task<bool> CrearEventoApi(TareaCreada t)
        {
            var dto = new
            {
                idAgenda = t.IdAgenda,
                titulo = t.Titulo,
                descripcion = t.Descripcion,
                fechaInicio = t.FechaInicio ?? DateTime.Now,
                fechaFin = t.FechaFin ?? DateTime.Now,
                todoElDia = true,
                idPrioridad = 1,
                idSala = 0,
                ubicacion = t.Ubicacion ?? "",
                participantes = new List<object>()
            };

            var response = await httpClient.PostAsJsonAsync("eventos/crear", dto);
            return response.IsSuccessStatusCode;
        }

        // OBTENER AGENDA ASIGNADAS
        public async Task<List<int>> ObtenerAgendaAsignadasAsync()
        {
            var usuario = loginService.obtenerUsuarioLogueado();
            if (usuario == null || string.IsNullOrEmpty(usuario.Token))
                return new List<int>();

            using var request = new HttpRequestMessage(HttpMethod.Get, "agenda/ObtenerAsignadas");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", usuario.Token);

            var response = await httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                Debug.WriteLine($"Error al obtener agendas asignadas: {response.StatusCode}");
                return new List<int>();
            }

            var lista = await response.Content.ReadFromJsonAsync<List<AgendaAsignadaDTO>>();
            return lista?.Select(a => a.Id).ToList() ?? new List<int>();
        }

        // OBTENER TAREAS
        public async Task<List<TareaApi>> ObtenerTareasApi(int idAgenda)
        {
            var usuario = loginService.obtenerUsuarioLogueado();
            if (usuario == null || string.IsNullOrEmpty(usuario.Token))
                return new List<TareaApi>();

            try
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", usuario.Token);

                var url = $"tareas?idAgenda={idAgenda}";
                var data = await httpClient.GetFromJsonAsync<List<TareaApi>>(url);
                return data ?? new List<TareaApi>();
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"Error al obtener tareas: {ex.Message}");
                return new List<TareaApi>();
            }
        }

        // OBTENER EVENTOS
        public async Task<List<EventoApiDTO>> ObtenerEventosApi(int idAgenda)
        {
            var usuario = loginService.obtenerUsuarioLogueado();
            if (usuario == null || string.IsNullOrEmpty(usuario.Token))
                return new List<EventoApiDTO>();

            try
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", usuario.Token);

                var url = $"eventos/?idAgenda={idAgenda}";
                var data = await httpClient.GetFromJsonAsync<List<EventoApiDTO>>(url);
                return data ?? new List<EventoApiDTO>();
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"Error al obtener eventos: {ex.Message}");
                return new List<EventoApiDTO>();
            }
        }
    }
}
