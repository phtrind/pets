using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Anuncios;

namespace PetSaver.Repository
{
    public class DuvidaMap : DommelEntityMap<DuvidaEntity>
    {
        public DuvidaMap()
        {
            ToTable("DUV_DUVIDAS");

            Map(x => x.Id).ToColumn("DUV_CODIGO").IsKey().IsIdentity();

            #region .: Atributos :.

            Map(x => x.Pergunta).ToColumn("DUV_PERGUNTA");
            Map(x => x.Resposta).ToColumn("DUV_RESPOSTA");
            Map(x => x.DataHoraResposta).ToColumn("DUV_DTHRESPOSTA");

            #endregion

            #region .: Foreign Keys :.

            Map(x => x.IdUsuario).ToColumn("USU_CODIGO");
            Map(x => x.IdAnuncio).ToColumn("ANU_CODIGO");

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("DUV_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("DUV_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
