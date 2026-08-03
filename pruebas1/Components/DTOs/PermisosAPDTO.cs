using Microsoft.Maui.Controls.PlatformConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    // DTO para la respuesta del GET
    public class PermisosArchivoDTO
    {
        public bool Cargar { get; set; }
        public bool Visualizar { get; set; }
        public bool Descargar { get; set; }
    }

    // DTO para recibir los datos en el PUT/POST
    public class UpsertPermisosDTO
    {
        public string ClavePuesto { get; set; } = null!;
        public bool Cargar { get; set; }
        public bool Visualizar { get; set; }
        public bool Descargar { get; set; }
    }

    public class PermisosGeneralesDTO
    {
        public string ClavePuesto { get; set; } = null!;
        public string Puesto { get; set; } = string.Empty;
        public bool Cargar { get; set; }
        public bool Visualizar { get; set; }
        public bool Descargar { get; set; }
    }
}