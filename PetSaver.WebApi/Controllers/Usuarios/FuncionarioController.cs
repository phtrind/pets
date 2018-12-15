using PetSaver.Business.Usuarios;
using PetSaver.Contracts.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetSaver.WebApi.Controllers.Usuarios
{
    [Authorize]
    public class FuncionarioController : BaseController
    {
        [Route("api/Funcionario/Verificar/{aEmail}")]
        [HttpGet]
        public VerificarFuncionarioReponse Verificar(string aEmail)
        {
            try
            {
                return new FuncionarioBusiness().Verificar(aEmail);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }
    }
}
