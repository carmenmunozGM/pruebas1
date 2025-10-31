using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using pruebas1.Entidades;

namespace pruebas1.Servicios
{
    public class SalasEm
    {
        private readonly HttpClient httpClient;

        public SalasEm(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<SalasEm>> GetFrecuencia()
        {
            var f = await httpClient.GetFromJsonAsync<List<SalasEm>>("salas");
            return f ?? new List<SalasEm>();
        }

    }

}
