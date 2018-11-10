using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Anuncios;

namespace PetSaver.Repository
{
    public class AnuncioMap : DommelEntityMap<AnuncioEntity>
    {
        public AnuncioMap()
        {
            ToTable("ANU_ANUNCIOS");

            Map(x => x.Id).ToColumn("ANU_CODIGO").IsKey().IsIdentity();

            #region .: Foreign Keys :.

            Map(x => x.IdStatus).ToColumn("ANS_CODIGO");
            Map(x => x.IdTipo).ToColumn("ANT_CODIGO");
            Map(x => x.IdPet).ToColumn("PET_CODIGO");
            Map(x => x.IdLocalizacao).ToColumn("LOC_CODIGO");
            Map(x => x.IdEstado).ToColumn("EST_CODIGO");
            Map(x => x.IdCidade).ToColumn("CID_CODIGO");
            Map(x => x.IdUsuario).ToColumn("USU_CODIGO");

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("ANU_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("ANU_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
