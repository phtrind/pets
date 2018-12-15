using PetSaver.Contracts.Base;
using System.Collections.Generic;

namespace PetSaver.Contracts.Anuncios
{
    public class DetalharAnuncioAprovacaoContract
    {
        public int IdAnuncio { get; set; }
        public IEnumerable<ChaveValorContract> Fotos { get; set; }
        public string NomePet { get; set; }
        public string Sobre { get; set; }
    }
}
