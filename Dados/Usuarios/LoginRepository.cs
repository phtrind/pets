using Dapper;
using PetSaver.Entity.Usuarios;
using PetSaver.Exceptions;
using System.Data.SqlClient;

namespace PetSaver.Repository.Usuarios
{
    public class LoginRepository : BaseRepository<LoginEntity>
    {
        #region .: Buscas :.

        public LoginEntity BuscarPorEmail(string aEmail)
        {
            using (var db = new SqlConnection(StringConnection))
            {
                return db.QueryFirstOrDefault<LoginEntity>(Resource.BuscarLoginPorEmail, new { @Email = aEmail });
            }
        }

        #endregion

        #region .: Validações :

        protected override void ValidarCadastro(LoginEntity aObjeto)
        {
            base.ValidarCadastro(aObjeto);

            if (BuscarPorEmail(aObjeto.Email) != null)
            {
                throw new BusinessException("O e-mail do Login já está cadastrado no sistema.");
            }
        }

        protected override void ValidarAtributos(LoginEntity aObjeto)
        {
            if (!Utilities.Validador.EmailIsValid(aObjeto.Email))
            {
                throw new BusinessException("E-mail do Login inválido.");
            }

            if (!Utilities.Validador.PasswordIsValid(aObjeto.Senha))
            {
                throw new BusinessException("Senha do Login inválida.");
            }

            if (aObjeto.IdTipo == default || new TipoLoginRepository().Listar(aObjeto.IdTipo) == null)
            {
                throw new DbValidationException("Id do tipo de login inválido.");
            }
        }

        #endregion
    }
}
