using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Pets;

namespace PetSaver.Repository
{
    public class RacaEspecieMap : DommelEntityMap<RacaEspecieEntity>
    {
        public RacaEspecieMap()
        {
            ToTable("RAC_RACASESPECIES");

            Map(x => x.Id).ToColumn("RAC_CODIGO").IsKey().IsIdentity();

            #region .: Atributos :.

            Map(x => x.Nome).ToColumn("RAC_NOME");

            #endregion

            #region .: Foreign Keys :.

            Map(x => x.IdAnimal).ToColumn("ANI_CODIGO");

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("RAC_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("RAC_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
