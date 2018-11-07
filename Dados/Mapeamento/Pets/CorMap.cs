using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Pets;

namespace PetSaver.Repository
{
    public class CorMap : DommelEntityMap<CorEntity>
    {
        public CorMap()
        {
            ToTable("COR_CORES");

            Map(x => x.Id).ToColumn("COR_CODIGO").IsKey().IsIdentity();

            #region .: Atributos :.

            Map(x => x.Nome).ToColumn("COR_NOME");

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("COR_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("COR_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
