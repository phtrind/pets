using System;
using PetSaver.Business.Usuarios;
using PetSaver.Contracts.Anuncios;
using PetSaver.Entity.Anuncios;
using PetSaver.Exceptions;
using PetSaver.Repository.Anuncios;

namespace PetSaver.Business.Anuncios
{
    public class AnuncioGosteiBusiness : BaseBusiness<AnuncioGosteiEntity, AnuncioGosteiRepository>
    {
        #region .: Cadastro :.

        public int Cadastrar(CadastrarGosteiRequest aRequest)
        {
            if (aRequest == null)
            {
                throw new BusinessException("O objeto de requisição é inválido.");
            }

            var usuario = new UsuarioBusiness().Listar(aRequest.IdUsuario);

            if (usuario == null)
            {
                throw new BusinessException("O Id do usuário é inválido");
            }

            if (UsuarioGostouAnuncio(aRequest.IdAnuncio, aRequest.IdUsuario))
            {
                throw new BusinessException("O usuário já marcou esse anúncio como Gostei.");
            }

            return new AnuncioGosteiRepository().Inserir(new AnuncioGosteiEntity()
            {
                IdLoginCadastro = usuario.IdLogin,
                IdAnuncio = aRequest.IdAnuncio,
                IdUsuario = aRequest.IdUsuario
            });
        }

        public void Remover(CadastrarGosteiRequest aRequest)
        {
            if (aRequest.IdAnuncio == default)
            {
                throw new BusinessException("O Id do anuncio é inválido.");
            }

            if (aRequest.IdUsuario == default)
            {
                throw new BusinessException("O Id do usuário é inválido.");
            }

            if (!UsuarioGostouAnuncio(aRequest.IdAnuncio, aRequest.IdUsuario))
            {
                throw new BusinessException("Não existe um Gostei entre o usuário e o anúncio informado.");
            }

            new AnuncioGosteiRepository().RemoverGostei(aRequest.IdAnuncio, aRequest.IdUsuario);
        }

        #endregion

        #region .: Buscas :.

        public bool UsuarioGostouAnuncio(int aIdAnuncio, int aIdUsuario)
        {
            if (aIdAnuncio == default)
            {
                throw new BusinessException("O Id do anuncio é inválido.");
            }

            if (aIdUsuario == default)
            {
                throw new BusinessException("O Id do usuário é inválido.");
            }

            return new AnuncioGosteiRepository().BuscarPorAnuncioUsuario(aIdAnuncio, aIdUsuario) != null;
        }

        #endregion
    }
}
