using Dapper.FluentMap.Dommel.Mapping;
using PetSaver.Entity.Localizacao;

namespace PetSaver.Repository
{
    public class EnderecoMap : DommelEntityMap<EnderecoEntity>
    {
        public EnderecoMap()
        {
            ToTable("END_ENDERECOS");

            Map(x => x.Id).ToColumn("END_CODIGO").IsKey().IsIdentity();

            Map(x => x.Logradouro).ToColumn("END_LOGRADOURO");
            Map(x => x.Numero).ToColumn("END_NUMERO");
            Map(x => x.Complemento).ToColumn("END_COMPLEMENTO");
            Map(x => x.Bairro).ToColumn("END_BAIRRO");
            Map(x => x.Cep).ToColumn("END_CEP");

            #region .: Foreign Keys :.

            Map(x => x.IdEstado).ToColumn("EST_CODIGO");
            Map(x => x.IdCidade).ToColumn("CID_CODIGO");

            #endregion

            #region .: Controle de Alteração :.

            Map(x => x.DataCadastro).ToColumn("END_DTHCADASTRO");
            Map(x => x.DataAlteracao).ToColumn("END_DTHALTERACAO");
            Map(x => x.IdLoginCadastro).ToColumn("LOG_CADASTRO");
            Map(x => x.IdLoginAlteracao).ToColumn("LOG_ALTERACAO");

            #endregion
        }
    }
}
