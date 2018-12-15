﻿using PetSaver.Business.Anuncios;
using PetSaver.Contracts.Anuncios;
using PetSaver.Contracts.Base;
using PetSaver.Contracts.Paginas.Response.PetPage;
using PetSaver.Entity.Enums.Tipos;
using System;
using System.Collections.Generic;
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
        public int CadastrarInteresse([FromBody]CadastrarInteresseRequest aRequest)
        {
            try
            {
                return new InteresseBusiness().Cadastrar(aRequest);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
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
        [Route("api/Anuncio/CadastrarResposta")]
        [HttpPost]
        public HttpResponseMessage CadastrarResposta([FromBody]CadastrarRespostaRequest aRequest)
        {
            try
            {
                new DuvidaBusiness().CadastrarResposta(aRequest);
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

        [Authorize]
        [Route("api/Anuncio/CadastrarDoacao")]
        [HttpPost]
        public int CadastrarDoacao([FromBody]CadastrarPetAnuncioRequest aRequest)
        {
            try
            {
                return new AnuncioBusiness().Cadastrar(aRequest, TiposAnuncio.Doacao);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        [Authorize]
        [Route("api/Anuncio/CadastrarPetPerdido")]
        [HttpPost]
        public int CadastrarPetPerdido([FromBody]CadastrarPetAnuncioRequest aRequest)
        {
            try
            {
                return new AnuncioBusiness().Cadastrar(aRequest, TiposAnuncio.PetPerdido);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        [Authorize]
        [Route("api/Anuncio/CadastrarPetEncontrado")]
        [HttpPost]
        public int CadastrarPetEncontrado([FromBody]CadastrarPetAnuncioRequest aRequest)
        {
            try
            {
                return new AnuncioBusiness().Cadastrar(aRequest, TiposAnuncio.PetEncontrado);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        [Authorize]
        [Route("api/Anuncio/AlterarFotoDestaque/{aIdFoto}")]
        [HttpPost]
        public HttpResponseMessage AlterarFotoDestaque(int aIdFoto)
        {
            try
            {
                new AnuncioFotoBusiness().AlterarFotoDestaque(aIdFoto);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [Authorize]
        [Route("api/Anuncio/CancelarInteresse")]
        [HttpPost]
        public HttpResponseMessage CancelarInteresse(CancelarInteresseRequest aRequest)
        {
            try
            {
                new InteresseBusiness().CancelarInteresse(aRequest);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [Authorize]
        [Route("api/Anuncio/ConcretizarInteresse")]
        [HttpPost]
        public HttpResponseMessage ConcretizarInteresse(ConcretizarInteresseRequest aRequest)
        {
            try
            {
                new InteresseBusiness().ConcretizarInteresse(aRequest);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [Authorize]
        [Route("api/Anuncio/FinalizarAnuncio")]
        [HttpPost]
        public HttpResponseMessage FinalizarAnuncio(FinalizarAnuncioRequest aRequest)
        {
            try
            {
                new AnuncioBusiness().FinalizarAnuncio(aRequest);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [Authorize]
        [Route("api/Anuncio/AtivarAnuncio")]
        [HttpPost]
        public HttpResponseMessage AtivarAnuncio(AtivarAnuncioRequest aRequest)
        {
            try
            {
                new AnuncioBusiness().AtivarAnuncio(aRequest);
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

        [Route("api/Anuncio/BuscarFotos/{aIdAnuncio}")]
        [HttpGet]
        public IEnumerable<ChaveValorContract> BuscarFotos(int aIdAnuncio)
        {
            try
            {
                return new AnuncioFotoBusiness().BuscarPorAnuncio(aIdAnuncio);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        [Route("api/Anuncio/BuscarAnuncios")]
        [HttpPost]
        public IEnumerable<AnuncioMiniaturaResponse> BuscarAnuncios(FiltroAnuncioRequest aFiltro)
        {
            try
            {
                return new AnuncioBusiness().ListarMiniaturas(aFiltro);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        [Authorize]
        [Route("api/Anuncio/RelatorioDoacoes")]
        [HttpPost]
        public IEnumerable<RelatorioAnunciosContract> RelatorioDoacoes(RelatorioAnunciosRequest aRequest)
        {
            try
            {
                return new AnuncioBusiness().ListarRelatorioAnuncios(aRequest, TiposAnuncio.Doacao);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        [Authorize]
        [Route("api/Anuncio/RelatorioPetPerdido")]
        [HttpPost]
        public IEnumerable<RelatorioAnunciosContract> RelatorioPetPerdido(RelatorioAnunciosRequest aRequest)
        {
            try
            {
                return new AnuncioBusiness().ListarRelatorioAnuncios(aRequest, TiposAnuncio.PetPerdido);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        [Authorize]
        [Route("api/Anuncio/RelatorioPetEncontrado")]
        [HttpPost]
        public IEnumerable<RelatorioAnunciosContract> RelatorioPetEncontrado(RelatorioAnunciosRequest aRequest)
        {
            try
            {
                return new AnuncioBusiness().ListarRelatorioAnuncios(aRequest, TiposAnuncio.PetEncontrado);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        [Authorize]
        [Route("api/Anuncio/RelatorioAnuncios")]
        [HttpPost]
        public IEnumerable<RelatorioAnunciosContract> RelatorioAnuncios(RelatorioAnunciosRequest aRequest)
        {
            try
            {
                return new AnuncioBusiness().ListarRelatorioAnuncios(aRequest, null);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        [Authorize]
        [Route("api/Anuncio/RelatorioInteresses")]
        [HttpPost]
        public IEnumerable<RelatorioInteressesContract> RelatorioInteresses(RelatorioInteressesRequest aRequest)
        {
            try
            {
                return new InteresseBusiness().BuscarRelatorioInteresses(aRequest);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        [Authorize]
        [Route("api/Anuncio/BuscarInteressados/{aIdAnuncio}")]
        [HttpGet]
        public IEnumerable<InteressadosContract> BuscarInteressados(int aIdAnuncio)
        {
            try
            {
                return new InteresseBusiness().BuscarInteressados(aIdAnuncio);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        [Authorize]
        [Route("api/Anuncio/DetalharAnuncioAprovacao/{aIdAnuncio}")]
        [HttpGet]
        public DetalharAnuncioAprovacaoContract DetalharAnuncioAprovacao(int aIdAnuncio)
        {
            try
            {
                return new AnuncioBusiness().DetalharAnuncioAprovacao(aIdAnuncio);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        #endregion
    }
}
