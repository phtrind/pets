using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Anuncios;

namespace PetSaver.Repository
{
    public class AnuncioGosteiMap : DommelEntityMap<AnuncioGosteiEntity>
    {
        public AnuncioGosteiMap()
        {
            ToTable("ANG_ANUNCIOSGOSTEI");

            Map(x => x.Id).ToColumn("ANG_CODIGO").IsKey().IsIdentity();

            #region .: Foreign Keys :.

            Map(x => x.IdAnuncio).ToColumn("ANU_CODIGO");
            Map(x => x.IdUsuario).ToColumn("USU_CODIGO");

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("ANG_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("ANG_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
