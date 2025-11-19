using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public UsuarioLoginDTO Usuario { get; set; }
    }

}
