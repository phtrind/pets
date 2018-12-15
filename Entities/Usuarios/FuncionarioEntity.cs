using System;

namespace PetSaver.Entity.Usuarios
{
    public class FuncionarioEntity : PessoaEntity
    {
        #region .: Base Entity :.

        public override int Id { get; set; }

        public override DateTime DataCadastro { get; set; }
        public override int IdLoginCadastro { get; set; }

        public override DateTime? DataAlteracao { get; set; }
        public override int? IdLoginAlteracao { get; set; }

        #endregion

        #region .: Atributos Herdados :.

        public override string Nome { get; set; }
        public override string Sobrenome { get; set; }
        public override DateTime DataNascimento { get; set; }
        public override string Documento { get; set; }
        public override string Sexo { get; set; }

        #endregion

        #region .: Atributos :.

        /// <summary>
        /// Data em que o funcionário foi admitido
        /// </summary>
        public DateTime DataAdmissao { get; set; } 

        #endregion

        #region .: Foreign Key :.

        /// <summary>
        /// Id do endereço da pessoa
        /// </summary>
        public override int? IdEndereco { get; set; }

        /// <summary>
        /// Id do login da pessoa
        /// </summary>
        public override int IdLogin { get; set; }

        /// <summary>
        /// Id do tipo do funcionário, relativo ao nível de acesso. Ex.: Básico, Admin, etc
        /// </summary>
        public override int IdTipo { get; set; }

        #endregion
    }
}
