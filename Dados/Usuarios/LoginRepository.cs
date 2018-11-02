using Dapper;
using PetSaver.Entity.Usuarios;
using PetSaver.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if (this.BuscarPorEmail(aObjeto.Email) != null)
            {
                throw new BusinessException("O e-mail já está cadastrado no sistema.");
            }
        }

        protected override void ValidarAtributos(LoginEntity aObjeto)
        {
            if (!Utilities.Validador.EmailIsValid(aObjeto.Email))
            {
                throw new BusinessException("E-mail inválido.");
            }

            if (Utilities.Validador.PasswordIsValid(aObjeto.Senha))
            {
                throw new BusinessException("Senha inválida.");
            }
        } 

        #endregion
    }
}
