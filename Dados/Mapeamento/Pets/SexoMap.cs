using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Pets;

namespace PetSaver.Repository
{
    public class SexoMap : DommelEntityMap<SexoEntity>
    {
        public SexoMap()
        {
            ToTable("PTS_PETSEXOS");

            Map(x => x.Id).ToColumn("PTS_CODIGO").IsKey().IsIdentity();

            #region .: Atributos :.

            Map(x => x.Descricao).ToColumn("PTS_DESCRICAO"); 

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("PTS_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("PTS_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");
        }

        #endregion
    }
}
