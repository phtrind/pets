using PetSaver.Contracts.Base;
using System.Collections.Generic;

namespace PetSaver.Contracts.Anuncios
{
    public class FiltroRelatorioDoacoesResponse
    {
        public IEnumerable<ChaveValorContract> Animais { get; set; }
        public IEnumerable<ChaveValorContract> Status { get; set; }
    }
}
