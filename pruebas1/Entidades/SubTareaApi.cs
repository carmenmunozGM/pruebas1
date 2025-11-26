using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Entidades
{
    public class SubTareaApi
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public bool completada { get; set; }
        public DateTime? fechaCompletada { get; set; }
        public int orden { get; set; }
    }


}
