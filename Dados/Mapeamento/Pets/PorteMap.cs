using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Pets;

namespace PetSaver.Repository
{
    public class PorteMap : DommelEntityMap<PorteEntity>
    {
        public PorteMap()
        {
            ToTable("PPR_PETPORTES");

            Map(x => x.Id).ToColumn("PPR_CODIGO").IsKey().IsIdentity();

            #region .: Atributos :.

            Map(x => x.Descricao).ToColumn("PPR_DESCRICAO");

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("PPR_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("PPR_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
