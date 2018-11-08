using Bugsnag.AspNet.WebApi;
using PetSaver.Exceptions;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetSaver.WebApi.Controllers
{
    public class BaseController : ApiController
    {
        public HttpResponseException TratarErro(Exception ex)
        {
            HttpResponseMessage erro;

            if (ex is HandledException)
            {
                erro = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.Message)
                };
            }
            else
            {
                erro = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(Util.MensagemErroNaoTratado)
                };

                Request.Bugsnag().Notify(ex);
            }

            return new HttpResponseException(erro);
        }
    }
}