using System.Collections.Generic;

namespace PetSaver.Contracts.Paginas.Response.PetPage
{
    public class PetContract
    {
        public string Nome { get; set; }
        public string RacaEspecie { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Sexo { get; set; }
        public string Idade { get; set; }
        public string Porte { get; set; }
        public string Peso { get; set; }
        public IEnumerable<string> Cores { get; set; }
        public string Pelo { get; set; }
        public bool? Vacinado { get; set; }
        public bool? Vermifugado { get; set; }
        public bool? Castrado { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<string> Fotos { get; set; }
    }
}
