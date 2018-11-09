namespace PetSaver.Contracts.Anuncios
{
    public class FiltroAnuncioRequest
    {
        public int? IdEstado { get; set; }
        public int? IdCidade { get; set; }
        public int? IdAnimal { get; set; }
        public int? IdSexo { get; set; }
        public int? IdPorte { get; set; }
        public int? IdRacaEspecie { get; set; }
        public int? IdPelo { get; set; }
        public int? IdIdade { get; set; }
        public int? IdCor { get; set; }
        public string Nome { get; set; }

        public int Quantidade { get; set; }
        public int Pagina { get; set; }
    }
}
