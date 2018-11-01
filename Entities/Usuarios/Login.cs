namespace Entities.Usuarios
{
    public class Login : BaseEntity
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        /// <summary>
        /// Tipo do login (usuário ou funcionário)
        /// </summary>
        public int IdTipo { get; set; }
    }
}
