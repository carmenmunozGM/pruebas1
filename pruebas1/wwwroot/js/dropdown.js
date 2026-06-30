using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.wwwroot.js
{
    class dropdown
    {
        window.scrollDropdownItemIntoView = function (elementId) {

            const element = document.getElementById(elementId);

            if (element) {
                element.scrollIntoView({
                    block: 'nearest'
                });
            }
        };
    }
}
