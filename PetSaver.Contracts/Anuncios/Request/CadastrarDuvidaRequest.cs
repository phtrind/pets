namespace PetSaver.Contracts.Anuncios
{
    public class CadastrarDuvidaRequest
    {
        public int IdAnuncio { get; set; }
        public int IdUsuario { get; set; }
        public string Pergunta { get; set; }
    }
}
