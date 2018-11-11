using PetSaver.Business.Anuncios;
using PetSaver.Business.Localizacao;
using PetSaver.Business.Pets;
using PetSaver.Contracts.Anuncios;
using PetSaver.Contracts.Paginas;
using PetSaver.Exceptions;

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

        public AnunciosPageResponse InicializarAnuncios(FiltroAnuncioRequest aFiltro)
        {
            FiltroAnuncioRequest filtro;

            if (aFiltro == null)
            {
                filtro = new FiltroAnuncioRequest();
            }
            else
            {
                filtro = aFiltro;
            }

            if (filtro.Quantidade == default)
            {
                filtro.Quantidade = 16;
            }

            filtro.Pagina = 1;

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
