using System.Collections.Generic;

namespace PetSaver.Contracts.Anuncios
{
    public class RelatorioDoacoesResponse
    {
        public FiltroRelatorioDoacoesResponse Filtros { get; set; }

        public IEnumerable<RelatorioDoacoesContract> Anuncios { get; set; }
    }
}
