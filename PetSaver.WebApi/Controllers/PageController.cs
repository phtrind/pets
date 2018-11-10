using PetSaver.Business;
using PetSaver.Contracts.Anuncios;
using PetSaver.Contracts.Base;
using PetSaver.Contracts.Paginas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetSaver.WebApi.Controllers
{
    public class PageController : BaseController
    {
        [Route("api/Page/Home")]
        [HttpGet]
        public HomePageResponse Home()
        {
            try
            {
                return new PageBusiness().InicializarHomePage();
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        [Route("api/Page/Anuncios/{aQuantidade}")]
        [HttpGet]
        public AnunciosPageResponse Anuncios(int aQuantidade)
        {
            try
            {
                return new PageBusiness().InicializarAnuncios(aQuantidade);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        [Route("api/Page/Pet")]
        [HttpPost]
        public PetPageResponse Pet([FromBody]PetPageRequest aRequest)
        {
            try
            {
                return new PageBusiness().InicializarPet(aRequest);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }
    }
}
