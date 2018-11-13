using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Usuarios;

namespace PetSaver.Repository
{
    public class LoginMap : DommelEntityMap<LoginEntity>
    {
        public LoginMap()
        {
            ToTable("LOG_LOGINS");

            Map(x => x.Id).ToColumn("LOG_CODIGO").IsKey().IsIdentity();

            Map(x => x.Email).ToColumn("LOG_EMAIL");
            Map(x => x.Senha).ToColumn("LOG_SENHA");

            #region .: Foreign Keys :.

            Map(x => x.IdTipo).ToColumn("LOT_CODIGO");

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("LOG_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("LOG_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
