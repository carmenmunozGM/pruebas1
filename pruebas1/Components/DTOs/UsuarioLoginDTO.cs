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
        public string NombreUsuario { get; set; } = string.Empty;
        public List<int> IdAgendasAsignadas { get; set; } = new();
        public string Token { get; set; }
    }

}
