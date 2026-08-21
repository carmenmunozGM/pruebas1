using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class HistorialMinutaDTO
    {
        public DateTime Fecha { get; set; }
        public string? Comentarios { get; set; }
        public List<HistorialActividadDTO> Actividades { get; set; } = new();
    }

    public class HistorialActividadDTO
    {
        public string? Cliente { get; set; }
        public string? Servicio { get; set; }
        public string? Actividad { get; set; }
        public string? Area { get; set; }
        public string Periodo { get; set; } = "";
        public string? Lugar { get; set; }
        public int HorasInvertidas { get; set; }
        public string? ObservacionIndividual { get; set; }
    }
}
