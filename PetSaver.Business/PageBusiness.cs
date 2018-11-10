using PetSaver.Business.Anuncios;
using PetSaver.Business.Localizacao;
using PetSaver.Business.Pets;
using PetSaver.Contracts.Anuncios;
using PetSaver.Contracts.Base;
using PetSaver.Contracts.Paginas;
using PetSaver.Entity.Anuncios;
using PetSaver.Exceptions;
using System;

namespace PetSaver.Business
{
    public class PageBusiness
    {
        public HomePageResponse InicializarHomePage()
        {
            return new HomePageResponse()
            {
                Anuncios = new AnuncioBusiness().ListarDestaquesMiniaturas(),
                Filtros = InicializarFiltros()
            };
        }

        public AnunciosPageResponse InicializarAnuncios(int aQuantidade)
        {
            var filtro = new FiltroAnuncioRequest()
            {
                Quantidade = aQuantidade,
                Pagina = 1
            };

            return new AnunciosPageResponse()
            {
                Anuncios = new AnuncioBusiness().ListarMiniaturas(filtro),
                Filtros = InicializarFiltros()
            };
        }

        private FiltroAnuncioResponse InicializarFiltros()
        {
            return new FiltroAnuncioResponse()
            {
                Estados = new EstadoBusiness().Combo(),
                Sexos = new SexoBusiness().Combo(),
                Animais = new AnimalBusiness().Combo()
            };
        }

        public PetPageResponse InicializarPet(PetPageRequest aRequest)
        {
            if (aRequest == null)
            {
                throw new BusinessException("O objeto de request está nulo.");
            }

            return new AnuncioBusiness().AbrirAnuncio(aRequest.IdAnuncio, aRequest.IdUsuario);
        }
    }
}
