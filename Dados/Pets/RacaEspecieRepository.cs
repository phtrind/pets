using PetSaver.Entity.Pets;
using System;
using System.Collections.Generic;
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
    }
}
