namespace PetSaver.Contracts.Chat
{
    public class CadastroInboxRequest
    {
        public int IdLogin { get; set; }
        public int IdUsuario { get; set; }
        public int IdInteresse { get; set; }
        public string Mensagem { get; set; }
    }
}
