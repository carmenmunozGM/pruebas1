using Newtonsoft.Json;
using pruebas1.Components.DTOs;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace pruebas1.Servicios
{
    public class LoginService
    {
        private readonly HttpClient httpClient;
        private const string KeyUsuario = "usuario";
        private const string KeyToken = "token";
        private const string KeyAgenda = "agenda"; // Nueva clave para guardar agenda

        public LoginService(HttpClient httpClient)
        {
            this.httpClient = httpClient;

            // 🔹 Al inicializar, cargar token guardado en HttpClient si existe
            var tokenGuardado = Preferences.Get(KeyToken, "");
            if (!string.IsNullOrWhiteSpace(tokenGuardado))
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", tokenGuardado);
            }

            // Cargar agenda si existe
            if (Preferences.ContainsKey(KeyAgenda))
            {
                AgendaActual = Preferences.Get(KeyAgenda, 0);
            }
        }

        // Agenda actual del usuario
        public int? AgendaActual { get; private set; } = null;

        // Guardar agenda actual
        public void SetAgendaActual(int idAgenda)
        {
            AgendaActual = idAgenda;
            Preferences.Set(KeyAgenda, idAgenda);
        }

        // Obtener usuario logueado
        public UsuarioLoginDTO obtenerUsuarioLogueado()
        {
            var usuarioJson = Preferences.Get(KeyUsuario, "");
            if (string.IsNullOrEmpty(usuarioJson))
                return new UsuarioLoginDTO();

            var usuario = JsonConvert.DeserializeObject<UsuarioLoginDTO>(usuarioJson);
            return usuario ?? new UsuarioLoginDTO();
        }

        // Método alternativo
        public UsuarioLoginDTO GetUsuarioActual()
        {
            return obtenerUsuarioLogueado();
        }

        // Saber si hay usuario logueado
        public bool EstaLogueado()
        {
            return Preferences.ContainsKey(KeyUsuario);
        }

        // Cerrar sesión
        public void cerrarSesion(UsuarioState usuarioState)
        {
            Preferences.Remove(KeyUsuario);
            Preferences.Remove(KeyToken);
            Preferences.Remove(KeyAgenda);
            AgendaActual = null;
            httpClient.DefaultRequestHeaders.Authorization = null;

            // Limpiar estado global
            usuarioState?.Reset();
        }



        // Guardar usuario y actualizar HttpClient con token
        public void guardarUsuario(UsuarioLoginDTO usuarioLoginDTO)
        {
            if (usuarioLoginDTO == null) return;

            // Serializar usuario completo
            var data = JsonConvert.SerializeObject(usuarioLoginDTO);
            Preferences.Set(KeyUsuario, data);

            // Guardar token
            Preferences.Set(KeyToken, usuarioLoginDTO.Token);

            // 🔹 Actualizar HttpClient con el token
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", usuarioLoginDTO.Token);

            // 🔹 Asignar agenda actual automáticamente si existe
            if (usuarioLoginDTO.IdAgendasAsignadas?.Count > 0)
                SetAgendaActual(usuarioLoginDTO.IdAgendasAsignadas[0]);
        }

        // Login
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

                // Deserializamos la respuesta completa
                var loginResponse = JsonConvert.DeserializeObject<LoginResponseDTO>(json);
                if (loginResponse == null || loginResponse.Usuario == null)
                    return new UsuarioLoginDTO();

                // Guardar token en el objeto usuario
                loginResponse.Usuario.Token = loginResponse.Token;

                // 🔹 Actualizar HttpClient inmediatamente después de login
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", loginResponse.Token);

                // Asegurar listas vacías
                if (loginResponse.Usuario.IdAgendasAsignadas == null)
                    loginResponse.Usuario.IdAgendasAsignadas = new List<int>();

                // 🔹 Asignar agenda actual automáticamente si existe
                if (loginResponse.Usuario.IdAgendasAsignadas.Count > 0)
                    SetAgendaActual(loginResponse.Usuario.IdAgendasAsignadas[0]);

                return loginResponse.Usuario;
            }
            catch
            {
                return new UsuarioLoginDTO();
            }
        }
    }
}
