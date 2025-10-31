using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Entidades
{
    public class PlantillaReglaRecurrencia
    {
        public int? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Frecuencia { get; set; } = null!;
        public int? Intervalo { get; set; } = 1;
        public List<string>? DiasSemana { get; set; }
        public int? DiaDelMes { get; set; }
        public int? Repeticiones { get; set; }


    }
}
