using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class AgendaAdminDTO
    {
        public int Id { get; set; }
        public string NombreAgenda { get; set; } = "";
        public bool Activa { get; set; }

        public int? IdEmpleadoActual { get; set; }
        public string? EmpleadoActual { get; set; }
        public string Puesto { get; set; } = "";
        public int ClavePuesto { get; set; }
    }
}
