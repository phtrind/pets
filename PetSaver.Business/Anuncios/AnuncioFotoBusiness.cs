using PetSaver.Entity.Anuncios;
using PetSaver.Exceptions;
using PetSaver.Repository.Anuncios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSaver.Business.Anuncios
{
    public class AnuncioFotoBusiness : BaseBusiness<AnuncioFotoEntity, AnuncioFotoRepository>
    {
        public void Cadastrar(int aIdAnuncio, int aIdLoginCadastro, string aGuidAnuncio, int aIndexDestaque)
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

            foreach (var pathImagem in pathImagens)
            {
                Inserir(new AnuncioFotoEntity()
                {
                    IdLoginCadastro = aIdLoginCadastro,
                    IdAnuncio = aIdAnuncio,
                    Caminho = pathImagem.Replace("/", @"\"),
                    Destaque = Convert.ToInt32(Path.GetFileNameWithoutExtension(pathImagem)) == aIndexDestaque
                });
            }
        }

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
    }
}
