using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class ArchivoPermanenteCrearFrontDTO
    {
        public string IdCarpetaPadre { get; set; } = "";
        public string? NombreCarpeta { get; set; }
        public List<IBrowserFile> Archivos { get; set; } = new();
    }
}
