using Dapper;
using PetSaver.Entity.Usuarios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSaver.Repository.Usuarios
{
    public class FuncionarioRepository : BaseRepository<FuncionarioEntity>
    {
        protected override void ValidarAtributos(FuncionarioEntity aObjeto)
        {
        }

        #region .: Buscas :.

        public FuncionarioEntity BuscarPorLogin(int aIdLogin)
        {
            if (aIdLogin == default)
            {
                return null;
            }

            using (var db = new SqlConnection(StringConnection))
            {
                return db.QueryFirstOrDefault<FuncionarioEntity>(Resource.BuscarFuncionarioPorLogin, new { @IdLogin = aIdLogin });
            }
        }

        #endregion
    }
}
