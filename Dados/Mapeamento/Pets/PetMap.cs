using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Pets;

namespace PetSaver.Repository
{
    public class PetMap : DommelEntityMap<PetEntity>
    {
        public PetMap()
        {
            ToTable("PET_PETS");

            Map(x => x.Id).ToColumn("PET_CODIGO").IsKey().IsIdentity();

            Map(x => x.Nome).ToColumn("PET_NOME");
            Map(x => x.Peso).ToColumn("PET_PESO");
            Map(x => x.Vacinado).ToColumn("PET_VACINADO");
            Map(x => x.Vermifugado).ToColumn("PET_VERMIFUGADO");
            Map(x => x.Castrado).ToColumn("PET_CASTRADO");
            Map(x => x.Descricao).ToColumn("PET_DESCRICAO");

            #region .: Foreign Keys :.

            Map(x => x.IdAnimal).ToColumn("ANI_CODIGO");
            Map(x => x.IdRacaEspecie).ToColumn("RAC_CODIGO");
            Map(x => x.IdSexo).ToColumn("PTS_CODIGO");
            Map(x => x.IdIdade).ToColumn("PID_CODIGO");
            Map(x => x.IdPorte).ToColumn("PPR_CODIGO");
            Map(x => x.IdPelo).ToColumn("PPL_CODIGO");
            Map(x => x.IdCorPrimaria).ToColumn("COR_PRIMARIA");
            Map(x => x.IdCorSecundaria).ToColumn("COR_SECUNDARIA");

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("PET_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("PET_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
