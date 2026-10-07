
using System;
using System.Collections.Generic;

namespace pruebas1.Components.DTOs
{
    public class AdopcionAgendaDTO
    {
        public int TotalEmpleados { get; set; }
        public int EmpleadosConActividad { get; set; }
        public int EmpleadosSinActividad { get; set; }
        public double PorcentajeAdopcion { get; set; }
        public int AccesosRegistrados { get; set; }

        public List<AdopcionEmpleadoDTO> Empleados { get; set; } = new();
        public List<AdopcionAreaDTO> Areas { get; set; } = new();
        public List<AdopcionMesDTO> TendenciaMensual { get; set; } = new();
    }

    public class AdopcionEmpleadoDTO
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; } = "";
        public string Area { get; set; } = "";
        public int AccesosRegistrados { get; set; }
        public DateTime? UltimoAcceso { get; set; }
        public bool TieneActividad { get; set; }
    }

    public class AdopcionAreaDTO
    {
        public string Area { get; set; } = "";
        public int TotalEmpleados { get; set; }
        public int EmpleadosConActividad { get; set; }
        public double PorcentajeAdopcion { get; set; }
    }

    public class AdopcionMesDTO
    {
        public int Anio { get; set; }
        public int Mes { get; set; }
        public string NombreMes { get; set; } = "";
        public int EmpleadosConActividad { get; set; }
        public int TotalEmpleados { get; set; }
        public double PorcentajeAdopcion { get; set; }
        public int AccesosRegistrados { get; set; }
    }
}