using pruebas1.Components.DTOs;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

public class OrdenTramiteService
{
    private readonly HttpClient http;

    public OrdenTramiteService(HttpClient http)
    {
        this.http = http;
    }

    // 🔵 ORDEN DE TRÁMITE (DATOS GENERALES + TABLA)
    public async Task<OrdenTramiteDTO?> GetDetalle(int idOrden)
    {
        return await http.GetFromJsonAsync<OrdenTramiteDTO>(
            $"https://redgm.site:9096/ordenTramite/{idOrden}");
    }

    // 🟣 TRÁMITE INDIVIDUAL (DETALLE + TAREAS)
    public async Task<TramiteIndividualDTO?> GetTramiteDetalle(int idTramite)
    {
        return await http.GetFromJsonAsync<TramiteIndividualDTO>(
            $"https://redgm.site:9096/ordenTramite/tramite/{idTramite}");
    }
    public async Task<List<OrdenTramiteDTO>> GetVencidas()
        => await http.GetFromJsonAsync<List<OrdenTramiteDTO>>("https://redgm.site:9096/ordenTramite/vencidas");

    public async Task<List<OrdenTramiteDTO>> GetProximas()
        => await http.GetFromJsonAsync<List<OrdenTramiteDTO>>("https://redgm.site:9096/ordenTramite/proximas");

    public async Task<List<OrdenTramiteDTO>> GetHoy()
        => await http.GetFromJsonAsync<List<OrdenTramiteDTO>>("https://redgm.site:9096/ordenTramite/hoy");
}
