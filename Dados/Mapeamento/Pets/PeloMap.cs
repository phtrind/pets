using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Pets;

namespace PetSaver.Repository
{
    public class PeloMap : DommelEntityMap<PeloEntity>
    {
        public PeloMap()
        {
            ToTable("PPL_PETPELOS");

            Map(x => x.Id).ToColumn("PPL_CODIGO").IsKey().IsIdentity();

            #region .: Atributos :.

            Map(x => x.Descricao).ToColumn("PPL_DESCRICAO");

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("PPL_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("PPL_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
