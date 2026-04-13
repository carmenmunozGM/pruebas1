using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class HoraSistemaDTO
    {
        public DateOnly Servidor { get; set; }
        public DateOnly Sistema { get; set; }
        public bool Desfase { get; set; }
    }
}
