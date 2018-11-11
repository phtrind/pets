using PetSaver.Business.Usuarios;
using PetSaver.Contracts.Usuario;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetSaver.WebApi.Controllers.Usuarios
{
    [Authorize]
    public class UsuarioController : BaseController
    {
        [Authorize]
        [Route("api/Usuario/CadastrarBasico")]
        [HttpPost]
        public HttpResponseMessage CadastrarBasico([FromBody]CadastroBasicoRequest value)
        {
            try
            {
                new UsuarioBusiness().CadastrarBasico(value);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [Authorize]
        [Route("api/Usuario/InformacoesSession/{aEmail}")]
        [HttpGet]
        public UsuarioSessionContract InformacoesSession(string aEmail)
        {
            try
            {
                return new UsuarioBusiness().BuscarInformacoesSession(aEmail);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }
    }
}
