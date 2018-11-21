using PetSaver.Contracts.Base;
using PetSaver.Contracts.Paginas.Response.PetPage;
using PetSaver.Entity.Anuncios;
using PetSaver.Exceptions;
using PetSaver.Repository.Anuncios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace PetSaver.Business.Anuncios
{
    public class AnuncioFotoBusiness : BaseBusiness<AnuncioFotoEntity, AnuncioFotoRepository>
    {
        #region .: Cadastros :.

        public void Cadastrar(int aIdAnuncio, int aIdLoginCadastro, string aGuidAnuncio)
        {
            if (string.IsNullOrEmpty(aGuidAnuncio))
            {
                throw new BusinessException("O guid do anúncio é invalido.");
            }

            var rootPath = ConfigurationManager.AppSettings[Utilities.Constantes.PathFotosAnuncios] ?? string.Empty;

            if (string.IsNullOrEmpty(rootPath))
            {
                throw new BusinessException("O endereço do diretório raiz das fotos nos anúncios não está definido no config.");
            }

            var pastaAnuncio = $"{rootPath}/{aGuidAnuncio}";

            if (!Directory.Exists(pastaAnuncio))
            {
                throw new BusinessException("O diretório desse anúncio não existe");
            }

            var pathImagens = Directory.GetFiles(pastaAnuncio);

            if (!pathImagens.Any())
            {
                throw new BusinessException("Não existe nenhuma imagem no diretório de imagens desse anúncio.");
            }

            var cont = 0;

            foreach (var pathImagem in pathImagens)
            {
                Inserir(new AnuncioFotoEntity()
                {
                    IdLoginCadastro = aIdLoginCadastro,
                    IdAnuncio = aIdAnuncio,
                    Caminho = pathImagem.Replace("/", @"\"),
                    Destaque = cont == 0
                });

                cont++;
            }
        }

        public void AlterarFotoDestaque(int aIdFoto)
        {
            if (aIdFoto == default || Listar(aIdFoto) == null)
            {
                throw new BusinessException("O Id da foto é inválido.");
            }

            new AnuncioFotoRepository().AlterarFotoDestaque(aIdFoto);
        }

        #endregion

        #region .: Utilitário :.

        public static string TratarCaminhoImagem(string aCaminho)
        {
            if (string.IsNullOrEmpty(aCaminho))
            {
                return null;
            }

            var rootPath = ConfigurationManager.AppSettings[Utilities.Constantes.PathFotosAnuncios];
            var pastaFotos = ConfigurationManager.AppSettings[Utilities.Constantes.NomePastaFotos];

            return aCaminho.Replace(rootPath, pastaFotos).Replace(@"\", "/");
        } 

        #endregion

        #region .: Buscas :.

        public IEnumerable<ChaveValorContract> BuscarPorAnuncio(int aIdAnuncio)
        {
            if (aIdAnuncio == default)
            {
                throw new BusinessException("O Id do anúncio é inválido.");
            }

            return new AnuncioFotoRepository().BuscarPorAnuncio(aIdAnuncio).Select(x => new ChaveValorContract()
            {
                Chave = Convert.ToString(x.Id),
                Valor = TratarCaminhoImagem(x.Caminho)
            });
        }

        public IEnumerable<ChaveValorContract> BuscarPorAnuncioComDestaque(int aIdAnuncio)
        {
            if (aIdAnuncio == default)
            {
                throw new BusinessException("O Id do anúncio é inválido.");
            }

            return new AnuncioFotoRepository().BuscarPorAnuncio(aIdAnuncio).Select(x => new ChaveValorContract()
            {
                Chave = Convert.ToString(x.Destaque),
                Valor = TratarCaminhoImagem(x.Caminho)
            });
        } 

        #endregion
    }
}
