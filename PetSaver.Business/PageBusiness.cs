using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetSaver.Business.Anuncios;
using PetSaver.Contracts.Anuncios;
using PetSaver.Contracts.Base;
using PetSaver.Contracts.Paginas;
using PetSaver.Exceptions;

namespace PetSaver.Business
{
    public class PageBusiness
    {
        public BasePageContract Inicializar(string aNomePagina)
        {
            if (Enum.TryParse(aNomePagina, true, out Paginas pagina))
            {
                switch (pagina)
                {
                    case Paginas.Home:
                        return Home();
                    case Paginas.Busca:
                        return Busca();
                    case Paginas.Anuncio:
                        return Anuncio();
                    case Paginas.Dashboard:
                        return Dashboard();
                    case Paginas.CadastroDoacao:
                        return CadastroDoacao();
                    case Paginas.RelatorioDoacoes:
                        return RelatorioDoacoes();
                    case Paginas.Favoritos:
                        return Favoritos();
                    case Paginas.RelatorioAdocoes:
                        return RelatorioAdocoes();
                    case Paginas.CadastroPetPerdido:
                        return CadastroPetPerdido();
                    case Paginas.CadastroPetEncontrado:
                        return CadastroPetEncontrado();
                    default:
                        throw new BusinessException("Página não encontrada");
                }
            }
            else
            {
                throw new BusinessException("Página não encontrada");
            }
        }

        private HomeContract Home()
        {
            return new HomeContract() // Pendente de finalizar
            {
                Anuncios = new AnuncioBusiness().ListarDestaquesMiniatura()
            };
        }

        private BuscaContract Busca()
        {
            throw new NotImplementedException();
        }

        private AnuncioContract Anuncio()
        {
            throw new NotImplementedException();
        }

        private DashboardContract Dashboard()
        {
            throw new NotImplementedException();
        }

        private CadastroDoacaoContract CadastroDoacao()
        {
            throw new NotImplementedException();
        }

        private RelatorioDoacoesContract RelatorioDoacoes()
        {
            throw new NotImplementedException();
        }

        private FavoritosContract Favoritos()
        {
            throw new NotImplementedException();
        }

        private RelatorioAdocoesContract RelatorioAdocoes()
        {
            throw new NotImplementedException();
        }

        private CadastroPetPerdidoContract CadastroPetPerdido()
        {
            throw new NotImplementedException();
        }

        private CadastroPetEncontradoContract CadastroPetEncontrado()
        {
            throw new NotImplementedException();
        }
    }
}
