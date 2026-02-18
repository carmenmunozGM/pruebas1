using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class EliminarAsignacionDTO
    {
        public List<int> IdUsuarioEntidadAgenda { get; set; } = new();
        public int IdEmpleado { get; set; }
    }
}
