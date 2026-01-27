using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    public class ClientesDTO
    {
        public int Id { get; set; }
        public string? Clave { get; set; }
        public string? RazonSocial { get; set; }
    }

    public class GrupoClientesDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public List<ClientesDTO> Clientes { get; set; } = new();
    }

}
