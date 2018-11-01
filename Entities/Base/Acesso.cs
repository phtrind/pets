using System;

namespace Entities
{
    public class Acesso : BaseEntity
    {
        public int IdUsuario { get; set; }
        public DateTime DataHora { get; set; }
    }
}