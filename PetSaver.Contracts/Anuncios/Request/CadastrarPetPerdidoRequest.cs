namespace PetSaver.Contracts.Anuncios
{
    public class CadastrarPetPerdidoRequest
    {
        public int IdUsuario { get; set; }

        public CadastroAnuncioContract Anuncio { get; set; }
    }
}
