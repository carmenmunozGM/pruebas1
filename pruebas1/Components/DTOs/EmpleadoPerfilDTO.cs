using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class EmpleadoPerfilDTO
    {
        public int Clave { get; set; }
        public string Nombre { get; set; } = null!;
        public string Area { get; set; } = null!;
        public string Puesto { get; set; } = null!;
        public string Perfil { get; set; } = null!;
    }
}
