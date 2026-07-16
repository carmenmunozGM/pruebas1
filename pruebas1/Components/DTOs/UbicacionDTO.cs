using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class UbicacionDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = "";
        public string Nombre { get; set; } = "";
        public int? IdPadre { get; set; }

        public int Nivel { get; set; }

        public bool EsDinamica { get; set; }

        public bool PermiteArchivos { get; set; }
        public string IdSharePoint { get; set; } = "";
        public List<UbicacionDTO> Hijos { get; set; } = new();
    }
}
