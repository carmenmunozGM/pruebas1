window.flatpickrInit = (element, value, dotNetHelper) => {
    let fecha = null;

    if (value) {
        try {
            fecha = new Date(value);
            if (isNaN(fecha.getTime())) {
                fecha = null;
            }
        } catch {
            fecha = null;
        }
    }

    flatpickr(element, {
        dateFormat: "d/m/Y",
        defaultDate: fecha,
        locale: "es",
        allowInput: true,
        static: true, // <--- ESTO ES VITAL: Mantiene el calendario dentro de tu contenedor
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