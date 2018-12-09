using System;

namespace PetSaver.Entity.Contato
{
    public class FaleConoscoEntity : BaseEntity
    {
        #region .: Base Entity :.

        public override int Id { get; set; }

        public override DateTime DataCadastro { get; set; }
        public override DateTime? DataAlteracao { get; set; }

        #endregion

        #region .: Foreign Keys :.

        public int? IdUsuario { get; set; }
        public int? IdFuncionario { get; set; }

        #endregion

        #region .: Atributos :.

        public string Email { get; set; }
        public string Mensagem { get; set; }
        public string Resposta { get; set; }

        #endregion
    }
}
