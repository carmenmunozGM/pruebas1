using pruebas1.Components;
using pruebas1.Components.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Entidades
{
    public class TareaCreada
    {
        public string Tipo { get; set; } = "";
        public string Titulo { get; set; } = "";
        public string Descripcion { get; set; } = "";

        public List<string> Subtareas { get; set; } = new();
        public bool IsEvento { get; set; } = false;

        // 🔥 Fechas reales
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        // 🔥 Horas reales
        public TimeOnly? HoraInicio { get; set; }
        public TimeOnly? HoraFin { get; set; }

        // 🔥 Extras
        public string? Ubicacion { get; set; }
        public string? NombreCreador { get; set; }
        public List<EmpleadoDTO> ParticipantesLista { get; set; } = new();

        public List<int> ParticipantesSeleccionados { get; set; } = new();

        public int? IdSala { get; set; } = 0;
        public bool EsRecurrente { get; set; } = false;
        public string ReglaRecurrencia { get; set; } = "";
        public int? IdFrecuencia { get; set; }  // FK al catálogo
        // 🔥 CAMPOS REQUERIDOS POR LA API
        public int IdAgenda { get; set; }
        public int IdCreador { get; set; }
        public int IdResponsable { get; set; }
        public int Prioridad { get; set; }

    }
    public class Participante
    {
        public int Id { get; set; }
        public int IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; } = "";
    }

    public class SubtaskModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int ApiId { get; set; }
        public int IdAgenda { get; set; }
        public bool EsRecurrente { get; set; } = false;
        public string ReglaRecurrencia { get; set; } = "";
        public string Title { get; set; }
        public string Descripcion { get; set; }
        public bool IsDone { get; set; }
        public string Tipo { get; set; }
        public string Icon { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime FechaConclusion { get; set; } = DateTime.Now.Date;
        public DateTime? FechaSolicitud { get; set; }
        public TimeOnly? HoraInicio { get; set; }
        public TimeOnly? HoraFin { get; set; }
        public string Autor { get; set; }
        public string Cliente { get; set; }
        public string Objetivo { get; set; }
        public string ObjetivosOtros { get; set; }
        public int Prioridad { get; set; }
        public string Ubicacion { get; set; }
        public List<string> Participantes { get; set; } = new();
        public DateTime? FechaPendiente { get; set; } // 🔹 NUEVO
        public int ProgressPercent { get; set; }
        public bool EsEventoCompartido => Tipo == "Evento" && Participantes?.Count > 1;
        public int IdCreador { get; set; }
        public bool EsInvitado { get; set; }
        public bool EsEventoMio { get; set; }
        public string NombreCreador { get; set; } = "";
        public List<SubtaskModel> Subtasks { get; set; } = new();
        public DateTime? FechaCompletado { get; set; }

    }


    /* public class OrdenTrabajoModel
     {
         public int Id { get; set; }
         public int IdOrdenReal { get; set; }         // 🔥 ID REAL API
         public string NumeroOrden { get; set; }
         public DateTime? FechaSolicitud { get; set; }
         public DateTime FechaProgramada { get; set; }
         public string Autor { get; set; }
         public string Cliente { get; set; }
         public string Objetivo { get; set; }
         public string ObjetivoOtro { get; set; }
         public OrdenStatus Status { get; set; }
         public TipoOrden Tipo { get; set; }   // 🔥 NUEVO
         public List<TareaOrdenModel> Tareas { get; set; } = new();
     }*/
    public class OrdenTrabajoModel
    {
        public int Id { get; set; }              // UI / trabajo
        public int? IdOrdenTramite { get; set; }     // 🔥 ÓRDEN DE TRÁMITE
        public string NumeroOrden { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public DateTime FechaProgramada { get; set; }
        public string Autor { get; set; }
        public string Cliente { get; set; }
        public string Objetivo { get; set; }
        public string ObjetivoOtro { get; set; }
        public OrdenStatus Status { get; set; }
        public TipoOrden Tipo { get; set; }

        public List<TareaOrdenModel> Tareas { get; set; } = new();
    }


    public class TareaOrdenModel
    {
        public string Nombre { get; set; }
        public string DescripcionAutor { get; set; }
        public string DescripcionReceptor { get; set; }
        public string Valor { get; set; }
        public string Observacion { get; set; }
    }

    public enum OrdenStatus
    {
        Hoy,
        Proximo,
        Vencido
    }
    public enum TipoOrden
    {
        Trabajo,
        Tramite
    }



}
