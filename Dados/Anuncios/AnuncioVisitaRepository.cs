using PetSaver.Entity.Anuncios;
using PetSaver.Exceptions;
using PetSaver.Repository.Usuarios;

namespace PetSaver.Repository.Anuncios
{
    public class AnuncioVisitaRepository : BaseRepository<AnuncioVisitaEntity>
    {
        protected override void ValidarCadastro(AnuncioVisitaEntity aObjeto)
        {
            if (aObjeto.DataCadastro == default)
            {
                throw new DbValidationException("Data de cadastro inválida.");
            }
        }

        protected override void ValidarAtributos(AnuncioVisitaEntity aObjeto)
        {
            if (aObjeto.IdUsuario == default || new UsuarioRepository().Listar(aObjeto.IdUsuario) == null)
            {
                throw new DbValidationException("O Id do usuário é inválido;");
            }

            var anuncio = new AnuncioRepository().Listar(aObjeto.IdAnuncio);

            if (aObjeto.IdAnuncio == default || anuncio == null)
            {
                throw new DbValidationException("O Id do anúncio é inválido.");
            }

            if (anuncio.IdUsuario == aObjeto.IdUsuario)
            {
                throw new BusinessException("Não é gravado log de acesso em anúncios do próprio usuário.");
            }
        }
    }
}
