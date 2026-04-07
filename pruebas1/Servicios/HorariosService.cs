using pruebas1.Components.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Servicios
{
    public class HorariosService
    {
        private readonly HttpClient _http;

        public HorariosService(HttpClient http)
        {
            _http = http;
        }

        public async Task<HoraSistemaDTO> GetHorario()
        {
            var horaCliente = DateTime.Now.AddHours(1);

            var respuesta = await _http.GetFromJsonAsync<HoraSistemaDTO>(
                $"/Horarios?cliente={horaCliente:o}");

            return respuesta ?? new HoraSistemaDTO();
        }
    }
}
