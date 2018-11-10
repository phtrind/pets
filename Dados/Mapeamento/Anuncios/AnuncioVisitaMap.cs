using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Anuncios;

namespace PetSaver.Repository
{
    public class AnuncioVisitaMap : DommelEntityMap<AnuncioVisitaEntity>
    {
        public AnuncioVisitaMap()
        {
            ToTable("AVI_ANUNCIOSVISITAS");

            Map(x => x.Id).ToColumn("AVI_CODIGO").IsKey().IsIdentity();

            #region .: Foreign Keys :.

            Map(x => x.IdUsuario).ToColumn("USU_CODIGO");
            Map(x => x.IdAnuncio).ToColumn("ANU_CODIGO");

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("AVI_DTHCADASTRO");

            Map(x => x.IdLoginCadastro).Ignore();
            Map(x => x.IdLoginAlteracao).Ignore();
            Map(x => x.DataAlteracao).Ignore();

            #endregion
        }
    }
}
