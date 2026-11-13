
namespace APIProyectoSPEC.DTOs
{
    public class DashboardVencidasEmpleadoDTO
    {
        public int IdPerPersonal { get; set; }

        public string NumeroPersonal { get; set; } = "";

        public string NombreCompleto { get; set; } = "";

        public string AreaNombre { get; set; } = "";

        public int TotalOrdenesVencidas { get; set; }

        public int TotalDiasHabilesAtraso { get; set; }
    }
}
