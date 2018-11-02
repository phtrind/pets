using System;

namespace PetSaver.Entity
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime DataCadastro { get; set; }
        public int IdUsuarioCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }
        public int IdUsuarioAlteracao { get; set; }
    }
}
