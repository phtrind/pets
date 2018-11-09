using PetSaver.Business.Anuncios;
using PetSaver.Business.Localizacao;
using PetSaver.Business.Pets;
using PetSaver.Contracts.Anuncios;
using PetSaver.Contracts.Paginas;

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
    }
}
