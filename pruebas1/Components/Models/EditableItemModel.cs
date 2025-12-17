public class EditableItemModel
{
    public int Id { get; set; }
    public int IdAgenda { get; set; }

    public bool EsEvento { get; set; }

    public string Titulo { get; set; } = "";
    public string Descripcion { get; set; } = "";

    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }

    public TimeOnly? HoraInicio { get; set; }
    public TimeOnly? HoraFin { get; set; }

    public bool EsRecurrente { get; set; }
    public string ReglaRecurrencia { get; set; } = "";
    public int? IdFrecuencia { get; set; }

    public int IdPrioridad { get; set; }

    // EVENTO
    public int IdSala { get; set; }
    public string Ubicacion { get; set; } = "";
    public List<int> IdsParticipantes { get; set; } = new();

    // TAREA
    public List<string> SubTareas { get; set; } = new();
}
