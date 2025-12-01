namespace pruebas1.Servicios
{
    public class UsuarioState
    {
        public int IdUsuario { get; private set; }
        public int IdAgenda { get; private set; }

        public void SetUsuario(int idUsuario, int idAgenda)
        {
            IdUsuario = idUsuario;
            IdAgenda = idAgenda;
        }

        public void Reset()
        {
            IdUsuario = 0;
            IdAgenda = 0;
        }
    }

}
