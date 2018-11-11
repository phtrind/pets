using PetSaver.Business.Anuncios;
using PetSaver.Contracts.Anuncios;
using PetSaver.Contracts.Paginas.Response.PetPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetSaver.WebApi.Controllers.Anuncios
{
    public class AnuncioController : BaseController
    {
        #region .: Cadastro :.

        [Authorize]
        [Route("api/Anuncio/CadastrarInteresse")]
        [HttpPost]
        public HttpResponseMessage CadastrarInteresse([FromBody]CadastrarInteresseRequest aRequest)
        {
            try
            {
                new InteresseBusiness().Cadastrar(aRequest);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [Authorize]
        [Route("api/Anuncio/CadastrarDuvida")]
        [HttpPost]
        public HttpResponseMessage CadastrarDuvida([FromBody]CadastrarDuvidaRequest aRequest)
        {
            try
            {
                new DuvidaBusiness().Cadastrar(aRequest);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [Authorize]
        [Route("api/Anuncio/CadastrarGostei")]
        [HttpPost]
        public HttpResponseMessage CadastrarGostei([FromBody]CadastrarGosteiRequest aRequest)
        {
            try
            {
                new AnuncioGosteiBusiness().Cadastrar(aRequest);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [Authorize]
        [Route("api/Anuncio/RemoverGostei")]
        [HttpPost]
        public HttpResponseMessage RemoverGostei([FromBody]CadastrarGosteiRequest aRequest)
        {
            try
            {
                new AnuncioGosteiBusiness().Remover(aRequest);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        #endregion

        #region .: Busca :.

        [Route("api/Anuncio/BuscarDuvidas/{aIdAnuncio}")]
        [HttpGet]
        public IEnumerable<DuvidaContract> BuscarDuvidas(int aIdAnuncio)
        {
            try
            {
                return new DuvidaBusiness().BuscarPorAnuncio(aIdAnuncio);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        } 

        #endregion
    }
}
