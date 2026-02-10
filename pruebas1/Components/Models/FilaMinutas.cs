public class FilaMinuta
{
    public string Cliente { get; set; }
    public string Actividad { get; set; }
    public string Periodo { get; set; }

    public TimeOnly? Horas { get; set; }   // 👈 CAMBIO CLAVE

    public bool CapAux { get; set; }
}
