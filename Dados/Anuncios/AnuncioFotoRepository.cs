using Dapper;
using PetSaver.Entity.Anuncios;
using PetSaver.Exceptions;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PetSaver.Repository.Anuncios
{
    public class AnuncioFotoRepository : BaseRepository<AnuncioFotoEntity>
    {
        protected override void ValidarAtributos(AnuncioFotoEntity aObjeto)
        {
            if (aObjeto.IdAnuncio == default || new AnuncioRepository().Listar(aObjeto.IdAnuncio) == null)
            {
                throw new DbValidationException("O Id do anúncio informado é inválido.");
            }

            if (string.IsNullOrEmpty(aObjeto.Caminho))
            {
                throw new BusinessException("O caminho da imagem informado é inválido.");
            }
        }

        public IEnumerable<AnuncioFotoEntity> BuscarPorAnuncio(int aIdAnuncio)
        {
            using (var db = new SqlConnection(StringConnection))
            {
                return db.Query<AnuncioFotoEntity>(Resource.BuscarFotosPorAnuncio, new { @IdAnuncio = aIdAnuncio });
            }
        }

        public void AlterarFotoDestaque(int aIdFoto)
        {
            using (var db = new SqlConnection(StringConnection))
            {
                db.Execute(Resource.AlterarFotoDestaque, new { @IdFoto = aIdFoto });
            }
        }
    }
}
