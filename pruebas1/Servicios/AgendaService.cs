using pruebas1.Components;
using pruebas1.Components.DTOs;
using pruebas1.Entidades;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using static System.Net.WebRequestMethods;
using System.Text.Json;

namespace pruebas1.Servicios
{
    public class AgendaService
    {
        private readonly HttpClient httpClient;
        private readonly LoginService loginService;
        private int? selectedPrioridadId;

        public AgendaService(HttpClient httpClient, LoginService loginService)
        {
            this.httpClient = httpClient;
            this.loginService = loginService;
            this.httpClient = httpClient;
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
        /*  public async Task<bool> CrearEventoApi(TareaCreada t)
          {
              // Obtener usuario actual
              var usuario = loginService.obtenerUsuarioLogueado();
              if (usuario == null)
                  return false;

              // Asegurar agenda
              int idAgenda = t.IdAgenda > 0 ? t.IdAgenda : usuario.IdAgendasAsignadas.FirstOrDefault();

              var dto = new
              {
                  idAgenda = idAgenda,
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

              Debug.WriteLine($"[CREAR EVENTO] POST /eventos  → Agenda: {idAgenda}, Título: {t.Titulo}");

              var response = await httpClient.PostAsJsonAsync("eventos", dto);

              Debug.WriteLine($"Respuesta crear evento: {response.StatusCode}");

              return response.IsSuccessStatusCode;
          }*/
        public async Task<bool> CrearEventoApi(TareaCreada evento)
        {
            try
            {
                var usuario = loginService.obtenerUsuarioLogueado();
                if (usuario == null || string.IsNullOrEmpty(usuario.Token))
                    return false;

                // Header Authorization
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", usuario.Token);

                int idAgenda = evento.IdAgenda > 0 ? evento.IdAgenda : usuario.IdAgendasAsignadas.FirstOrDefault();

                // Obtener IDs de participantes
                var idsParticipantes = evento.ParticipantesSeleccionados != null && evento.ParticipantesSeleccionados.Any()
                    ? evento.ParticipantesSeleccionados
                    : (evento.ParticipantesLista?.Select(p => p.Id).ToList() ?? new List<int>());

                var dto = new
                {
                    idAgenda = idAgenda,
                    titulo = evento.Titulo,
                    descripcion = evento.Descripcion ?? "",
                    fechaInicio = (evento.FechaInicio ?? DateTime.Now).ToString("yyyy-MM-ddTHH:mm:ss"),
                    fechaFin = (evento.FechaFin ?? DateTime.Now).ToString("yyyy-MM-ddTHH:mm:ss"),
                    esRecurrente = evento.EsRecurrente,
                    reglaRecurrencia = string.IsNullOrEmpty(evento.ReglaRecurrencia) ? null : evento.ReglaRecurrencia,
                    // Ahora usamos la prioridad del usuario
                    idPrioridad = evento.Prioridad > 0 ? evento.Prioridad : 1,
                    idSala = evento.IdSala > 0 ? evento.IdSala : null as int?,
                    ubicacion = evento.Ubicacion ?? "",
                    idsParticipantes = idsParticipantes // API espera este campo
                };

                var json = JsonSerializer.Serialize(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                Debug.WriteLine("[CREAR EVENTO] POST → https://redgm.site:9096/eventos");
                Debug.WriteLine(json);

                var response = await httpClient.PostAsync("https://redgm.site:9096/eventos", content);

                Debug.WriteLine($"[CREAR EVENTO] Status: {response.StatusCode}");
                if (!response.IsSuccessStatusCode)
                {
                    var respText = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"[CREAR EVENTO] Error details: {respText}");
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ Excepción CrearEventoApi: {ex.Message}");
                return false;
            }
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
        /*public async Task<List<EventoApiDTO>> ObtenerEventosApi(int idAgenda)
        {
            var usuario = loginService.obtenerUsuarioLogueado();
            if (usuario == null || string.IsNullOrEmpty(usuario.Token))
                return new List<EventoApiDTO>();

            try
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", usuario.Token);

                var url = $"eventos?idAgenda={idAgenda}";
                Debug.WriteLine($"[GET EVENTOS] URL = {url}");

                var data = await httpClient.GetFromJsonAsync<List<EventoApiDTO>>(url);

                Debug.WriteLine($"[GET EVENTOS] Eventos recibidos: {data?.Count}");

                return data ?? new List<EventoApiDTO>();
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"Error al obtener eventos: {ex.Message}");
                return new List<EventoApiDTO>();
            }
        }*/
        public async Task<List<EventoApiDTO>> ObtenerEventos(int idAgenda)
        {
            var lista = new List<EventoApiDTO>();

            try
            {
                var usuario = loginService.obtenerUsuarioLogueado();
                if (usuario == null || string.IsNullOrEmpty(usuario.Token))
                    return lista;

                // Header auth
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", usuario.Token);

                string url = $"https://redgm.site:9096/eventos/{idAgenda}";
                Debug.WriteLine($"[GET EVENTOS] URL = {url}");

                var result = await httpClient.GetAsync(url);

                if (!result.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"❌ Error al obtener eventos → {result.StatusCode}");
                    return lista;
                }

                string json = await result.Content.ReadAsStringAsync();
                lista = JsonSerializer.Deserialize<List<EventoApiDTO>>(json) ?? new List<EventoApiDTO>();

                Debug.WriteLine($"Eventos recibidos desde API: {lista.Count}");
                return lista;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ Excepción GET eventos: {ex.Message}");
                return lista;
            }
        }


    }
}

