using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class OrdenTrabajoDTO
    {
        public int id { get; set; }
        public string cliente { get; set; }
        public string descripcion { get; set; }
        public string prioridad { get; set; }       // Alta / Media / Baja
        public string fecha { get; set; }           // "2025-11-02T00:00:00"
        public string responsable { get; set; }
    }
}
