using PetSaver.Business.Anuncios;
using PetSaver.Contracts.Anuncios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetSaver.WebApi.Controllers.Anuncios
{
    public class AnuncioController : BaseController
    {
        [Authorize]
        [Route("api/Anuncio/CadastrarInteresse")]
        [HttpPost]
        public HttpResponseMessage CadastrarInteresse([FromBody]CadastrarInteresseRequest aRequest)
        {
            try
            {
                new InteresseBusiness().Cadastrar(aRequest);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
