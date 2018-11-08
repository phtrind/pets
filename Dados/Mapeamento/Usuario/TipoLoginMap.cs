using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Usuarios;

namespace PetSaver.Repository
{
    public class TipoLoginMap : DommelEntityMap<TipoLoginEntity>
    {
        public TipoLoginMap()
        {
            ToTable("LOT_LOGINTIPOS");

            Map(x => x.Id).ToColumn("LOT_CODIGO").IsKey().IsIdentity();

            Map(x => x.Descricao).ToColumn("LOT_DESCRICAO");

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("LOT_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("LOT_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
