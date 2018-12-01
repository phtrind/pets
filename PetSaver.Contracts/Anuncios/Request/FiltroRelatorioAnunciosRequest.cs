using System;

namespace PetSaver.Contracts.Anuncios
{
    public class FiltroRelatorioAnunciosRequest
    {
        public string Nome { get; set; }
        public int? Animal { get; set; }
        public DateTime? DataCadastroInicio { get; set; }
        public DateTime? DataCadastroFim { get; set; }
        public int? Status { get; set; }
        public int? TipoAnuncio { get; set; }

        public int? Quantidade { get; set; }
        public int? Pagina { get; set; }
    }
}
