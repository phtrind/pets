namespace PetSaver.Contracts.Anuncios
{
    public class CadastroAnuncioContract
    {
        public CadastroPetContract Pet { get; set; }

        public CadastroLocalizacaoContract Localizacao { get; set; }

        public int IdEstado { get; set; }
        public int IdCidade { get; set; }

        public string GuidImagens { get; set; }
    }
}
