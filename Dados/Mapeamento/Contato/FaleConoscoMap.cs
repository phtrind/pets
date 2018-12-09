using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Contato;

namespace PetSaver.Repository
{
    public class FaleConoscoMap : DommelEntityMap<FaleConoscoEntity>
    {
        public FaleConoscoMap()
        {
            ToTable("FCN_FALECONOSCO");

            Map(x => x.Id).ToColumn("FCN_CODIGO").IsKey().IsIdentity();

            #region .: Foreign Keys :.

            Map(x => x.IdUsuario).ToColumn("USU_CODIGO");
            Map(x => x.IdFuncionario).ToColumn("FUN_CODIGO");

            #endregion

            #region .: Atributos :.

            Map(x => x.Email).ToColumn("FCN_EMAIL");
            Map(x => x.Mensagem).ToColumn("FCN_MENSAGEM");
            Map(x => x.Resposta).ToColumn("FCN_RESPOSTA");

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("FCN_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("FCN_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).Ignore();
            Map(x => x.IdLoginAlteracao).Ignore();

            #endregion
        }
    }
}
