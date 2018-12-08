using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Chat;

namespace PetSaver.Repository
{
    public class InboxMap : DommelEntityMap<InboxEntity>
    {
        public InboxMap()
        {
            ToTable("INB_INBOX");

            Map(x => x.Id).ToColumn("INB_CODIGO").IsKey().IsIdentity();

            #region .: Foreign Keys :.

            Map(x => x.IdInteresse).ToColumn("INT_CODIGO");
            Map(x => x.IdRemetente).ToColumn("USU_REMETENTE");
            Map(x => x.IdDestinatário).ToColumn("USU_DESTINATARIO");

            #endregion

            #region .: Atributos :.

            Map(x => x.Mensagem).ToColumn("INB_MENSAGEM");
            Map(x => x.FoiLida).ToColumn("INB_LIDA");

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("INB_DTHCADASTRO");
            Map(x => x.IdLoginCadastro).Ignore();
            Map(x => x.IdLoginAlteracao).Ignore();
            Map(x => x.DataAlteracao).Ignore();

            #endregion
        }
    }
}
