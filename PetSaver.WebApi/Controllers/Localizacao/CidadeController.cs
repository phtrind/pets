using PetSaver.Business.Localizacao;
using PetSaver.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetSaver.WebApi.Controllers.Localizacao
{
    public class CidadeController : BaseController
    {
        [Route("api/Cidade/Combo/{aIdEstado}")]
        [HttpGet]
        public IEnumerable<ChaveValorContract> Get(int aIdEstado)
        {
            try
            {
                return new CidadeBusiness().Combo(aIdEstado);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }
    }
}
