using PetSaver.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSaver.Repository.Pets
{
    public class AnimalRepository : BaseRepository<AnimalEntity>
    {
        protected override void ValidarAtributos(AnimalEntity aObjeto)
        {
            throw new NotImplementedException();
        }
    }
}
