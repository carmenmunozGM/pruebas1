using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class AreaDTO
    {
        [JsonPropertyName("clave")]
        public int Clave { get; set; }
        [JsonPropertyName("area")]
        public string Area { get; set; }
        [JsonPropertyName("puestos")]
        public List<PuestoDTO> Puestos { get; set; }
    }
}
