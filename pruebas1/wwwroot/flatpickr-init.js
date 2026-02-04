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
        // CAMBIOS AQUÍ:
        static: false,          // Ya no se queda encerrado en el div
        monthSelectorType: "static",
        appendTo: element.parentNode, // Lo pega al padre del input para que no se pierda
        onOpen: function (selectedDates, dateStr, instance) {
            // Esto asegura que el calendario siempre esté por encima de todo
            instance.calendarContainer.style.zIndex = "99999";
        },
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