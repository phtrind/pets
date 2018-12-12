using PetSaver.Business.Usuarios;
using PetSaver.Contracts.Usuario;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetSaver.WebApi.Controllers.Usuarios
{
    public class UsuarioController : BaseController
    {
        #region .: Cadastro :.

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

        #endregion

        #region .: Buscas :.

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

        [Authorize]
        [Route("api/Usuario/Completo/{aIdUsuario}")]
        [HttpGet]
        public UsuarioCompletoResponse Completo(int aIdUsuario)
        {
            try
            {
                return new UsuarioBusiness().BuscarCompleto(aIdUsuario);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        } 

        #endregion
    }
}
