namespace PetSaver.Contracts.Anuncios
{
    public class RelatorioDoacoesContract
    {
        public int IdAnuncio { get; set; }
        public string Nome { get; set; }
        public string Animal { get; set; }
        public string DataCadastro { get; set; }
        public string Status { get; set; }
        public int Visualizacoes { get; set; }
        public int Interessados { get; set; }
    }
}
