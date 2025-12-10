using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pruebas1.Entidades
{
    public class SalasEm
    {
        [JsonPropertyName("clave")]
        public int Id { get; set; }

        [JsonPropertyName("salas")]
        public string Salas { get; set; } = null!;

    }
}
