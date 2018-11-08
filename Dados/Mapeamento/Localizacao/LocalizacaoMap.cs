using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Localizacao;

namespace PetSaver.Repository
{
    public class LocalizacaoMap : DommelEntityMap<LocalizacaoEntity>
    {
        public LocalizacaoMap()
        {
            ToTable("LOC_LOCALIZACOES");

            Map(x => x.Id).ToColumn("LOC_CODIGO").IsKey().IsIdentity();

            Map(x => x.Longitude).ToColumn("LOC_LONGITUDE");
            Map(x => x.Latitude).ToColumn("LOC_LATITUDE");

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("LOC_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("LOC_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
