namespace PetSaver.Contracts.Anuncios
{
    public class CadastrarRespostaRequest
    {
        public int IdDuvida { get; set; }
        public int IdUsuario { get; set; }
        public int IdLogin { get; set; }
        public string Resposta { get; set; }
    }
}
