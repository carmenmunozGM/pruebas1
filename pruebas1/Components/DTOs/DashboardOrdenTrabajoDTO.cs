using APIProyectoSPEC.DTOs;

namespace pruebas1.Components.DTOs
{
    public class DashboardOrdenTrabajoDTO
    {
        public int Total { get; set; }
        public int TotalTrabajo { get; set; }
        public int TotalTramite { get; set; }
        public int Vencidas { get; set; }
        public int Hoy { get; set; }
        public int Proximas { get; set; }
        public int PendientesAceptarTerminacion { get; set; }

        public List<OrdenTrabajoDTO> OrdenesTrabajo { get; set; } = new();
        public List<OrdenTramiteDashboardDTO> OrdenesTramite { get; set; } = new();

        // Nuevas listas estructuradas para las gráficas y tablas del front
        public List<GraficaRangosAtrasoDTO> GraficaRangosAtraso { get; set; } = new();
        public List<GraficaHistoricoMensualDTO> GraficaHistoricoMensual { get; set; } = new();
        public List<TablaComparacionAreaDTO> TablaComparacionAreas { get; set; } = new();
        public List<TablaEmpleadoDTO> TablaEmpleados { get; set; } = new();
        public List<OrdenTrabajoEmpleadoResumenDTO> EmpleadosResumen { get; set; } = new();
    }

    public class GraficaRangosAtrasoDTO
    {
        public string Rango { get; set; } = string.Empty; // Ej. "1-6 días", "7-11 días", etc.
        public int CantidadOrdenes { get; set; }
    }

    public class GraficaHistoricoMensualDTO
    {
        public int MesNumero { get; set; }
        public string NombreMes { get; set; } = string.Empty; // Enero a Diciembre
        public int CantidadVencidas { get; set; }
    }

    public class TablaComparacionAreaDTO
    {
        public string Area { get; set; } = string.Empty; // Asesoria Contable, Auditoria, etc.
        public int Vencidas { get; set; }
        public int Proximas { get; set; }
        public int Hoy { get; set; }
        public int PendientesAceptar { get; set; }
    }

    public class TablaEmpleadoDTO
    {
        public string Empleado { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public int OrdenesVencidas { get; set; }
        public int DiasHabilesAtrasoTotal { get; set; } // Suma total de días hábiles de sus órdenes vencidas
    }
}