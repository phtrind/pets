using PetSaver.Business.Usuarios;
using PetSaver.Entity.Usuarios;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PetSaver.WebApi.Controllers.Usuarios
{
    public class LoginController : BaseController
    {
        [Route("api/Login/VerificarEmailExistente/{aEmail}")]
        [HttpGet]
        public bool VerificarEmailExistente(string aEmail)
        {
            try
            {
                return new LoginBusiness().VerificarEmailExistente(aEmail);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        [Route("api/Login/EsqueceuSenha/{aEmail}")]
        [HttpGet]
        public async Task<HttpResponseMessage> EsqueceuSenhaAsync(string aEmail)
        {
            try
            {
                await new LoginBusiness().EsqueceuSenhaAsync(aEmail);

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }
    }
}
