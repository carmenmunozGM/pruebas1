using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Components.DTOs
{
    // DTO que viene del backend para mostrar en pantalla
    public class AutoevaluacionDTO
    {
        public string Bloque { get; set; } = "";
        public List<TareaAutoDTO> Tareas { get; set; } = new();
    }

    // archivo: pruebas1.Components.DTOs (añadir o modificar)

    public class RegistroGeneradoDTO
    {
        public int IdRegistro { get; set; }
        public DateOnly Fecha { get; set; }        // coincide con lo que envía el backend
        public bool Realizado { get; set; }
    }

    public class TareaAutoDTO
    {
        public int IdTareaAU { get; set; }
        public string Tarea { get; set; } = "";
        public string Periodicidad { get; set; } = "";
        public string Programado { get; set; } = "";

        // ✅ NUEVO: lista de registros (uno por fecha) tal como lo devuelve el backend
        public List<RegistroGeneradoDTO> Registros { get; set; } = new();

        // 👍 Helper: fecha real programada (primera fecha si existe)
        public DateOnly? FechaProgramadaReal =>
            Registros != null && Registros.Count > 0 ? Registros.First().Fecha : (DateOnly?)null;
    }



    // ================================
    // DTO QUE EL FRONTEND ENVÍA AL POST
    // ================================
    public class RegistroTareaDTO
    {
        public int IdTareaAU { get; set; }

        // EVENTUAL
        public List<DateOnly> Fechas { get; set; } = new();

        // SEMANAL (0 = Lunes)
        public int? DiaSemana { get; set; }

        // MENSUAL (1 - 31)
        public int? DiaMes { get; set; }
    }

    public class GuardarAutoevaluacionEmpleadoDTO
    {
        public int Mes { get; set; }
        public int Anio { get; set; }
        public List<RegistroTareaDTO> Tareas { get; set; } = new();
    }
}