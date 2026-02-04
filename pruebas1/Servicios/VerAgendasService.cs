using pruebas1.Components;
using pruebas1.Components.DTOs;
using pruebas1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Servicios
{
    public class VerAgendasService
    {
        private readonly HttpClient httpClient;
        private readonly LoginService loginService;
        private int? selectedPrioridadId;
        private readonly HttpClient _http;

        public VerAgendasService(HttpClient httpClient, LoginService loginService)
        {
            this.httpClient = httpClient;
            this.loginService = loginService;
            this.httpClient = httpClient;
            _http = httpClient;
        }

        public async Task<int> GetAgendaPorEmpleado(int idEmpleado)
        {
            return await _http.GetFromJsonAsync<int>(
                $"/empleado/agendaPorEmpleado/{idEmpleado}");
        }

        public async Task<List<TareaApi>> GetTareasAgenda(int idAgenda)
        {
            return await _http.GetFromJsonAsync<List<TareaApi>>(
                $"/tareas/porAgenda?idAgenda={idAgenda}"
            ) ?? new();
        }

        public async Task<List<EventoApiDTO>> GetEventosAgenda(int idAgenda)
        {
            return await _http.GetFromJsonAsync<List<EventoApiDTO>>(
                $"/eventos/{idAgenda}"
            ) ?? new();
        }

        public async Task<List<OrdenTrabajoDTO>> GetOTHoyAgenda(int idAgenda)
        {
            return await _http.GetFromJsonAsync<List<OrdenTrabajoDTO>>(
                $"/ordenTrabajo/ordenTrabajo/hoyAgenda?agendaId={idAgenda}"
            ) ?? new();
        }

        public async Task<List<OrdenTrabajoDTO>> GetOTProximasAgenda(int idAgenda)
        {
            return await _http.GetFromJsonAsync<List<OrdenTrabajoDTO>>(
                $"/ordenTrabajo/ordenTrabajo/proximasAgenda?agendaId={idAgenda}"
            ) ?? new();
        }

        public async Task<List<OrdenTrabajoDTO>> GetOTVencidasAgenda(int idAgenda)
        {
            return await _http.GetFromJsonAsync<List<OrdenTrabajoDTO>>(
                $"/ordenTrabajo/ordenTrabajo/vencidasAgenda?agendaId={idAgenda}"
            ) ?? new();
        }

        public async Task<List<OrdenTramiteDTO>> GetTRAHoyAgenda(int idAgenda)
        {
            return await _http.GetFromJsonAsync<List<OrdenTramiteDTO>>(
                $"/ordenTramite/hoyAgenda?agendaId={idAgenda}"
            ) ?? new();
        }

        public async Task<List<OrdenTramiteDTO>> GetTRAProximasAgenda(int idAgenda)
        {
            return await _http.GetFromJsonAsync<List<OrdenTramiteDTO>>(
                $"/ordenTramite/proximasAgenda?agendaId={idAgenda}"
            ) ?? new();
        }

        public async Task<List<OrdenTramiteDTO>> GetTRAVencidasAgenda(int idAgenda)
        {
            return await _http.GetFromJsonAsync<List<OrdenTramiteDTO>>(
                $"/ordenTramite/vencidasAgenda?agendaId={idAgenda}"
            ) ?? new();
        }

        public async Task<List<AutoevaluacionDTO>> GetAutoevaluacionAgenda(int idAgenda)
        {
            return await _http.GetFromJsonAsync<List<AutoevaluacionDTO>>(
                $"/vistaAutoevaluacion/vista-autoevaluacion/AutoevaluacionPorAgenda?agendaId={idAgenda}"
            ) ?? new();
        }

        public async Task<List<ServicioClienteAgendaDTO>> GetServicioClienteAgenda(int idAgenda)
        {
            return await _http.GetFromJsonAsync<List<ServicioClienteAgendaDTO>>(
                $"/entidadAgenda/servicioPorAgenda?agendaId={idAgenda}"
            ) ?? new();
        }

        public async Task<AgendaCompletaDTO> CargarAgendaCompleta(int idEmpleado)
        {
            var agendaId = await GetAgendaPorEmpleado(idEmpleado);

            var agenda = new AgendaCompletaDTO
            {
                AgendaId = agendaId
            };

            var tareasTask = GetTareasAgenda(agendaId);
            var eventosTask = GetEventosAgenda(agendaId);

            var otHoyTask = GetOTHoyAgenda(agendaId);
            var otProxTask = GetOTProximasAgenda(agendaId);
            var otVencTask = GetOTVencidasAgenda(agendaId);

            var traHoyTask = GetTRAHoyAgenda(agendaId);
            var traProxTask = GetTRAProximasAgenda(agendaId);
            var traVencTask = GetTRAVencidasAgenda(agendaId);

            var autoevalTask = GetAutoevaluacionAgenda(agendaId);
            var serviciosTask = GetServicioClienteAgenda(agendaId);

            await Task.WhenAll(
                tareasTask, eventosTask,
                otHoyTask, otProxTask, otVencTask,
                traHoyTask, traProxTask, traVencTask,
                autoevalTask, serviciosTask
            );

            agenda.Tareas = await tareasTask;
            agenda.Eventos = await eventosTask;

            agenda.OTHoy = await otHoyTask;
            agenda.OTProximas = await otProxTask;
            agenda.OTVencidas = await otVencTask;

            agenda.TRAHoy = await traHoyTask;
            agenda.TRAProximas = await traProxTask;
            agenda.TRAVencidas = await traVencTask;

            agenda.Autoevaluaciones = await autoevalTask;
            agenda.Servicios = await serviciosTask;

            return agenda;
        }

        public async Task<AgendaCompletaDTO> GetAgendaCompleta(int idEmpleado)
        {
            var agendaId = await GetAgendaPorEmpleado(idEmpleado);

            var tareasTask = GetTareasAgenda(agendaId);
            var eventosTask = GetEventosAgenda(agendaId);
            var otHoyTask = GetOTHoyAgenda(agendaId);
            var otProxTask = GetOTProximasAgenda(agendaId);
            var otVencidasTask = GetOTVencidasAgenda(agendaId);
            var traHoyTask = GetTRAHoyAgenda(agendaId);
            var traProxTask = GetTRAProximasAgenda(agendaId);
            var traVencidasTask = GetTRAVencidasAgenda(agendaId);
            var autoTask = GetAutoevaluacionAgenda(agendaId);
            var servicioTask = GetServicioClienteAgenda(agendaId);

            await Task.WhenAll(
                tareasTask, eventosTask,
                otHoyTask, otProxTask, otVencidasTask,
                traHoyTask, traProxTask, traVencidasTask,
                autoTask, servicioTask
            );

            return new AgendaCompletaDTO
            {
                AgendaId = agendaId,
                Tareas = tareasTask.Result,
                Eventos = eventosTask.Result,
                OTHoy = otHoyTask.Result,
                OTProximas = otProxTask.Result,
                OTVencidas = otVencidasTask.Result,
                TRAHoy = traHoyTask.Result,
                TRAProximas = traProxTask.Result,
                TRAVencidas = traVencidasTask.Result,
                Autoevaluaciones = autoTask.Result,
                Servicios = servicioTask.Result
            };
        }
    }
}
