using PetSaver.Entity.Pets;
using System;

namespace PetSaver.Repository.Pets
{
    public class PorteRepository : BaseRepository<PorteEntity>
    {
        protected override void ValidarAtributos(PorteEntity aObjeto)
        {
            throw new NotImplementedException();
        }
    }
}
