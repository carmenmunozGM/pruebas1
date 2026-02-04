using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Servicios
{
    public class ThemeService
    {
        public string CurrentTheme { get; private set; } = "light";
        public event Action? OnChange;

        public void SetTheme(string theme)
        {
            CurrentTheme = theme;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
