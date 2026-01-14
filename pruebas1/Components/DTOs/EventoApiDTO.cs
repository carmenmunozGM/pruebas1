using pruebas1.Components.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components
{
    public class EventoApiDTO
    {
        public int id { get; set; }
        public int idAgenda { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }

        public bool completada { get; set; } 

        public bool esRecurrente { get; set; }
        public string reglaRecurrencia { get; set; }
        public int idPrioridad { get; set; }
        public int? idSala { get; set; }
        public string? ubicacion { get; set; }
        public List<ParticipanteDTO> participantes { get; set; } = new();

        public int creadorId { get; set; }
        public string nombreCreador { get; set; } = "";

    }

}