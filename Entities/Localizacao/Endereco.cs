namespace Entities.Localizacao
{
    public class Endereco : BaseEntity
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }

        public int IdCidade { get; set; }
        public int IdEstado { get; set; }
    }
}
