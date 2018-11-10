using PetSaver.Entity.Anuncios;
using PetSaver.Repository.Anuncios;
using System.Collections.Generic;

namespace PetSaver.Business.Anuncios
{
    public class DuvidaBusiness : BaseBusiness<DuvidaEntity, DuvidaRepository>
    {
        public IEnumerable<DuvidaEntity> BuscarPorAnuncio(int aIdAnuncio)
        {
            return new DuvidaRepository().BuscarPorAnuncio(aIdAnuncio);
        }
    }
}
