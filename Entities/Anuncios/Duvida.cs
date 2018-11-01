using System;

namespace Entities.Anuncios
{
    public class Duvida : BaseEntity
    {
        public string Pergunta { get; set; }
        public string Resposta { get; set; }
        public DateTime DataHoraResposta { get; set; }
    }
}
