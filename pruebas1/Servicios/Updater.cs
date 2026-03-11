using System.Diagnostics;
using Velopack;

namespace pruebas1.Servicios
{
    public class Updater
    {
        public static async Task<bool> CheckForUpdates()
        {
            try
            {
                var mgr = new UpdateManager("https://redgm.site:9096/AgendaGM");

                var update = await mgr.CheckForUpdatesAsync();

                if (update == null)
                    return false;

                await mgr.DownloadUpdatesAsync(update);

                mgr.ApplyUpdatesAndRestart(update);

                return true;
            }
            catch (Velopack.Exceptions.NotInstalledException)
            {
                return false;
            }
        }
    }
}