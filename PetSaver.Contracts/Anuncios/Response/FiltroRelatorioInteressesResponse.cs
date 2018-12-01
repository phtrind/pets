using PetSaver.Contracts.Base;
using System.Collections.Generic;

namespace PetSaver.Contracts.Anuncios.Response
{
    public class FiltroRelatorioInteressesResponse
    {
        public IEnumerable<ChaveValorContract> Animais { get; set; }
        public IEnumerable<ChaveValorContract> TiposAnuncio { get; set; }
    }
}
