using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class HistorialItemDTO
    {
        public DateTime FechaMovimiento { get; set; }
        public DateTime FechaAnterior { get; set; }
        public DateTime FechaNueva { get; set; }
        public string Motivo { get; set; } = string.Empty;
    }

    public class HistorialFechaCreateDTO
    {
        public int IdHorasProgramaTrabajo { get; set; }
        public DateTime FechaNueva { get; set; }
        public string Motivo { get; set; } = string.Empty;
    }
}