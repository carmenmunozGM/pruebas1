using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class VacacionesDTO
    {
        [JsonPropertyName("numeroPersonal")]
        public string NumeroPersonal { get; set; } = "";

        [JsonPropertyName("personal")]
        public string Personal { get; set; } = "";

        [JsonPropertyName("area")]
        public string Area { get; set; } = "";

        [JsonPropertyName("desde")]
        public string Desde { get; set; } = "";

        [JsonPropertyName("hasta")]
        public string Hasta { get; set; } = "";

        [JsonPropertyName("movimiento")]
        public string Movimiento { get; set; } = "VACACIONES";
    }
}
