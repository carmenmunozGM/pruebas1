using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class OrdenTrabajoDTO
    {
        public int id { get; set; }
        public string strClave { get; set; }
        public DateTime dteFechaSolicitud { get; set; }
        public string nombreCompleto { get; set; }
        public string strValor { get; set; }
        public string strObjetivoOtro { get; set; }
        public DateTime fechaFinal { get; set; }
        public string estado { get; set; }
        public List<TareaDTO> tareas { get; set; } = new();
    }

    public class TareaDTO
    {
        public string strNombreTarea { get; set; }
        public string strDescripcionAutor { get; set; }
        public string strValor { get; set; }
        public string strObservacion { get; set; }
        public string strDescripcionReceptor { get; set; }
    }

}
