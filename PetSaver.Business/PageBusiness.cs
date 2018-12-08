using PetSaver.Business.Anuncios;
using PetSaver.Business.Chat;
using PetSaver.Business.Localizacao;
using PetSaver.Business.Pets;
using PetSaver.Business.Usuarios;
using PetSaver.Contracts.Anuncios;
using PetSaver.Contracts.Anuncios.Response;
using PetSaver.Contracts.Base;
using PetSaver.Contracts.Paginas;
using PetSaver.Entity.Enums.Status;
using PetSaver.Entity.Enums.Tipos;
using PetSaver.Exceptions;
using System;
using System.Collections.Generic;

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

        public RelatorioAnunciosResponse InicializarRelatorioAnuncios(RelatorioAnunciosRequest aRequest, TiposAnuncio? aTipoAnuncio)
        {
            return new RelatorioAnunciosResponse()
            {
                Filtros = new FiltroRelatorioAnunciosResponse()
                {
                    Animais = new AnimalBusiness().Combo(),
                    Status = new AnuncioStatusBusiness().Combo(),
                    TiposAnuncio = new AnuncioBusiness().ComboTiposAnuncios()
                },
                Anuncios = new AnuncioBusiness().ListarRelatorioAnuncios(aRequest, aTipoAnuncio)
            };
        }

        public RelatorioInteressesPageResponse InicializarMeusInteresses(int aIdUsuario)
        {
            var request = new RelatorioInteressesRequest()
            {
                IdUsuario = aIdUsuario
            };

            return new RelatorioInteressesPageResponse()
            {
                Filtros = new FiltroRelatorioInteressesResponse()
                {
                    Animais = new AnimalBusiness().Combo(),
                    TiposAnuncio = new AnuncioBusiness().ComboTiposAnuncios()
                },
                Interesses = new InteresseBusiness().BuscarRelatorioInteresses(request)
            };
        }

        public ChatPageResponse InicializarChat(ChatPageRequest aRequest)
        {
            if (aRequest.IdUsuario == default)
            {
                throw new BusinessException("O Id do usuário é inválido.");
            }

            if (aRequest.IdInteresse == default)
            {
                throw new BusinessException("O Id do interesse é inválido.");
            }

            var interesseEntity = new InteresseBusiness().Listar(aRequest.IdInteresse);

            if (interesseEntity == null)
            {
                throw new BusinessException("O Id do interesse é inválido.");
            }

            var anuncioEntity = new AnuncioBusiness().Listar(interesseEntity.IdAnuncio);

            if (anuncioEntity == null)
            {
                throw new BusinessException("O anúncio não foi encontrado.");
            }

            string nomeUsuario;

            var usuarioBusiness = new UsuarioBusiness();

            if (aRequest.IdUsuario == interesseEntity.IdUsuario)
            {
                nomeUsuario = usuarioBusiness.Listar(anuncioEntity.IdUsuario)?.Nome;
            }
            else if (aRequest.IdUsuario == anuncioEntity.IdUsuario)
            {
                nomeUsuario = usuarioBusiness.Listar(interesseEntity.IdUsuario)?.Nome;
            }
            else
            {
                throw new BusinessException("O Id do usuário informado não é referente à esse chat.");
            }

            return new ChatPageResponse()
            {
                IdAnuncio = anuncioEntity.Id,
                IdInteresse = interesseEntity.Id,
                Imagem = new AnuncioFotoBusiness().BuscarCaminhoFotoDestaquePorAnuncio(anuncioEntity.Id),
                Pet = new PetBusiness().Listar(anuncioEntity.IdPet)?.Nome ?? Utilities.Constantes.Desconhecido,
                Usuario = nomeUsuario,
                Mensagens = new InboxBusiness().BuscarTodasMensagens(aRequest.IdInteresse, aRequest.IdUsuario)
            };
        }

        public DashboardPageResponse InicializarDashboard(int aIdUsuario)
        {
            return new DashboardPageResponse()
            {
                QuantidadeAnuncios = new AnuncioBusiness().QuantidadeAnunciosUsuario(aIdUsuario),
                QuantidadeFavoritos = new AnuncioBusiness().QuantidadeFavoritosUsuario(aIdUsuario),
                QuantidadeInteracoes = new InteresseBusiness().QuantidadeInteracoesUsuario(aIdUsuario)
            };
        }

        #endregion
    }
}
