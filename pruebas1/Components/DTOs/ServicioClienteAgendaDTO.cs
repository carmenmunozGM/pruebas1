using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class ServicioClienteAgendaDTO
    {
        public int IdHorasProgramaTrabajo { get; set; }
        public string NombreServicio { get; set; }
        public string NombreActividad { get; set; }
        public string NombreEmpresa { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public DateTime FechaConclusion { get; set; }
    }

}
