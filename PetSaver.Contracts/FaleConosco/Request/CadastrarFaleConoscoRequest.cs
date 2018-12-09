namespace PetSaver.Contracts.FaleConosco
{
    public class CadastrarFaleConoscoRequest
    {
        public int? IdUsuario { get; set; }
        public string Email { get; set; }
        public string Mensagem { get; set; }
    }
}
