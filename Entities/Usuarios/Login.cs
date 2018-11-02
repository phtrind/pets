namespace Entities.Usuarios
{
    public class Login : BaseEntity
    {
        /// <summary>
        /// Email do login
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Senha do login
        /// </summary>
        public string Senha { get; set; }

        /// <summary>
        /// Tipo do login. Ex.: Usuário, Funcionário, etc
        /// </summary>
        public int IdTipo { get; set; }
    }
}
