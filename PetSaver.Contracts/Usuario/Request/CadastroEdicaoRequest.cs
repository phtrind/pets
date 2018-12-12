namespace PetSaver.Contracts.Usuario
{
    public class CadastroEdicaoRequest
    {
        public int IdLogin { get; set; }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Sexo { get; set; }
        public string Documento { get; set; }
        public string Senha { get; set; }
    }
}
