using pruebas1.Components.DTOs;
using pruebas1.Entidades;
using System.Net.Http.Json;

namespace pruebas1.Servicios
{
    public class AgendaService
    {
        private readonly HttpClient httpClient;
        private readonly LoginService loginService;   // <-- IMPORTANTE

        public AgendaService(HttpClient httpClient, LoginService loginService)
        {
            this.httpClient = httpClient;
            this.loginService = loginService;        // <-- IMPORTANTE
        }

        // ======================================================
        // PASO 3 ───── CREAR TAREA (CORREGIDO)
        // ======================================================
        public async Task<bool> CrearTareaApi(TareaCreada tarea)
        {
            var usuario = loginService.obtenerUsuarioLogueado();

            int idAgenda = usuario.idAgendasAsignadas.FirstOrDefault();
            int idCreador = usuario.Idusuario;

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

        // ======================================================
        // PASO 4 ───── CREAR EVENTO (CORREGIDO)
        // ======================================================
        public async Task<bool> CrearEventoApi(TareaCreada evento)
        {
            var usuario = loginService.obtenerUsuarioLogueado();

            int idAgenda = usuario.idAgendasAsignadas.FirstOrDefault();
            int idCreador = usuario.Idusuario;

            var dto = new
            {
                id = 0,
                idAgenda = idAgenda,
                idCreador = idCreador,
                titulo = evento.Titulo,
                descripcion = evento.Descripcion,
                fechaInicio = evento.FechaInicio,
                fechaFin = evento.FechaFin,
                completada = false,
                fechaCompletada = (DateTime?)null,
                todoElDia = true,
                idPrioridad = 1,
                prioridad = "Media",
                idSala = 0,
                ubicacion = evento.Ubicacion ?? "",
                idsParticipantes = new int[] { idCreador }
            };

            var response = await httpClient.PostAsJsonAsync("eventos", dto);
            return response.IsSuccessStatusCode;
        }

        // Obtener tareas
        public async Task<List<TareaApi>> ObtenerTareasApi(int idAgenda)
        {
            var url = $"tareas?idAgenda={idAgenda}";
            var data = await httpClient.GetFromJsonAsync<List<TareaApi>>(url);

            return data ?? new List<TareaApi>();
        }
       /* public async Task<List<EventoApi>> ObtenerEventosApi(int idAgenda)
        {
            var url = $"eventos?idAgenda={idAgenda}";
            var data = await httpClient.GetFromJsonAsync<List<EventoApi>>(url);
            return data ?? new List<EventoApi>();
        }*/


    }
}
