using PetSaver.Business.Usuarios;
using PetSaver.Contracts.Usuario;
using System;
using System.Web.Http;

namespace PetSaver.WebApi.Controllers.Usuarios
{
    [Authorize]
    public class UsuarioController : BaseController
    {
        [Authorize]
        [Route("api/Usuario/CadastrarBasico")]
        [HttpPost]
        public void CadastrarBasico([FromBody]CadastroBasicoRequest value)
        {
            try
            {
                new UsuarioBusiness().CadastrarBasico(value);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }
    }
}
