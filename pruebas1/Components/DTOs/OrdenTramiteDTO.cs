using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class OrdenTramiteDTO
    {
        [JsonPropertyName("idOrden")]
        public int idOrden { get; set; }
        [JsonPropertyName("numeroOrden")]
        public string numeroOrden { get; set; }
        [JsonPropertyName("fechaSolicitud")]
        public string fechaSolicitud { get; set; }
        [JsonPropertyName("solicitanteInterno")]
        public string solicitanteInterno { get; set; }
        [JsonPropertyName("cliente")]
        public string cliente { get; set; }
        [JsonPropertyName("nombreGlobal")]
        public string nombreGlobal { get; set; }

        [JsonPropertyName("fechaConclusionTramite")]
        public string fechaConclusionTramite { get; set; }
        [JsonPropertyName("tramitesIndividuales")]
        public List<TramiteIndividualDTO> tramitesIndividuales { get; set; } = new();
    }

    public class TramiteIndividualDTO
    {
        [JsonPropertyName("idTramite")]
        public int idTramite { get; set; }
        [JsonPropertyName("clave")]
        public string clave { get; set; }
        [JsonPropertyName("personalEncargado")]
        public string personalEncargado { get; set; }
        [JsonPropertyName("dependencia")]
        public string dependencia { get; set; }
        [JsonPropertyName("tramiteIndividual")]
        public string tramiteIndividual { get; set; }
        [JsonPropertyName("observacion")]
        public string observacion { get; set; }
        [JsonPropertyName("estadoTramite")]
        public string estadoTramite { get; set; }
        [JsonPropertyName("avance")]
        public string avance { get; set; }
        [JsonPropertyName("tareas")]
        public List<TareaTramiteDTO> tareas { get; set; } = new();
    }

    public class TareaTramiteDTO
    {
        [JsonPropertyName("idTarea")]
        public int idTarea { get; set; }
        [JsonPropertyName("claveTarea")]
        public string claveTarea { get; set; }
        [JsonPropertyName("tarea")]
        public string tarea { get; set; }
        [JsonPropertyName("encargadoTarea")]
        public string encargadoTarea { get; set; }
        [JsonPropertyName("fechaConclusion")]
        public string fechaConclusion { get; set; }
        [JsonPropertyName("avance")]
        public string avance { get; set; }
    }

}