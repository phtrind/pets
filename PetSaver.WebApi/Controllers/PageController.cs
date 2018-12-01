using PetSaver.Business;
using PetSaver.Business.Anuncios;
using PetSaver.Contracts.Anuncios;
using PetSaver.Contracts.Base;
using PetSaver.Contracts.Paginas;
using PetSaver.Entity.Enums.Tipos;
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
        #region .: Comuns :.

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

        [Route("api/Page/Anuncios")]
        [HttpPost]
        public AnunciosPageResponse Anuncios([FromBody]FiltroAnuncioRequest aRequest)
        {
            try
            {
                return new PageBusiness().InicializarAnuncios(aRequest);
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

        #endregion

        #region .: Conta :.

        [Authorize]
        [Route("api/Page/CadastroAnuncio")]
        [HttpGet]
        public CadastroAnuncioPageResponse CadastroAnuncio()
        {
            try
            {
                return new PageBusiness().InicializarCadastroAnuncio();
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        [Authorize]
        [Route("api/Page/RelatorioDoacoes")]
        [HttpPost]
        public RelatorioAnunciosResponse RelatorioDoacoes(RelatorioAnunciosRequest aRequest)
        {
            try
            {
                return new PageBusiness().InicializarRelatorioAnuncios(aRequest, TiposAnuncio.Doacao);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        [Authorize]
        [Route("api/Page/RelatorioPetPerdido")]
        [HttpPost]
        public RelatorioAnunciosResponse RelatorioPetPerdido(RelatorioAnunciosRequest aRequest)
        {
            try
            {
                return new PageBusiness().InicializarRelatorioAnuncios(aRequest, TiposAnuncio.PetPerdido);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        [Authorize]
        [Route("api/Page/RelatorioPetEncontrado")]
        [HttpPost]
        public RelatorioAnunciosResponse RelatorioPetEncontrado(RelatorioAnunciosRequest aRequest)
        {
            try
            {
                return new PageBusiness().InicializarRelatorioAnuncios(aRequest, TiposAnuncio.PetEncontrado);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        [Authorize]
        [Route("api/Page/Favoritos/{aIdUsuario}")]
        [HttpGet]
        public IEnumerable<AnuncioMiniaturaResponse> Favoritos(int aIdUsuario)
        {
            try
            {
                return new AnuncioBusiness().BuscarFavoritos(aIdUsuario);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        #endregion
    }
}
