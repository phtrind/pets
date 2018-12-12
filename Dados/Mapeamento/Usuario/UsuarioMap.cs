using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Usuarios;

namespace PetSaver.Repository
{
    public class UsuarioMap : DommelEntityMap<UsuarioEntity>
    {
        public UsuarioMap()
        {
            ToTable("USU_USUARIOS");

            Map(x => x.Id).ToColumn("USU_CODIGO").IsKey().IsIdentity();

            #region .: Atributos :.

            Map(x => x.Nome).ToColumn("USU_NOME");
            Map(x => x.Sobrenome).ToColumn("USU_SOBRENOME");
            Map(x => x.DataNascimento).ToColumn("USU_DTHNASCIMENTO");
            Map(x => x.Documento).ToColumn("USU_DOCUMENTO"); 
            Map(x => x.Sexo).ToColumn("USU_SEXO"); 

            #endregion

            #region .: Foreign Keys :.

            Map(x => x.IdLogin).ToColumn("LOG_CODIGO");
            Map(x => x.IdEndereco).ToColumn("END_CODIGO");
            Map(x => x.IdTipo).ToColumn("UST_CODIGO");

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("USU_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("USU_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
