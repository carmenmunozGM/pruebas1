using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Entidades
{
    public class EventoApi    {
        public int id { get; set; }
        public int idAgenda { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public bool todoElDia { get; set; }
        public string ubicacion { get; set; }
        public bool completada { get; set; }
        // Si tu API devuelve más campos, agrégalos aquí
    }
}
