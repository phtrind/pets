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
        [Route("api/Inbox/NovaMensagem")]
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

        //[Authorize]
        //[Route("api/Inbox/NaoLidas")]
        //[HttpGet]
        //public HttpResponseMessage Post([FromBody]CadastroInboxRequest aRequest)
        //{
        //    try
        //    {
        //        new InboxBusiness().NovaMensagem(aRequest);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw TratarErro(ex);
        //    }

        //    return new HttpResponseMessage(HttpStatusCode.OK);
        //}

        #endregion
    }
}
