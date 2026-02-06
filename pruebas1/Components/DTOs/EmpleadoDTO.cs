using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class EmpleadoDTO
    {
        public int Id { get; set; }
        public int ClavePersonal { get; set; }
        public string Nombre { get; set; }
        public string NombreRed { get; set; }
        public string Area { get; set; }
        public string Puesto { get; set; }

        public int ActividadesPendientes { get; set; }

        [JsonPropertyName("autoevaluacionPendiente")]
        public int AutoevaluacionesPendientes { get; set; }
    }
}
