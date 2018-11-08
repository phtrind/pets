using PetSaver.Business;
using PetSaver.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetSaver.WebApi.Controllers
{
    [Authorize]
    public class PageController : BaseController
    {
        // GET: api/Page/5
        [Route("api/Page/{aNomePagina}")]
        [HttpGet]
        public BasePageContract Get(string aNomePagina)
        {
            try
            {
                return new PageBusiness().Inicializar(aNomePagina);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }
    }
}
