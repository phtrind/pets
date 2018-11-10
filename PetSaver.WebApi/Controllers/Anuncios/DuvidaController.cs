using PetSaver.Business.Anuncios;
using PetSaver.Contracts.Anuncios;
using System;
using System.Net.Http;
using System.Web.Http;

namespace PetSaver.WebApi.Controllers.Anuncios
{
    public class DuvidaController : BaseController
    {
        [Authorize]
        [Route("api/Duvida/Cadastrar")]
        [HttpPost]
        public HttpResponseMessage Cadastrar([FromBody]CadastrarDuvidaRequest aRequest)
        {
            try
            {
                new DuvidaBusiness().Cadastrar(aRequest);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
    }
}
