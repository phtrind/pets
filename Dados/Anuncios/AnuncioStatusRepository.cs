using PetSaver.Entity.Anuncios;
using System;

namespace PetSaver.Repository.Anuncios
{
    public class AnuncioStatusRepository : BaseRepository<AnuncioStatusEntity>
    {
        protected override void ValidarAtributos(AnuncioStatusEntity aObjeto)
        {
            throw new NotImplementedException();
        }
    }
}
