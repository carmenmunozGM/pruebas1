namespace pruebas1.Servicios
{
    // Lee el token que manda el ERP:  pruebas1.exe --sso <token>
    public static class SsoArgs
    {
        private static string? token = LeerToken();

        private static string? LeerToken()
        {
            var args = Environment.GetCommandLineArgs();
            var i = Array.IndexOf(args, "--sso");
            return (i >= 0 && i + 1 < args.Length) ? args[i + 1] : null;
        }

        // Devuelve el token y lo borra: solo se puede usar una vez
        // (si el usuario cierra sesión y vuelve al login, no intenta entrar otra vez)
        public static string? Tomar()
        {
            var t = token;
            token = null;
            return t;
        }
    }
}