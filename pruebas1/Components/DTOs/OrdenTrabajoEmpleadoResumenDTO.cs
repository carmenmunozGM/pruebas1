namespace APIProyectoSPEC.DTOs
{
    public class OrdenTrabajoEmpleadoResumenDTO
    {
        public int IdPerPersonal { get; set; }
        public string Empleado { get; set; } = "";
        public string NombreEmpleado { get; set; } = "";
        public string Area { get; set; } = "";
        public int OrdenesVencidas { get; set; }
        public int DiasHabilesAtrasoTotal { get; set; }
    }
}