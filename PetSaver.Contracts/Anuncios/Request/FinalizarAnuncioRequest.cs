namespace PetSaver.Contracts.Anuncios
{
    public class FinalizarAnuncioRequest
    {
        public int IdLogin { get; set; }
        public int IdUsuario { get; set; }
        public int IdAnuncio { get; set; }
        public string Status { get; set; }
    }
}
