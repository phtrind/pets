using PetSaver.Entity.Pets;
using System;

namespace PetSaver.Repository.Pets
{
    public class IdadeRepository : BaseRepository<IdadeEntity>
    {
        protected override void ValidarAtributos(IdadeEntity aObjeto)
        {
            throw new NotImplementedException();
        }
    }
}
