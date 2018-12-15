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
    }
}
