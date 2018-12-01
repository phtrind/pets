using PetSaver.Contracts.Anuncios;
using PetSaver.Contracts.Anuncios.Response;
using System.Collections.Generic;

namespace PetSaver.Contracts.Paginas
{
    public class RelatorioInteressesPageResponse
    {
        public FiltroRelatorioInteressesResponse Filtros { get; set; }
        public IEnumerable<RelatorioInteressesContract> Interesses { get; set; }
    }
}
