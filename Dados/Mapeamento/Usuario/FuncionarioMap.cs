using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Usuarios;

namespace PetSaver.Repository
{
    public class FuncionarioMap : DommelEntityMap<FuncionarioEntity>
    {
        public FuncionarioMap()
        {
            ToTable("FUN_FUNCIONARIOS");

            Map(x => x.Id).ToColumn("FUN_CODIGO").IsKey().IsIdentity();

            Map(x => x.Nome).ToColumn("FUN_NOME");
            Map(x => x.Sobrenome).ToColumn("FUN_SOBRENOME");
            Map(x => x.DataNascimento).ToColumn("FUN_DTHNASCIMENTO");
            Map(x => x.Documento).ToColumn("FUN_DOCUMENTO");
            Map(x => x.Sexo).ToColumn("FUN_SEXO");
            Map(x => x.DataAdmissao).ToColumn("FUN_DTHADMISSAO");

            #region .: Foreign Keys :.

            Map(x => x.IdLogin).ToColumn("LOG_CODIGO");
            Map(x => x.IdEndereco).ToColumn("END_CODIGO");
            Map(x => x.IdTipo).ToColumn("FNT_CODIGO");
            
            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("FUN_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("FUN_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
