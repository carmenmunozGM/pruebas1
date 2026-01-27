using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class PuestoDTO
    {
        [JsonPropertyName("clave")]
        public int Clave { get; set; }
        [JsonPropertyName("puesto")]
        public string Puesto { get; set; }
    }
}
