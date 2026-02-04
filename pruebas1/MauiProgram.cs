using Microsoft.Extensions.Logging;
using pruebas1.Servicios;
using System.Globalization;
using Blazored.LocalStorage;
namespace pruebas1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Cultura mexicana
            var cultura = new CultureInfo("es-MX");
            CultureInfo.DefaultThreadCurrentCulture = cultura;
            CultureInfo.DefaultThreadCurrentUICulture = cultura;

            // Servicios
            builder.Services.AddScoped<LoginService>();
            builder.Services.AddScoped<AgendaService>();
            builder.Services.AddScoped<ReglasRecurrenciaServices>();
            builder.Services.AddScoped<SalasEmService>();
            builder.Services.AddSingleton<UsuarioState>();
            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<AutoevaluacionService>();
            builder.Services.AddScoped<OrdenTrabajoService>();
            builder.Services.AddScoped<OrdenTramiteService>();
            builder.Services.AddScoped<CalendarioService>();
            builder.Services.AddScoped<ServicioClienteService>();
            builder.Services.AddScoped<AreasService>();
            builder.Services.AddScoped<VerAgendasService>();
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<AppSettingsService>();
            builder.Services.AddBlazoredLocalStorage();
            // HttpClient compartido
            builder.Services.AddScoped(sp =>
            {
                return new HttpClient
                {
               //BaseAddress = new Uri("https://redgm.site:9096/")
               BaseAddress = new Uri("http://localhost:5231/")
                };
            });

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
