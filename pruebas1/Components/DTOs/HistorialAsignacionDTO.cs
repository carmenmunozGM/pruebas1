using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class HistorialAsignacionDTO
    {
        public int IdEmpleado { get; set; }

        public List<int> IdUsuarioEntidadAgenda { get; set; } = new();

        public List<int> EntidadesExternasIds { get; set; } = new();
        public List<int> ActividadesIds { get; set; } = new();
        public string Empleado { get; set; } = "";
        public string Entidad { get; set; } = "";
        public string TipoEntidad { get; set; } = "";
        public List<ServicioTextoDTO> Servicios { get; set; } = new();
        public string AsignadoPor { get; set; } = "";
        public DateTime FechaAsignacion { get; set; }
        public int? IdArea { get; set; }
        public int IdEntidadAgenda { get; set; }
    }

    public class ServicioTextoDTO
    {
        public string Servicio { get; set; } = "";

        public string? TextoServicio { get; set; }
    }



}
