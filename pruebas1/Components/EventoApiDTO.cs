using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components
{
    public class EventoApi
    {
        public int id { get; set; }
        public int idAgenda { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public bool completada { get; set; }
        public DateTime? fechaCompletada { get; set; }
        public bool todoElDia { get; set; }
        public int idPrioridad { get; set; }
        public string prioridad { get; set; }
        public int idSala { get; set; }
        public string ubicacion { get; set; }
        public List<ParticipanteEvento> participantes { get; set; }
    }

    public class ParticipanteEvento
    {
        public int id { get; set; }
        public int idEmpleado { get; set; }
        public string nombreEmpleado { get; set; }
    }

}
