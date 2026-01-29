using pruebas1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class AgendaCompletaDTO
    {
        public int AgendaId { get; set; }

        public List<TareaApi> Tareas { get; set; } = new();
        public List<EventoApiDTO> Eventos { get; set; } = new();

        public List<OrdenTrabajoDTO> OTHoy { get; set; } = new();
        public List<OrdenTrabajoDTO> OTProximas { get; set; } = new();
        public List<OrdenTrabajoDTO> OTVencidas { get; set; } = new();

        public List<OrdenTramiteDTO> TRAHoy { get; set; } = new();
        public List<OrdenTramiteDTO> TRAProximas { get; set; } = new();
        public List<OrdenTramiteDTO> TRAVencidas { get; set; } = new();

        public List<AutoevaluacionDTO> Autoevaluaciones { get; set; } = new();
        public List<ServicioClienteAgendaDTO> Servicios { get; set; } = new();
    }

}
