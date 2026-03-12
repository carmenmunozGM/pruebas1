using System;
using System.IO;
using System.Runtime.InteropServices;

namespace pruebas1.Servicios
{
    public class StartupService
    {
        public void RegisterStartup()
        {
#if WINDOWS

            string startupFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

            string shortcutPath = Path.Combine(startupFolder, "Agenda GM.lnk");

            if (File.Exists(shortcutPath))
                return;

            // carpeta donde corre la app
            string baseDir = AppContext.BaseDirectory;

            // subir un nivel para encontrar Update.exe
            string updateExe = Path.GetFullPath(Path.Combine(baseDir, @"..\Update.exe"));

            string arguments = "--processStart pruebas1.exe";

            Type shellType = Type.GetTypeFromProgID("WScript.Shell");
            dynamic shell = Activator.CreateInstance(shellType);

            dynamic shortcut = shell.CreateShortcut(shortcutPath);

            shortcut.TargetPath = updateExe;
            shortcut.Arguments = arguments;
            shortcut.WorkingDirectory = Path.GetDirectoryName(updateExe);
            shortcut.Description = "Agenda GM";

            shortcut.Save();

#endif
        }
    }
}