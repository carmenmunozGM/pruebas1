using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class ArchivoPermanenteCrearDTO
    {
        public string IdCarpetaPadre { get; set; } = null!;
        public string? NombreCarpeta { get; set; }
        public IList<IBrowserFile> Archivos { get; set; } = new List<IBrowserFile>();
    }
}
