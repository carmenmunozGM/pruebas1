using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class VacacionesDTO
    {
        public string NumeroPersonal { get; set; } = string.Empty;
        public string Personal { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string Movimiento { get; set; } = "VACACIONES";
        public string Desde { get; set; } = string.Empty;
        public string Hasta { get; set; } = string.Empty;
    }
}
