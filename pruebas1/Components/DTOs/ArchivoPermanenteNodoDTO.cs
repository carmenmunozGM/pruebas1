using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class ArchivoPermanenteNodoDTO
    {
        // Id en la base de datos
        public int? IdBD { get; set; }

        // Id del elemento en SharePoint
        public string IdSharePoint { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public bool EsCarpeta { get; set; }

        public string? Url { get; set; }

        public List<ArchivoPermanenteNodoDTO> Hijos { get; set; } = new();
    }
}
