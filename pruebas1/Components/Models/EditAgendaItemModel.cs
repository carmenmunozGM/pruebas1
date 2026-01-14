////public class EditAgendaItemModel
////{
////    public int Id { get; set; }
////    public int IdAgenda { get; set; }
////    public int ApiId { get; set; }
////    public string Tipo { get; set; } = ""; // "Tarea" | "Evento"

////    public string Titulo { get; set; } = "";
////    public string? Descripcion { get; set; }

////    // COMUNES
////    public DateTime FechaInicio { get; set; }
////    public DateTime FechaFin { get; set; }

////    // EVENTO
////    public TimeOnly? HoraInicio { get; set; }
////    public TimeOnly? HoraFin { get; set; }

////    public List<int> IdsParticipantes { get; set; } = new();

////    // 🔥 ESTAS SON LAS QUE FALTABAN
////    public int Prioridad { get; set; }
////    public string ReglaRecurrencia { get; set; } = "";
////    public string Ubicacion { get; set; } = "";
////    // RECURRENCIA
////    public bool EsRecurrente { get; set; }

////    // LISTAS
////    public List<string> Participantes { get; set; } = new();
////    public List<string> Subtareas { get; set; } = new();
////}
//public class EditAgendaItemModel
//{
//    public int ApiId { get; set; }
//    public int IdAgenda { get; set; }

//    public string Tipo { get; set; } = "";

//    public string Titulo { get; set; } = "";
//    public string Descripcion { get; set; } = "";

//    public DateTime FechaInicio { get; set; }
//    public DateTime FechaFin { get; set; }

//    public TimeOnly? HoraInicio { get; set; }
//    public TimeOnly? HoraFin { get; set; }

//    public int Prioridad { get; set; }

//    public string Ubicacion { get; set; } = "";

//    // 🔥 ESTA ES LA ÚNICA FORMA DE RECURRENCIA
//    public string ReglaRecurrencia { get; set; } = "";

//    // 🔥 SUBTAREAS CORRECTAS
//    public List<EditableSubtask> Subtareas { get; set; } = new();

//    // (Participantes lo veremos después)
//    public List<string> Participantes { get; set; } = new();
//}

//public class EditableSubtask
//{
//    public int Index { get; set; }
//    public string Titulo { get; set; } = "";
//}

using pruebas1.Components.DTOs;

public class EditAgendaItemModel
{
    public int ApiId { get; set; }
    public int IdAgenda { get; set; }
    public string Tipo { get; set; } = "Tarea";
    public string Titulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public bool EsRecurrente { get; set; }
    public DateTime FechaInicio { get; set; } = DateTime.Now;
    public DateTime FechaFin { get; set; } = DateTime.Now;
    // IMPORTANTE: Usa TimeOnly o TimeSpan para los inputs de hora
    public TimeOnly HoraInicio { get; set; } = new TimeOnly(9, 0);
    public TimeOnly HoraFin { get; set; } = new TimeOnly(10, 0);
    public int Prioridad { get; set; }
    public string Ubicacion { get; set; } = string.Empty;
    public string ReglaRecurrencia { get; set; } = string.Empty;
    public List<EmpleadoDTO> Participantes { get; set; } = new();
    public List<EditableSubtask> Subtareas { get; set; } = new();
}

public class EditableSubtask
{
    public int Index { get; set; }
    public string Titulo { get; set; } = string.Empty;
}