using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Pets;

namespace PetSaver.Repository
{
    public class IdadeMap : DommelEntityMap<IdadeEntity>
    {
        public IdadeMap()
        {
            ToTable("PID_PETIDADES");

            Map(x => x.Id).ToColumn("PID_CODIGO").IsKey().IsIdentity();

            #region .: Atributos :.

            Map(x => x.Descricao).ToColumn("PID_DESCRICAO");

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("PID_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("PID_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
