using System;

namespace PetSaver.Contracts.Anuncios
{
    public class RelatorioInteressesContract
    {
        public int IdInteresse { get; set; }
        public int IdAnuncio { get; set; }
        public string Pet { get; set; }
        public string Animal { get; set; }
        public string RacaEspecie { get; set; }
        public string Data { get; set; }
        public string TipoAnuncio { get; set; }
        public string Usuario { get; set; }
        public string Status { get; set; }
    }
}
