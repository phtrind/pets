using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Localizacao;

namespace PetSaver.Repository
{
    public class CidadeMap : DommelEntityMap<CidadeEntity>
    {
        public CidadeMap()
        {
            ToTable("CID_CIDADES");

            Map(x => x.Id).ToColumn("CID_CODIGO").IsKey().IsIdentity();

            Map(x => x.Nome).ToColumn("CID_NOME");

            #region .: Foreign Keys :.

            Map(x => x.IdEstado).ToColumn("EST_CODIGO");

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("CID_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("CID_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
