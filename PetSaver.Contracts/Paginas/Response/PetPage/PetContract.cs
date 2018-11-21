using PetSaver.Contracts.Base;
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
        public string Cor { get; set; }
        public string Pelo { get; set; }
        public string Vacinado { get; set; }
        public string Vermifugado { get; set; }
        public string Castrado { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<ChaveValorContract> Fotos { get; set; }
    }
}
