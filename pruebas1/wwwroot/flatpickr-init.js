// 👇 Función GLOBAL para cambiar theme
window.toggleFlatpickrTheme = (isDark) => {
    const light = document.getElementById("flatpickr-light");
    const dark = document.getElementById("flatpickr-dark");

    if (isDark) {
        light.disabled = true;
        dark.disabled = false;
    } else {
        light.disabled = false;
        dark.disabled = true;
    }
};


// 👇 Activar theme al cargar la app
document.addEventListener("DOMContentLoaded", function () {

    const isDark =
        document.documentElement.getAttribute("data-theme") === "dark";

    window.toggleFlatpickrTheme(isDark);
});

// 👇 Inicializador del DatePicker (SOLO esto)
window.flatpickrInit = (element, value, dotNetHelper) => {

    let fecha = null;
    if (value) {
        try {
            fecha = new Date(value);
            if (isNaN(fecha.getTime())) fecha = null;
        } catch { fecha = null; }
    }

    flatpickr(element, {
        dateFormat: "d/m/Y",
        defaultDate: fecha,
        locale: "es",
        allowInput: true,
        appendTo: document.body,
        position: "auto",

        onChange: function (selectedDates) {
            if (selectedDates.length > 0) {
                dotNetHelper.invokeMethodAsync(
                    "OnDateSelected",
                    selectedDates[0].toISOString()
                );
            }
        }
    });
};
