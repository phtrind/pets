namespace PetSaver.Contracts.Anuncios
{
    public class RelatorioDoacoesRequest
    {
        public int IdUsuario { get; set; }
        public FiltroRelatorioDoacoesRequest Filtro { get; set; }
    }
}
