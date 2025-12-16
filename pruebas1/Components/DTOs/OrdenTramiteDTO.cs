using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class OrdenTramiteDTO
    {
        public int idOrden { get; set; }
        public string numeroOrden { get; set; }
        public string fechaSolicitud { get; set; }
        public string solicitanteInterno { get; set; }
        public string cliente { get; set; }
        public string nombreGlobal { get; set; }
        public string fechaConclusionTramite { get; set; }
        public List<TramiteIndividualDTO> tramitesIndividuales { get; set; } = new();
    }

    public class TramiteIndividualDTO
    {
        public int idTramite { get; set; }
        public string clave { get; set; }
        public string personalEncargado { get; set; }
        public string dependencia { get; set; }
        public string tramiteIndividual { get; set; }
        public string observacion { get; set; }
        public string estadoTramite { get; set; }
        public string avance { get; set; }
        public List<TareaTramiteDTO> tareas { get; set; } = new();
    }

    public class TareaTramiteDTO
    {
        public int idTarea { get; set; }
        public string claveTarea { get; set; }
        public string tarea { get; set; }
        public string encargadoTarea { get; set; }
        public string fechaConclusion { get; set; }
        public string avance { get; set; }
    }

}
