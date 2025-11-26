using pruebas1.Components;
using pruebas1.Components.DTOs;
using pruebas1.Entidades;
using System.Net.Http.Json;

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

                idSala = 0, // si tu API necesita una sala, cámbialo
                ubicacion = t.Ubicacion ?? "",

                participantes = new List<object>() // si de momento no manejas participantes
            };

            var response = await httpClient.PostAsJsonAsync("eventos/crear", dto);
            return response.IsSuccessStatusCode;
        }

        // OBTENER TAREAS
        public async Task<List<TareaApi>> ObtenerTareasApi(int idAgenda)
        {
            var url = $"tareas?idAgenda={idAgenda}";
            var data = await httpClient.GetFromJsonAsync<List<TareaApi>>(url);
            return data ?? new List<TareaApi>();
        }

        // OBTENER EVENTOS
        public async Task<List<EventoApiDTO>> ObtenerEventosApi(int idAgenda)
        {
            var url = $"eventos?idAgenda={idAgenda}";

            var data = await httpClient.GetFromJsonAsync<List<EventoApiDTO>>(url);
            return data ?? new List<EventoApiDTO>();
        }
    }
}
