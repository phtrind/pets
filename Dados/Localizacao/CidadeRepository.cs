using Dapper;
using PetSaver.Entity.Localizacao;
using PetSaver.Exceptions;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PetSaver.Repository.Localizacao
{
    public class CidadeRepository : BaseRepository<CidadeEntity>
    {
        protected override void ValidarAtributos(CidadeEntity aObjeto)
        {
            if (string.IsNullOrEmpty(aObjeto.Nome))
            {
                throw new BusinessException("O nome da cidade é inválida.");
            }

            if (aObjeto.IdEstado == default || new EstadoRepository().Listar(aObjeto.IdEstado) == null)
            {
                throw new BusinessException("O Id do estado da cidade é inválido.");
            }
        }

        public IEnumerable<CidadeEntity> BuscarPorEstado(int aIdEstado)
        {
            using (var db = new SqlConnection(StringConnection))
            {
                return db.Query<CidadeEntity>(Resource.BuscarCidadePorEstado, new { @IdEstado = aIdEstado });
            }
        }
    }
}
