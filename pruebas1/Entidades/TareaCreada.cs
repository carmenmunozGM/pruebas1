using pruebas1.Components;
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
        public string Participantes { get; set; }



        // 🔥 CAMPOS REQUERIDOS POR LA API
        public int IdAgenda { get; set; }
        public int IdCreador { get; set; }
        public int IdResponsable { get; set; }
    }
    public class SubtaskModel
    {
        // Identificador (opcional)
        public string Id { get; set; } = Guid.NewGuid().ToString();

        // Campos que usa tu UI (español)
        public string Title { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool IsDone { get; set; } = false;
        public string Estado { get; set; } = string.Empty;   // autoevaluación
        public string Tipo { get; set; } = string.Empty;     // "Evento" o "Tarea"
        public List<SubtaskModel> Subtasks { get; set; } = new();
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public TimeOnly? HoraInicio { get; set; }
        public TimeOnly? HoraFin { get; set; }
        // Campos de fechas y metadatos (opcionales)
        public DateTime FechaConclusion { get; set; } = DateTime.Now.Date;
        public DateTime? FechaSolicitud { get; set; } = null;
        public string Ubicacion { get; set; } = string.Empty;
        //public string Participantes { get; set; } = string.Empty;
        public string Participantes { get; set; }


        public string Autor { get; set; } = string.Empty;
        public string Cliente { get; set; } = string.Empty;
        public string Objetivo { get; set; } = string.Empty;
        public string ObjetivosOtros { get; set; } = string.Empty;

        // Campos en inglés que también usabas en otros lugares (compatibilidad)
        public string Description { get => Descripcion; set => Descripcion = value; }
        public int ProgressPercent { get; set; } = 0;
    }
    public class OrdenTrabajoModel
    {
        public string NumeroOrden { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaProgramada { get; set; }
        public string Autor { get; set; }
        public string Cliente { get; set; }
        public string Objetivo { get; set; }
        public string OtrosObjetivos { get; set; }
        public OrdenStatus Status { get; set; } = OrdenStatus.Normal;
        public List<TareaOrdenModel> Tareas { get; set; } = new();
    }

    public class TareaOrdenModel
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Avance { get; set; } // %
    }

    public enum OrdenStatus
    {
        Normal,
        ProximaVencer,
        Vencida
    }

}
