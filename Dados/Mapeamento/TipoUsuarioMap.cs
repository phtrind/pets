using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Usuarios;

namespace PetSaver.Repository
{
    public class TipoUsuarioMap : DommelEntityMap<TipoUsuarioEntity>
    {
        public TipoUsuarioMap()
        {
            ToTable("UST_USUARIOTIPOS");

            Map(x => x.Id).ToColumn("UST_CODIGO").IsKey().IsIdentity();

            Map(x => x.Descricao).ToColumn("UST_DESCRICAO");

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("UST_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("UST_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
