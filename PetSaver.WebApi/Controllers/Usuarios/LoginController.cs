using PetSaver.Business.Usuarios;
using PetSaver.Entity.Usuarios;
using System;
using System.Collections.Generic;
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
    }
}
