using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class AutoevaluacionDTO
    {
        public string Bloque { get; set; } = "";
        public List<TareaAutoDTO> Tareas { get; set; } = new();
    }

    public class TareaAutoDTO
    {
        public string Tarea { get; set; } = "";
        public string Periodicidad { get; set; } = "";
    }

}
