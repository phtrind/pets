using PetSaver.Business.Chat;
using PetSaver.Contracts.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetSaver.WebApi.Controllers.Chat
{
    public class InboxController : BaseController
    {
        #region .: Cadastro :.

        [Authorize]
        [Route("api/Inbox")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]CadastroInboxRequest aRequest)
        {
            try
            {
                new InboxBusiness().NovaMensagem(aRequest);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        #endregion

        #region .: Buscas :.

        [Authorize]
        [Route("api/Inbox/BuscarTodas")]
        [HttpPost]
        public IEnumerable<InboxResponseContract> BuscarTodas([FromBody]BuscarInboxRequest aRequest)
        {
            try
            {
                return new InboxBusiness().BuscarTodasMensagens(aRequest.IdInteresse, aRequest.IdUsuario);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        #endregion
    }
}
