using System;

public class AppSettingsService
{
    // Propiedad con get y set para que no sea de "solo lectura"
    public string ViewMode { get; set; } = "horizontal";

    public event Action OnChange;

    // Este es el método que tu componente está gritando que no encuentra
    public void SetViewMode(string mode)
    {
        ViewMode = mode;
        NotifyStateChanged();
    }

    public void NotifyStateChanged() => OnChange?.Invoke();
}