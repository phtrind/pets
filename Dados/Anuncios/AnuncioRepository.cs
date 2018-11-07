using PetSaver.Entity.Anuncios;
using PetSaver.Entity.Enums.Status;
using PetSaver.Entity.Enums.Tipos;
using PetSaver.Exceptions;
using PetSaver.Repository.Localizacao;
using PetSaver.Repository.Pets;
using PetSaver.Repository.Usuarios;
using System;

namespace PetSaver.Repository.Anuncios
{
    public class AnuncioRepository : BaseRepository<AnuncioEntity>
    {
        protected override void ValidarAtributos(AnuncioEntity aObjeto)
        {
            if (!Enum.IsDefined(typeof(StatusAnuncio), aObjeto.IdStatus))
            {
                throw new DbValidationException("O Id do status do anúncio é inválido.");
            }

            if (!Enum.IsDefined(typeof(TiposAnuncio), aObjeto.IdTipo))
            {
                throw new DbValidationException("O Id do tipo do anúncio é inválido.");
            }

            if (aObjeto.IdPet == default || new PetRepository().Listar(aObjeto.IdPet) == null)
            {
                throw new DbValidationException("O Id do pet do anúncio é inválido.");
            }

            if (aObjeto.IdLocalizacao.HasValue)
            {
                if (aObjeto.IdLocalizacao == default)
                {
                    aObjeto.IdLocalizacao = null;
                }
                else if (new LocalizacaoRepository().Listar(aObjeto.IdLocalizacao.Value) == null)
                {
                    throw new DbValidationException("O Id da localização do anúncio é inválido.");
                }
            }

            if (aObjeto.IdEstado == default || new EstadoRepository().Listar(aObjeto.IdEstado) == null)
            {
                throw new DbValidationException("O Id do estado do anúncio é inválido.");
            }

            if (aObjeto.IdCidade == default)
            {
                throw new DbValidationException("O Id da cidade do anúncio é inválido.");
            }

            var cidade = new CidadeRepository().Listar(aObjeto.IdCidade);

            if (cidade == null)
            {
                throw new DbValidationException("O Id da cidade do anúncio é inválido.");
            }
            else if (cidade.IdEstado != aObjeto.IdEstado)
            {
                throw new DbValidationException("O Id da cidade não é referente ao Id do estado informado.");
            }

            if (aObjeto.IdUsuario == default || new UsuarioRepository().Listar(aObjeto.IdUsuario) == null)
            {
                throw new DbValidationException("O Id do usuário do anúncio é inválido.");
            }
        }
    }
}
