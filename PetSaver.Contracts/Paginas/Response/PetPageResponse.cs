using PetSaver.Contracts.Base;
using PetSaver.Contracts.Paginas.Response.PetPage;
using System.Collections.Generic;

namespace PetSaver.Contracts.Paginas
{
    public class PetPageResponse : BasePageContract
    {
        public AnuncianteContract Anunciante { get; set; }

        public PetContract Pet { get; set; }

        public LocalizacaoContract Localizacao { get; set; }

        public IEnumerable<DuvidaContract> Duvidas { get; set; }
    }
}
