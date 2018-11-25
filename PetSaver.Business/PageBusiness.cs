using PetSaver.Business.Anuncios;
using PetSaver.Business.Localizacao;
using PetSaver.Business.Pets;
using PetSaver.Contracts.Anuncios;
using PetSaver.Contracts.Paginas;
using PetSaver.Entity.Enums.Status;
using PetSaver.Exceptions;

namespace PetSaver.Business
{
    public class PageBusiness
    {
        #region .: Comuns :.

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

            filtro.IdStatus = Utilities.Conversor.EnumParaInt(StatusAnuncio.Ativo);

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
                Animais = new AnimalBusiness().Combo(),
                Sexos = new SexoBusiness().Combo(),
                Pelos = new PeloBusiness().Combo(),
                Idades = new IdadeBusiness().Combo(),
                Cores = new CorBusiness().Combo(),
                Portes = new PorteBusiness().Combo()
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

        #endregion

        #region .: Conta :.

        public CadastroAnuncioPageResponse InicializarCadastroAnuncio()
        {
            return new CadastroAnuncioPageResponse()
            {
                Animais = new AnimalBusiness().Combo(),
                Sexos = new SexoBusiness().Combo(),
                Idades = new IdadeBusiness().Combo(),
                Portes = new PorteBusiness().Combo(),
                Pelos = new PeloBusiness().Combo(),
                Cores = new CorBusiness().Combo(),
                Estados = new EstadoBusiness().Combo()
            };
        }

        public RelatorioDoacoesResponse InicializarRelatorioDoacoes(RelatorioDoacoesRequest aRequest)
        {
            return new RelatorioDoacoesResponse()
            {
                Filtros = new FiltroRelatorioDoacoesResponse()
                {
                    Animais = new AnimalBusiness().Combo(),
                    Status = new AnuncioStatusBusiness().Combo()
                },
                Anuncios = new AnuncioBusiness().ListarRelatorioDoacoes(aRequest.IdUsuario, aRequest.Filtro)
            };
        }

        #endregion
    }
}
