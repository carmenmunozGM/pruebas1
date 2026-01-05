using pruebas1.Components.DTOs.pruebas1.Components.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class EmpresasAsignadasDTO
    {
        public List<GrupoClientesAsignadosDTO> Grupos { get; set; } = new();
        public List<ClienteAsignadoDTO> ClientesIndividuales { get; set; } = new();
    }
}
