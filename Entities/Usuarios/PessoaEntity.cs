using System;

namespace PetSaver.Entity.Usuarios
{
    public abstract class PessoaEntity : BaseEntity
    {
        /// <summary>
        /// Nome da pessoa
        /// </summary>
        public virtual string Nome { get; set; }

        /// <summary>
        /// Sobrenome da pessoa
        /// </summary>
        public virtual string Sobrenome { get; set; }

        /// <summary>
        /// Data de nascimento da pessoa
        /// </summary>
        public virtual DateTime DataNascimento { get; set; }

        /// <summary>
        /// Número do documento da pessoa
        /// </summary>
        public virtual string Documento { get; set; }

        /// <summary>
        /// Id do endereço da pessoa
        /// </summary>
        public virtual int? IdEndereco { get; set; }

        /// <summary>
        /// Id do login da pessoa
        /// </summary>
        public virtual int IdLogin { get; set; }

        /// <summary>
        /// Tipo da pessoa, aplica-se de uma forma para Usuario e de outra forma para Funcionario
        /// </summary>
        public virtual int IdTipo { get; set; }
    }
}
