using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity;

namespace PetSaver.Repository
{
    public class AnimalMap : DommelEntityMap<AnimalEntity>
    {
        public AnimalMap()
        {
            ToTable("ANI_ANIMAIS");

            Map(x => x.Id).ToColumn("ANI_CODIGO").IsKey().IsIdentity();

            #region .: Atributos :.

            Map(x => x.Nome).ToColumn("ANI_NOME");

            #endregion

            #region .: Foreign Keys :.

            Map(x => x.IdTipo).ToColumn("ATP_CODIGO");

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("ANI_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("ANI_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
