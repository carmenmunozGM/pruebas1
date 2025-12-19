using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Entidades
{
    public class ViewAgendaItem
    {
        public string Tipo { get; set; }
        public string Title { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public TimeOnly? HoraInicio { get; set; }
        public TimeOnly? HoraFin { get; set; }
        public string Ubicacion { get; set; }
        public int Prioridad { get; set; }
        public bool EsRecurrente { get; set; }  // ✔️ aquí
        public string ReglaRecurrencia { get; set; } = ""; // ✔️ aquí
        public List<SubtaskModel> Subtasks { get; set; } = new();
        public List<string> Participantes { get; set; } = new();
    }



}
