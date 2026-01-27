using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class ServicioConActividadesDTO
    {
        public int IdServicio { get; set; }
        public string Servicio { get; set; } = "";
        public string Area { get; set; } = "";
        public List<ActividadDTO> Actividades { get; set; } = new();
    }

    public class ActividadDTO
    {
        public int IdActividad { get; set; }
        public string Actividad { get; set; } = "";
    }

}
