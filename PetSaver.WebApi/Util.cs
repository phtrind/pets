using PetSaver.Exceptions;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetSaver.WebApi
{
    public static class Util
    {
        public static HttpResponseException TratarErro(Exception ex)
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
                    Content = new StringContent(Exceptions.Util.MensagemErroNaoTratado)
                };

                //Mandar erro pro bugsnag
            }

            return new HttpResponseException(erro);
        }
    }
}