using pruebas1.Components.DTOs.pruebas1.Components.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class GrupoClientesAsignadosDTO
    {
        public int IdGrupo { get; set; }
        public string NombreGrupo { get; set; } = string.Empty;
        public List<ClienteAsignadoDTO> Clientes { get; set; } = new();
    }
}
