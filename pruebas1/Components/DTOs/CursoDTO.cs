using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace pruebas1.Components.DTOs
{
    public class CursoDTO
    {
        public int Id { get; set; }
        public string EstadoCurso { get; set; }
        public string FechaInicio { get; set; }
        public string ClaveCurso { get; set; }
        public string TituloCurso { get; set; }
        public string Observaciones { get; set; }
        public string Modalidad { get; set; }
        public string Expositor { get; set; }
        public int NumeroParticipantes { get; set; }
        public int LugaresDisponibles { get; set; }
    }
}