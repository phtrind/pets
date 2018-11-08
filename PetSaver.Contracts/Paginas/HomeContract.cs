using PetSaver.Contracts.Anuncios;
using PetSaver.Contracts.Base;
using System.Collections.Generic;

namespace PetSaver.Contracts.Paginas
{
    public class HomeContract : BasePageContract
    {
        public List<AnuncioMiniaturaContract> Anuncios { get; set; }
        public List<ChaveValorContract> Animais { get; set; }
        public List<ChaveValorContract> Sexos { get; set; }
        public List<ChaveValorContract> Estados { get; set; }
    }
}
