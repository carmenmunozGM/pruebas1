using System.Text.Json.Serialization;

namespace pruebas1.Components.DTOs
{
    public class TareaDuracionDTO
    {
        public int Id { get; set; }
        public string Area { get; set; } = string.Empty;

        [JsonPropertyName("diasRecorridos")]
        public int DiasRecorridos { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [JsonPropertyName("totalTareas")]
        public int TotalTareas { get; set; }

        public bool Completada { get; set; }

        [JsonPropertyName("empleadoId")]
        public int EmpleadoId { get; set; }

        [JsonPropertyName("empleadoNombre")]
        public string EmpleadoNombre { get; set; } = string.Empty;

        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime? FechaCompletada { get; set; }
    }
}