using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Usuarios;

namespace PetSaver.Repository
{
    public class HistoricoLoginMap : DommelEntityMap<HistoricoLoginEntity>
    {
        public HistoricoLoginMap()
        {
            ToTable("HLG_HISTLOGINS");

            Map(x => x.Id).ToColumn("HLG_CODIGO").IsKey().IsIdentity();

            #region .: Foreign Keys :.

            Map(x => x.IdLogin).ToColumn("LOG_CODIGO");

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("HLG_DTHCADASTRO");

            Map(x => x.DataAlteracao).Ignore();
            Map(x => x.IdLoginCadastro).Ignore();
            Map(x => x.IdLoginAlteracao).Ignore();

            #endregion
        }
    }
}
