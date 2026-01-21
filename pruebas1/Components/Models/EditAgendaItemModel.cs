
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
    public int? idSala { get; set; }
    public string ReglaRecurrencia { get; set; } = string.Empty;
    public List<EmpleadoDTO> Participantes { get; set; } = new();
    public List<EditableSubtask> Subtareas { get; set; } = new();
}

public class EditableSubtask
{
    public int? Id { get; set; } // Cambiar de Index a Id y que sea int?
    public string Titulo { get; set; } = "";
}