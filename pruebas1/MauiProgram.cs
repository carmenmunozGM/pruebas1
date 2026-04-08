using Microsoft.Extensions.Logging;
using pruebas1.Servicios;
using System.Globalization;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Maui.Handlers;
using Microsoft.Web.WebView2.Core;
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
            builder.Services.AddScoped<AdministrarAgendasService>();
            builder.Services.AddScoped<PerfilesService>();
            builder.Services.AddScoped<EmpleadosService>();
            builder.Services.AddScoped<HorariosService>();
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<AppSettingsService>();
            builder.Services.AddScoped<ThemeService>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<InfoPersonalService>();
            builder.Services.AddScoped<Updater>();
            builder.Services.AddScoped<StartupService>();
            // HttpClient compartido
            builder.Services.AddScoped(sp =>
            {
                return new HttpClient
                {
                //BaseAddress = new Uri("https://redgm.site:9096/") //SERVIDOR PRODUCCION
                //BaseAddress = new Uri("http://localhost:5231/")     //LOCAL
                BaseAddress = new Uri("http://redgm.site:9097/")  //SERVIDOR PRUEBAS
                };
            });

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var startup = scope.ServiceProvider.GetRequiredService<StartupService>();
                startup.RegisterStartup();
            }

            return app;
        }
    }
}
