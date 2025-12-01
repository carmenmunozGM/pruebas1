using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class TareaApiDto
    {
        public int id { get; set; }
        public int idAgenda { get; set; }
        public string titulo { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public bool esRecurrente { get; set; }
        public string? reglaRecurrencia { get; set; }
        public bool completada { get; set; }
        public DateTime? fechaCompletada { get; set; }
        public bool todoElDia { get; set; }
        public int idPrioridad { get; set; }
        public string? prioridadTitulo { get; set; }
        public int idBloque { get; set; }
        public bool esEvento { get; set; }

        public List<SubTareaApiDto> subTareas { get; set; } = new();
    }

    public class SubTareaApiDto
    {
        public int id { get; set; }
        public string titulo { get; set; } = string.Empty;
        public bool completada { get; set; }
        public DateTime? fechaCompletada { get; set; }
        public int orden { get; set; }
    }

}
