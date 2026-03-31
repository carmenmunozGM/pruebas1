using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.wwwroot.js
{
    class site
    {
        window.escListener = {
            register: function () {
                document.addEventListener("keydown", function (e) {
                    if (e.key === "Escape") {
                        DotNet.invokeMethodAsync('TuProyecto', 'HandleEsc');
                    }
                });
            }
        };
    }
}
