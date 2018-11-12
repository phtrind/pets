using System.Collections.Generic;

namespace PetSaver.Contracts.Anuncios
{
    public class CadastrarDoacaoRequest
    {
        public int IdUsuario { get; set; }

        public IEnumerable<CadastroAnuncioContract> Anuncios { get; set; }
    }
}
