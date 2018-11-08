using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Localizacao;

namespace PetSaver.Repository
{
    public class EstadoMap : DommelEntityMap<EstadoEntity>
    {
        public EstadoMap()
        {
            ToTable("EST_ESTADOS");

            Map(x => x.Id).ToColumn("EST_CODIGO").IsKey().IsIdentity();

            Map(x => x.Sigla).ToColumn("EST_SIGLA");
            Map(x => x.Nome).ToColumn("EST_NOME");

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("EST_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("EST_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
