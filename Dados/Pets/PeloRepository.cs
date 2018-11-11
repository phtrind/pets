using PetSaver.Entity.Pets;
using System;

namespace PetSaver.Repository.Pets
{
    public class PeloRepository : BaseRepository<PeloEntity>
    {
        protected override void ValidarAtributos(PeloEntity aObjeto)
        {
            throw new NotImplementedException();
        }
    }
}
