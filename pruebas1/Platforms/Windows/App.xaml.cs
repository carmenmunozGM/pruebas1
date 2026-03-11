using Microsoft.UI.Xaml;
using pruebas1.Servicios;
using Velopack;

namespace pruebas1.WinUI
{
    public partial class App : MauiWinUIApplication
    {
        public App()
        {
            VelopackApp.Build().Run();
            this.InitializeComponent();
        }

        protected override MauiApp CreateMauiApp()
        {
            var app = MauiProgram.CreateMauiApp();

            _ = Task.Run(async () =>
            {
                await Task.Delay(5000); // deja que la app arranque
                await Updater.CheckForUpdates();
            });

            return app;
        }
    }
}