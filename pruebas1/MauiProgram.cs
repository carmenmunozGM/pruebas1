using Microsoft.Extensions.Logging;
using pruebas1.Servicios;

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
                     builder.Services.AddScoped<ReglasRecurrenciaServices>();
                     builder.Services.AddScoped<LoginService>();
                     builder.Services.AddMauiBlazorWebView();
                builder.Services.AddScoped(sp =>
            {
                var http = new HttpClient
                {
                    BaseAddress = new Uri("https://redgm.site:9096/")
                };

                /*var credenciales = Encoding.ASCII.GetBytes("");
                http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("basic", Convert.ToBase64String(credenciales));*/

                return http;
            });

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
