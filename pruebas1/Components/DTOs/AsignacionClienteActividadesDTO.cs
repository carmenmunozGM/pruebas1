using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class AsignacionClienteActividadesDTO
    {
        public int IdAgenda { get; set; }
        public string TipoEntidad { get; set; } = "";
        public int IdEmpleado { get; set; }
        public List<int> ClientesIds { get; set; } = new();

        public List<ActividadCantidadDTO> Actividades { get; set; } = new();
    }

    public class ActividadCantidadDTO
    {
        public int IdActividad { get; set; }
        public int Cantidad { get; set; }
    }

}
