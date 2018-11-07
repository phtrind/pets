using PetSaver.Entity.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSaver.Repository.Pets
{
    public class CorRepository : BaseRepository<CorEntity>
    {
        protected override void ValidarAtributos(CorEntity aObjeto)
        {
            throw new NotImplementedException();
        }
    }
}
