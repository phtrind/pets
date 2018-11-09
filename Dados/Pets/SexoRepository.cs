using PetSaver.Entity.Pets;
using System;

namespace PetSaver.Repository.Pets
{
    public class SexoRepository : BaseRepository<SexoEntity>
    {
        protected override void ValidarAtributos(SexoEntity aObjeto)
        {
            throw new NotImplementedException();
        }
    }
}
