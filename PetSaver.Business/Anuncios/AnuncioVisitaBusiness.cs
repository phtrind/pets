using PetSaver.Entity.Anuncios;
using PetSaver.Repository.Anuncios;
using System;

namespace PetSaver.Business.Anuncios
{
    public class AnuncioVisitaBusiness : BaseBusiness<AnuncioVisitaEntity, AnuncioVisitaRepository>
    {
        public void GravarLog(int aIdAnuncio, int? aIdUsuario)
        {
            try
            {
                new AnuncioVisitaBusiness().Inserir(new AnuncioVisitaEntity()
                {
                    IdAnuncio = aIdAnuncio,
                    IdUsuario = aIdUsuario
                });
            }
            catch (Exception ex)
            {
                Exceptions.Util.TratarExcecao(ex);
            }
        }
    }
}
