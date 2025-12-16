using Newtonsoft.Json;
using pruebas1.Components.DTOs;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.Maui.Storage;

namespace pruebas1.Servicios
{
    public class LoginService
    {
        private readonly HttpClient httpClient;

        private const string KeyUsuario = "usuario";
        private const string KeyToken = "token";
        private const string KeyAgenda = "agenda";

        public LoginService(HttpClient httpClient)
        {
            this.httpClient = httpClient;

            // 🔹 Cargar token si existe
            var tokenGuardado = Preferences.Get(KeyToken, "");
            if (!string.IsNullOrWhiteSpace(tokenGuardado))
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", tokenGuardado);
            }

            // ❗ NO CARGAR AGENDA AUTOMÁTICAMENTE AQUÍ
            // Se asigna SOLO cuando el usuario hace login
        }

        // Agenda actual
        public int? AgendaActual { get; private set; } = null;

        public void SetAgendaActual(int idAgenda)
        {
            AgendaActual = idAgenda;
            Preferences.Set(KeyAgenda, idAgenda);
        }

        public UsuarioLoginDTO obtenerUsuarioLogueado()
        {
            var json = Preferences.Get(KeyUsuario, "");
            if (string.IsNullOrEmpty(json))
                return new UsuarioLoginDTO();

            return JsonConvert.DeserializeObject<UsuarioLoginDTO>(json) ?? new UsuarioLoginDTO();
        }

        public bool EstaLogueado()
        {
            return Preferences.ContainsKey(KeyUsuario);
        }

        // 🔥 LOGOUT CORRECTO
        public void cerrarSesion(UsuarioState usuarioState)
        {
            Preferences.Remove(KeyUsuario);
            Preferences.Remove(KeyToken);
            Preferences.Remove(KeyAgenda); // 🔥 BORRAR AGENDA SIEMPRE

            AgendaActual = null;
            httpClient.DefaultRequestHeaders.Authorization = null;

            usuarioState?.Reset();
        }

        // Guardar usuario SIN tocar agenda
        public void guardarUsuario(UsuarioLoginDTO usuarioLoginDTO)
        {
            if (usuarioLoginDTO == null) return;

            var json = JsonConvert.SerializeObject(usuarioLoginDTO);
            Preferences.Set(KeyUsuario, json);

            Preferences.Set(KeyToken, usuarioLoginDTO.Token);

            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", usuarioLoginDTO.Token);
        }

        // LOGIN PRINCIPAL
        /*public async Task<UsuarioLoginDTO> login(LoginDTO loginDTO)
        {
            try
            {
                var respuesta = await httpClient.PostAsJsonAsync("login", loginDTO);

                if (!respuesta.IsSuccessStatusCode)
                    return new UsuarioLoginDTO();

                var json = await respuesta.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<LoginResponseDTO>(json);

                if (loginResponse == null || loginResponse.Usuario == null)
                    return new UsuarioLoginDTO();

                // Asignar token al objeto usuario
                loginResponse.Usuario.Token = loginResponse.Token;

                // Guardar usuario SIN tocar agenda
                guardarUsuario(loginResponse.Usuario);

                // 🔥 AHORA SÍ asignar agenda desde la respuesta del backend
                if (loginResponse.Usuario.IdAgendasAsignadas?.Count > 0)
                {
                    var agenda = loginResponse.Usuario.IdAgendasAsignadas[0];
                    SetAgendaActual(agenda);

                    // Debug
                    Console.WriteLine($"✔ Agenda asignada tras login: {agenda}");
                }

                return loginResponse.Usuario;
            }
            catch
            {
                return new UsuarioLoginDTO();
            }*/
        public async Task<UsuarioLoginDTO> login(LoginDTO loginDTO)
        {
            var respuesta = await httpClient.PostAsJsonAsync("login", loginDTO);

            if (!respuesta.IsSuccessStatusCode)
                return new UsuarioLoginDTO();

            var loginResponse =
                await respuesta.Content.ReadFromJsonAsync<LoginResponseDTO>();

            if (loginResponse?.Usuario == null)
                return new UsuarioLoginDTO();

            // ✅ Token
            loginResponse.Usuario.Token = loginResponse.Token;

            // 💾 Guardar usuario
            guardarUsuario(loginResponse.Usuario);

            // 📅 Agenda
            if (loginResponse.Usuario.IdAgendasAsignadas?.Any() == true)
            {
                SetAgendaActual(loginResponse.Usuario.IdAgendasAsignadas[0]);
            }

            return loginResponse.Usuario;
        }


    }
}

