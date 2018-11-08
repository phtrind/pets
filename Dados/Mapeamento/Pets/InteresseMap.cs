using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Anuncios;

namespace PetSaver.Repository
{
    public class InteresseMap : DommelEntityMap<InteresseEntity>
    {
        public InteresseMap()
        {
            ToTable("INT_INTERESSES");

            Map(x => x.Id).ToColumn("INT_CODIGO").IsKey().IsIdentity();

            #region .: Foreign Keys :.

            Map(x => x.IdUsuario).ToColumn("USU_CODIGO");
            Map(x => x.IdAnuncio).ToColumn("ANU_CODIGO");
            Map(x => x.IdStatus).ToColumn("INS_CODIGO");

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("INT_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("INT_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
