using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Anuncios;

namespace PetSaver.Repository
{
    public class AvaliacaoMap : DommelEntityMap<AvaliacaoEntity>
    {
        public AvaliacaoMap()
        {
            ToTable("AVA_AVALIACOES");

            Map(x => x.Id).ToColumn("AVA_CODIGO").IsKey().IsIdentity();

            #region .: Atributos :.

            Map(x => x.Nota).ToColumn("AVA_NOTA");
            Map(x => x.Descricao).ToColumn("AVA_DESCRICAO");

            #endregion

            #region .: Foreign Keys :.

            Map(x => x.IdInteresse).ToColumn("INT_CODIGO");
            Map(x => x.IdAvaliador).ToColumn("USU_AVALIADOR");
            Map(x => x.IdAvaliado).ToColumn("USU_AVALIADO");

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("AVA_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("AVA_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
