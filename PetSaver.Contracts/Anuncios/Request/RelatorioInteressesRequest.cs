namespace PetSaver.Contracts.Anuncios
{
    public class RelatorioInteressesRequest
    {
        public string Nome { get; set; }
        public int IdUsuario { get; set; }
        public int? IdAnimal { get; set; }
        public int? IdTipoAnuncio { get; set; }
    }
}
