using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class ActividadAsignadaDTO
    {
        public int IdCheckListAsignacion { get; set; }
        public int IdActividadGeneral { get; set; }
        public int IdHorasProgramaTrabajo { get; set; }
        public string NombreActividad { get; set; } = string.Empty;
        public DateTime? Fecha { get; set; }
        public int HorasProgramadas { get; set; }
        public string? Observaciones { get; set; }
    }
    public class ServicioActividadesDTO
    {
        public string NombreServicio { get; set; } = string.Empty;
        public List<ActividadAsignadaDTO> Actividades { get; set; } = new();
    }
    public class ActividadesEmpresaDTO
    {
        public string NombreEmpresa { get; set; } = string.Empty;
        public List<ServicioActividadesDTO> Servicios { get; set; } = new();
    }

}
