using System.Net.Http.Json;
using pruebas1.Components.DTOs;

public class DashboardOrdenesService
{
    private readonly HttpClient _http;

    public DashboardOrdenesService(HttpClient http)
    {
        _http = http;
    }

    public async Task<DashboardOrdenTrabajoDTO?> ObtenerDashboardAsync(
        int? anio, int? mesInicio, int? mesFin, string? claveArea, string? numeroPersonal)
    {
        var query = $"?anio={anio ?? 2026}";
        if (mesInicio.HasValue) query += $"&mesInicio={mesInicio.Value}";
        if (mesFin.HasValue) query += $"&mesFin={mesFin.Value}";
        if (!string.IsNullOrEmpty(claveArea)) query += $"&claveArea={claveArea}";
        if (!string.IsNullOrEmpty(numeroPersonal)) query += $"&numeroPersonal={numeroPersonal}";

        return await _http.GetFromJsonAsync<DashboardOrdenTrabajoDTO>($"/ordenesdetrabajo/ordenTrabajo/dashboard{query}");
    }
}