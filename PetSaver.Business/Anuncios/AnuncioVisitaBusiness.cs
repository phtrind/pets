using PetSaver.Entity.Anuncios;
using PetSaver.Repository.Anuncios;
using System;

namespace PetSaver.Business.Anuncios
{
    public class AnuncioVisitaBusiness : BaseBusiness<AnuncioVisitaEntity, AnuncioVisitaRepository>
    {
        public void GravarLog(int aIdAnuncio, int? aIdUsuario)
        {
            if (aIdUsuario.HasValue && aIdUsuario.Value != default)
            {
                try
                {
                    new AnuncioVisitaBusiness().Inserir(new AnuncioVisitaEntity()
                    {
                        IdAnuncio = aIdAnuncio,
                        IdUsuario = aIdUsuario.Value
                    });
                }
                catch (Exception ex)
                {
                    Exceptions.Util.TratarExcecao(ex);
                }
            }
        }
    }
}
