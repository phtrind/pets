using System;

namespace Entities.Usuarios
{
    public class Pessoa : BaseEntity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Documento { get; set; }

        public int IdEndereco { get; set; }
        public int IdLogin { get; set; }
    }
}
