using System.Text.Json.Serialization;

namespace AgendaFront.DTOs
{
    public class ArchivoInstitucionalNodoDTO
    {
        [JsonPropertyName("idBD")]
        public int? IdBD { get; set; }

        [JsonPropertyName("idSharePoint")]
        public string? IdSharePoint { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("esCarpeta")]
        public bool EsCarpeta { get; set; }

        [JsonPropertyName("tipoUbicacion")]
        public string? TipoUbicacion { get; set; }

        [JsonPropertyName("hijos")]
        public List<ArchivoInstitucionalNodoDTO> Hijos { get; set; } = new();

        [JsonIgnore]
        public bool IsExpanded { get; set; }
    }
}