using System;

namespace PetSaver.Entity
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }

        public virtual DateTime DataCadastro { get; set; }
        public virtual int IdLoginCadastro { get; set; }

        public virtual DateTime? DataAlteracao { get; set; }
        public virtual int? IdLoginAlteracao { get; set; }
    }
}
