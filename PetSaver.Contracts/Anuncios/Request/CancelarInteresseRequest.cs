namespace PetSaver.Contracts.Anuncios
{
    public class CancelarInteresseRequest
    {
        public int IdLogin { get; set; }
        public int IdUsuario { get; set; }
        public int IdInteresse { get; set; }
    }
}
