namespace pruebas1.Components.DTOs
{
    public class OrdenTramiteDashboardDTO
    {
        public int Id { get; set; } // Ajustado para coincidir con el backend
        public string TipoOrden { get; set; } = "Trámite";
        public string NumeroOrden { get; set; } = string.Empty;

        public DateTime? FechaSolicitud { get; set; }
        public DateTime? FechaFinal { get; set; } // O FechaConclusion si prefieres renombrarlo

        public string Solicitante { get; set; } = string.Empty;
        public string Cliente { get; set; } = string.Empty;
        public string AreaNombre { get; set; } = "Sin área asignada";

        public int? IdPerPersonalResponsable { get; set; }
        public string? NumeroPersonalResponsable { get; set; }
        public string NombreResponsable { get; set; } = string.Empty;

        public string Estado { get; set; } = "";
        public int DiasHabilesAtraso { get; set; }
    }
}