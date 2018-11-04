using System;

namespace PetSaver.Entity.Usuarios
{
    public class UsuarioEntity : PessoaEntity
    {
        #region .: Propriedades Herdadas :.

        #region .: Base Entity :.

        public override int Id { get; set; }

        public override DateTime DataCadastro { get; set; }
        public override int IdLoginCadastro { get; set; }

        public override DateTime? DataAlteracao { get; set; }
        public override int? IdLoginAlteracao { get; set; }

        #endregion

        #region .: Pessoa Entity :.

        public override string Nome { get; set; }
        public override string Sobrenome { get; set; }
        public override DateTime DataNascimento { get; set; }
        public override string Documento { get; set; }
        public override int? IdEndereco { get; set; }
        public override int IdLogin { get; set; } 

        /// <summary>
        /// Pessoa física ou pessoa jurídica
        /// </summary>
        public override int IdTipo { get; set; } 

        #endregion

        #endregion
    }
}
