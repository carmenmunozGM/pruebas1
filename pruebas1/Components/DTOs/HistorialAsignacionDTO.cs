using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class HistorialAsignacionDTO
    {
        public int IdEmpleado { get; set; }

        public List<int> IdUsuarioEntidadAgenda { get; set; } = new();

        public List<int> EntidadesExternasIds { get; set; } = new();

        public string Empleado { get; set; } = "";
        public string Entidad { get; set; } = "";
        public string TipoEntidad { get; set; } = "";
        public string Servicios { get; set; } = "";
        public int TotalActividades { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }




}
