namespace PetSaver.Contracts.Anuncios
{
    public class RelatorioAnunciosRequest
    {
        public int IdUsuario { get; set; }
        public FiltroRelatorioAnunciosRequest Filtro { get; set; }
    }
}
