// Colócalo en una carpeta llamada 'Models' (por ejemplo)

namespace pruebas1.Models // <-- AJUSTA ESTE NAMESPACE
{
    public class EventoModel
    {
        public string Title { get; set; } = string.Empty;
    }

    public class TareaModel
    {
        public string TaskName { get; set; } = string.Empty;
        public List<string> Subtasks { get; set; } = new();
    }

    public class AdministrativaModel
    {
        public string ReportName { get; set; } = string.Empty;
    }
}