using PetSaver.Contracts.Chat;
using System.Collections.Generic;

namespace PetSaver.Contracts.Paginas
{
    public class ChatPageResponse
    {
        public int IdAnuncio { get; set; }
        public int IdInteresse { get; set; }
        public string Imagem { get; set; }
        public string Pet { get; set; }
        public string Usuario { get; set; }
        public IEnumerable<InboxResponseContract> Mensagens { get; set; }
    }
}
