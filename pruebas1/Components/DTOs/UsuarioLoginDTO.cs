using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    /*public class UsuarioLoginDTO
        {
            public int Idusuario { get; set; }
            public string Token { get; set; }
            public string nombreusuario { get; set; }
            public List<int> idAgendasAsignadas { get; set; }

        }*/
    public class UsuarioLoginDTO
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreRed { get; set; }   // 👈 AQUÍ VIENE EL NOMBRE
        public int IdEmpleado { get; set; }
        public List<int> IdAgendasAsignadas { get; set; }
        public string Token { get; set; }
    }



}
