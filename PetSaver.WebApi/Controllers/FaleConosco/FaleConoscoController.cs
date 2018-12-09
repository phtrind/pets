using PetSaver.Business.Contato;
using PetSaver.Contracts.FaleConosco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetSaver.WebApi.Controllers
{
    public class FaleConoscoController : BaseController
    {
        [Route("api/FaleConosco")]
        [HttpPost]
        public HttpResponseMessage Cadastrar([FromBody]CadastrarFaleConoscoRequest aRequest)
        {
            try
            {
                new FaleConoscoBusiness().Cadastrar(aRequest);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
