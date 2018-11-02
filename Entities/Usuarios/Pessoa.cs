using System;

namespace Entities.Usuarios
{
    public class Pessoa : BaseEntity
    {
        /// <summary>
        /// Nome da pessoa
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Sobrenome da pessoa
        /// </summary>
        public string Sobrenome { get; set; }

        /// <summary>
        /// Data de nascimento da pessoa
        /// </summary>
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Número do documento da pessoa
        /// </summary>
        public string Documento { get; set; }

        /// <summary>
        /// Id do endereço da pessoa
        /// </summary>
        public int IdEndereco { get; set; }

        /// <summary>
        /// Id do login da pessoa
        /// </summary>
        public int IdLogin { get; set; }
    }
}
