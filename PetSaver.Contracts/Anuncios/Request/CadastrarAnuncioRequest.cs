namespace PetSaver.Contracts.Anuncios
{
    public class CadastrarPetAnuncioRequest
    {
        public int IdUsuario { get; set; }

        public CadastroAnuncioContract Anuncio { get; set; }
    }
}
