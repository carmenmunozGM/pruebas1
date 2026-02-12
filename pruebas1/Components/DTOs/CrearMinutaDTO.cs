using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class CrearMinutaDTO
    {
        public DateTime Fecha { get; set; }
        public string? Comentarios { get; set; }
        public List<CrearActividadMinutaDTO> Actividades { get; set; }
    }
    public class CrearActividadMinutaDTO
    {
        public int ClaveCliente { get; set; }
        public int IdActividad { get; set; }
        public string Periodo { get; set; }
        public int HorasInvertidas { get; set; }
    }

}
