using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Debe ingresar el nombre usuario")]
        public string nombreusuario { get; set; }

        [Required(ErrorMessage = "Debe ingresar la contraseña")]
        public string contraseña { get; set; }
    }
}
