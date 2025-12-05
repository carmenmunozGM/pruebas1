using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.wwwroot.js
{
    // wwwroot/js/alertas-modal.js
    // Asegúrate de que SweetAlert2 (Swal) ya esté cargado antes de ejecutar estas funciones.

    window.alertaGuardadoEvento = function () {
        if (!window.Swal) {
            console.error("SweetAlert2 (Swal) no está disponible.");
            return;
        }

        Swal.fire({
            icon: 'success',
            title: 'Guardado con éxito 🎉',
            confirmButtonText: 'OK'
        }).then(function () {
            // Segunda alerta informativa
            Swal.fire({
                icon: 'info',
                title: 'No se te olvide registrarlo en RED GM',
                text: 'Verifica en Red GM este evento',
                confirmButtonText: 'Entendido'
            });
        });
    };

    window.alertaGuardadoSimple = function () {
        if (!window.Swal) {
            console.error("SweetAlert2 (Swal) no está disponible.");
            return;
        }

        Swal.fire({
            icon: 'success',
            title: 'Guardado con éxito 🎉',
            confirmButtonText: 'OK'
        });
    };

}
