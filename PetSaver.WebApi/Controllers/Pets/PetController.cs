using PetSaver.Business.Pets;
using PetSaver.Contracts.Base;
using PetSaver.Entity.Pets;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace PetSaver.WebApi.Controllers.Pets
{
    [Authorize]
    public class PetController : BaseController
    {
        #region .: Busca :.

        [Route("api/Anuncio/BuscarRacaEspeciePorAnimal/{aIdAnimal}")]
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
