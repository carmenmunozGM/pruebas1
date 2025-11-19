using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using pruebas1.Components.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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

            Preferences.Set("token", usuarioLoginDTO.Token);
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", usuarioLoginDTO.Token);
        }
        public async Task<UsuarioLoginDTO> login(LoginDTO loginDTO)
        {
            try
            {
                var respuesta = await httpClient.PostAsJsonAsync("login", loginDTO);

                if (!respuesta.IsSuccessStatusCode)
                    return new UsuarioLoginDTO();

                string json = await respuesta.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(json))
                    return new UsuarioLoginDTO();

                // Deserializamos el objeto completo
                var loginResponse = JsonConvert.DeserializeObject<LoginResponseDTO>(json);

                if (loginResponse == null || loginResponse.Usuario == null)
                    return new UsuarioLoginDTO();

                // Guardamos el token
                loginResponse.Usuario.Token = loginResponse.Token;

                return loginResponse.Usuario;
            }
            catch
            {
                return new UsuarioLoginDTO();
            }
        }
    }
}
