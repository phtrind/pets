using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSaver.Entity.Usuarios
{
    public class TipoUsuarioEntity : TipoEntity
    {
        #region .: Propriedades Herdadas :.

        #region .: BaseEntity :.

        public override int Id { get; set; }

        public override DateTime DataCadastro { get; set; }
        public override int IdLoginCadastro { get; set; }

        public override DateTime? DataAlteracao { get; set; }
        public override int? IdLoginAlteracao { get; set; }

        #endregion

        #region .: TipoEntity :.

        /// <summary>
        /// Descricao do tipo de usuário, se é pessoa jurídica ou pessoa física
        /// </summary>
        public override string Descricao { get; set; }

        #endregion

        #endregion
    }
}
