using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Anuncios;

namespace PetSaver.Repository
{
    public class AnuncioStatusHistoricoMap : DommelEntityMap<AnuncioStatusHistoricoEntity>
    {
        public AnuncioStatusHistoricoMap()
        {
            ToTable("ASH_ANUNSTATSHIST");

            Map(x => x.Id).ToColumn("ASH_CODIGO").IsKey().IsIdentity();

            #region .: Foreign Keys :.

            Map(x => x.IdAnuncio).ToColumn("ANU_CODIGO");
            Map(x => x.IdStatus).ToColumn("ANS_CODIGO");

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("ASH_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("ASH_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
