using PetSaver.Business.Pets;
using PetSaver.Contracts.Base;
using PetSaver.Contracts.Pets;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace PetSaver.WebApi.Controllers.Pets
{
    public class PetController : BaseController
    {
        #region .: Busca :.

        [Route("api/Pet/BuscarRacaEspeciePorAnimal/{aIdAnimal}")]
        [HttpGet]
        public IEnumerable<ChaveValorContract> BuscarRacaEspeciePorAnimal(int aIdAnimal)
        {
            try
            {
                return new RacaEspecieBusiness().BuscarPorAnimal(aIdAnimal);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        #endregion
    }
}
