using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pruebas1.Components.DTOs;
using System.Net.Http.Json;

namespace pruebas1.Servicios
{
    using System.Net.Http.Json;

    public class ServicioClienteService
    {
        private readonly HttpClient _http;

        public ServicioClienteService(HttpClient http)
        {
            _http = http;
        }

        public async Task<EmpresasAsignadasDTO> ObtenerMisEmpresas()
        {
            return await _http.GetFromJsonAsync<EmpresasAsignadasDTO>(
                "entidadAgenda/empresasAsignadas"
            ) ?? new EmpresasAsignadasDTO();
        }

        public async Task<ActividadesEmpresaDTO?> ObtenerActividadesEmpresa(int idUsuarioEntidadAgenda)
        {
            return await _http.GetFromJsonAsync<ActividadesEmpresaDTO>(
                $"entidadAgenda/actividades/{idUsuarioEntidadAgenda}"
            );
        }


    }


}
