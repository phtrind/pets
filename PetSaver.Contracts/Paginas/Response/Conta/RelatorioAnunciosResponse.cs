using PetSaver.Contracts.Anuncios;
using System.Collections.Generic;

namespace PetSaver.Contracts.Paginas
{
    public class RelatorioAnunciosResponse
    {
        public FiltroRelatorioAnunciosResponse Filtros { get; set; }
        public IEnumerable<RelatorioAnunciosContract> Anuncios { get; set; }
    }
}
