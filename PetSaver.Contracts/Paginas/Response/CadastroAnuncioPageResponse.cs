using PetSaver.Contracts.Base;
using System.Collections.Generic;

namespace PetSaver.Contracts.Paginas
{
    public class CadastroAnuncioPageResponse
    {
        public IEnumerable<ChaveValorContract> Animais { get; set; }
        public IEnumerable<ChaveValorContract> Sexos { get; set; }
        public IEnumerable<ChaveValorContract> Idades { get; set; }
        public IEnumerable<ChaveValorContract> Portes { get; set; }
        public IEnumerable<ChaveValorContract> Pelos { get; set; }
        public IEnumerable<ChaveValorContract> Cores { get; set; }
        public IEnumerable<ChaveValorContract> Estados { get; set; }
    }
}
