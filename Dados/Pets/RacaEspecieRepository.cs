using Dapper;
using PetSaver.Contracts.Base;
using PetSaver.Entity.Pets;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSaver.Repository.Pets
{
    public class RacaEspecieRepository : BaseRepository<RacaEspecieEntity>
    {
        protected override void ValidarAtributos(RacaEspecieEntity aObjeto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<dynamic> BuscarPorAnimal(int aIdAnimal)
        {
            using (var db = new SqlConnection(StringConnection))
            {
                return db.Query(Resource.BuscarRacaEspeciePorAnimal, new { @IdAnimal = aIdAnimal });
            }
        }
    }
}
