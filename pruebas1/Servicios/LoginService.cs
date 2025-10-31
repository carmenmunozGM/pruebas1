using Newtonsoft.Json;
using pruebas1.Components.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace pruebas1.Servicios
{
    public class LoginService
    {
        private readonly HttpClient httpClient;
        private List<UsuarioLoginDTO> usuarios;

        private const string KeyUsuario = "usuario";

        public LoginService(HttpClient httpClient)
        {
            this.httpClient = httpClient;


        }

        public UsuarioLoginDTO obtenerUsuarioLogueado()
        {
            var usuario = Preferences.Get("usuario", "");
            if (usuario == "") return new UsuarioLoginDTO();
            else
            {
                UsuarioLoginDTO obj = JsonConvert.DeserializeObject<UsuarioLoginDTO>(usuario);
                return obj;
            }
        }
        public bool EstaLogueado()
        {
            return Preferences.ContainsKey(KeyUsuario);
        }

        public void cerrarSesion()
        {
            Preferences.Remove("usuario");
        }

        public void guardarUsuario(UsuarioLoginDTO usuarioLoginDTO)
        {
            var data = JsonConvert.SerializeObject(usuarioLoginDTO);
            Preferences.Set("usuario", data);
        }

        public async Task<UsuarioLoginDTO> login(LoginDTO loginDTO)
        {
            try
            {
                var respuesta = await httpClient.PostAsJsonAsync<LoginDTO>("login", loginDTO);
                if (respuesta.IsSuccessStatusCode)
                {
                    string dataString = await respuesta.Content.ReadAsStringAsync();
                    if (dataString == "") return new UsuarioLoginDTO();
                    var obj = JsonConvert.DeserializeObject<UsuarioLoginDTO>(dataString);
                    return obj;
                }
                else
                { return new UsuarioLoginDTO(); }


            }
            catch (Exception ex)
            {
                return new UsuarioLoginDTO();
            }
        }

    }
}
