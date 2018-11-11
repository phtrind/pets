using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Anuncios;

namespace PetSaver.Repository
{
    public class AnuncioStatusMap : DommelEntityMap<AnuncioStatusEntity>
    {
        public AnuncioStatusMap()
        {
            ToTable("ANS_ANUNCIOSTATUS");

            Map(x => x.Id).ToColumn("ANS_CODIGO").IsKey().IsIdentity();

            #region .: Descrição :.

            Map(x => x.Descricao).ToColumn("ANS_DESCRICAO");

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("ANS_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("ANS_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
