namespace APIProyectoSPEC.DTOs
{
    public class TotalAutoevaluacionesDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public int TotalEvaluaciones { get; set; } 
        public decimal Cumplimiento { get; set; }
        public int ClavePuesto { get; set; }
    }
}
