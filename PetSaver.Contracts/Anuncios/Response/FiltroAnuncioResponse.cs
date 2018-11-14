using PetSaver.Contracts.Base;
using System.Collections.Generic;

namespace PetSaver.Contracts.Anuncios
{
    public class FiltroAnuncioResponse
    {
        public IEnumerable<ChaveValorContract> Estados { get; set; }
        public IEnumerable<ChaveValorContract> Animais { get; set; }
        public IEnumerable<ChaveValorContract> Sexos { get; set; }
    }
}
