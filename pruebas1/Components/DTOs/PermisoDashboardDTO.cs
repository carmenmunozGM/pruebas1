namespace pruebas1.Components.DTOs
{
    public class PermisoDashboardDTO
    {
        public string ClavePuesto { get; set; } = string.Empty;
        public string Puesto { get; set; } = string.Empty;
        public bool VisualizarDashboard { get; set; }
    }

    public class UpsertPermisoDashboardDTO
    {
        public string ClavePuesto { get; set; } = string.Empty;
        public bool VisualizarDashboard { get; set; }
    }
}