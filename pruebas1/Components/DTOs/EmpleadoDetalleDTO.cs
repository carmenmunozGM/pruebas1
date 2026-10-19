namespace pruebas1.Components.DTOs
{
    public class EmpleadoDetalleDTO
    {
        public int EmpleadoId { get; set; }
        public string ClavePersonal { get; set; } = string.Empty;
        public string NombreEmpleado { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public int Registradas { get; set; }
        public int EnFecha { get; set; }
        public int Pendientes { get; set; }
        public int Vencidas { get; set; }
        public decimal Cumplimiento { get; set; }
    }
}