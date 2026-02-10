using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class ReasignarAgendaRequestDTO
    {
        public int ClavePersonal { get; set; }
        public int ClavePuesto { get; set; }
        public int AgendaId { get; set; }
        public int RealizadoPor { get; set; }
    }
}
