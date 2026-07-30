using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class CrearCarpetaDTO
    {
        public string Nombre { get; set; } = null!;
        public string? IdCarpetaPadre { get; set; }
    }
}
