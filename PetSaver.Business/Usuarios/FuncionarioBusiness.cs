using PetSaver.Contracts.Usuario;
using PetSaver.Entity.Usuarios;
using PetSaver.Repository.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSaver.Business.Usuarios
{
    public class FuncionarioBusiness : BaseBusiness<FuncionarioEntity, FuncionarioRepository>
    {
        #region .: Buscas :.

        public FuncionarioEntity BuscarPorLogin(int aIdLogin)
        {
            if (aIdLogin == default)
            {
                return null;
            }

            return new FuncionarioRepository().BuscarPorLogin(aIdLogin);
        }

        public bool IsFuncionario(int aIdLogin)
        {
            return BuscarPorLogin(aIdLogin) != null;
        }

        public VerificarFuncionarioReponse Verificar(string aEmail)
        {
            var loginEntity = new LoginBusiness().BuscarPorEmail(aEmail);

            if (loginEntity == null)
            {
                return new VerificarFuncionarioReponse()
                {
                    IsFuncionario = false
                };
            }

            var funcionarioEntity = BuscarPorLogin(loginEntity.Id);

            if (funcionarioEntity == null)
            {
                return new VerificarFuncionarioReponse()
                {
                    IsFuncionario = false
                };
            }

            return new VerificarFuncionarioReponse()
            {
                IsFuncionario = true,
                IdFuncionario = funcionarioEntity.Id,
                IdLogin = loginEntity.Id,
                Nome = funcionarioEntity.Nome,
                DthValidadeToken = DateTime.Now.AddHours(Utilities.Constantes.HorasValidadeToken - 0.5)
            };
        } 

        #endregion
    }
}
