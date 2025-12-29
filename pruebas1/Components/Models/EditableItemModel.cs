public class EditableItemModel
{
    public int Id { get; set; }
    public int IdAgenda { get; set; }

    public string Titulo { get; set; } = string.Empty;
    public string? Descripcion { get; set; }

    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }

    // TAREA
    public int? IdPrioridad { get; set; }

    // EVENTO
    public string? Ubicacion { get; set; }
    public List<int> IdsParticipantes { get; set; } = new();

    // RECURRENCIA
    public bool EsRecurrente { get; set; }
    public string? ReglaRecurrencia { get; set; }

    // SUBTAREAS
    public List<string> SubTareas { get; set; } = new();
}
