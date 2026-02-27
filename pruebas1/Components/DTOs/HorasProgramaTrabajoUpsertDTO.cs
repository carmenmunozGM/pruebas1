using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class HorasProgramaTrabajoUpsertDTO
    {
        public int IdAsignacion { get; set; }
        public DateTime Fecha { get; set; }
        public int HorasProgramadas { get; set; }
    }

    public class ObservacionesDTO   
    {
        public string? Observaciones { get; set; }
    }
}

