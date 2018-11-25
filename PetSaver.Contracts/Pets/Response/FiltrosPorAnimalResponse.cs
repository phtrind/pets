using PetSaver.Contracts.Base;
using System.Collections.Generic;

namespace PetSaver.Contracts.Pets
{
    public class FiltrosPorAnimalResponse
    {
        public IEnumerable<ChaveValorContract> Sexos { get; set; }
        public IEnumerable<ChaveValorContract> RacasEspecies { get; set; }
        public IEnumerable<ChaveValorContract> Pelos { get; set; }
        public IEnumerable<ChaveValorContract> Idades { get; set; }
        public IEnumerable<ChaveValorContract> Cores { get; set; }
        public IEnumerable<ChaveValorContract> Portes { get; set; }
    }
}
