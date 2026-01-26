using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class DiaNoLaboralDto
    {
        public int Id { get; set; }
        public DateTime DiaInhabil { get; set; }
        public string? Descripcion { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }

    }
}
