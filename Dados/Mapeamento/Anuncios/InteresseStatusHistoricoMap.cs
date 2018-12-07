using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Anuncios;

namespace PetSaver.Repository
{
    public class InteresseStatusHistoricoMap : DommelEntityMap<InteresseStatusHistoricoEntity>
    {
        public InteresseStatusHistoricoMap()
        {
            ToTable("ISH_INTERSTATUSHIST");

            Map(x => x.Id).ToColumn("ISH_CODIGO").IsKey().IsIdentity();

            #region .: Foreign Keys :.

            Map(x => x.IdInteresse).ToColumn("INT_CODIGO");
            Map(x => x.IdStatus).ToColumn("INS_CODIGO");

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("ISH_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("ISH_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
