using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Anuncios;

namespace PetSaver.Repository
{
    public class AnuncioFotoMap : DommelEntityMap<AnuncioFotoEntity>
    {
        public AnuncioFotoMap()
        {
            ToTable("ANF_ANUNCIOFOTOS");

            Map(x => x.Id).ToColumn("ANF_CODIGO").IsKey().IsIdentity();

            #region .: Foreign Keys :.

            Map(x => x.IdAnuncio).ToColumn("ANU_CODIGO");

            #endregion

            #region .: Atributos :.

            Map(x => x.Caminho).ToColumn("ANF_LINK");
            Map(x => x.Destaque).ToColumn("ANF_DESTAQUE");

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("ANF_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("ANF_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
