public class EditAgendaItemModel
{
    public int Id { get; set; }
    public int IdAgenda { get; set; }
    public int ApiId { get; set; }
    public string Tipo { get; set; } = ""; // "Tarea" | "Evento"

    public string Titulo { get; set; } = "";
    public string? Descripcion { get; set; }

    // COMUNES
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }

    // EVENTO
    public TimeOnly? HoraInicio { get; set; }
    public TimeOnly? HoraFin { get; set; }
    
    public List<int> IdsParticipantes { get; set; } = new();

    // 🔥 ESTAS SON LAS QUE FALTABAN
    public int Prioridad { get; set; }
    public string ReglaRecurrencia { get; set; } = "";
    public string Ubicacion { get; set; } = "";
    // RECURRENCIA
    public bool EsRecurrente { get; set; }
 
    // LISTAS
    public List<string> Participantes { get; set; } = new();
    public List<string> Subtareas { get; set; } = new();
}
