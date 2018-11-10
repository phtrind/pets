using PetSaver.Entity.Anuncios;
using PetSaver.Repository.Anuncios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSaver.Business.Anuncios
{
    public class AvaliacaoBusiness : BaseBusiness<AvaliacaoEntity, AvaliacaoRepository>
    {
        public double? MediaAvaliacaoPorUsuario(int aIdUsuario)
        {
            if (aIdUsuario == default)
            {
                return null;
            }

            var lista = BuscarAvaliacaoPorUsuario(aIdUsuario);

            if (!lista.Any())
            {
                return null;
            }

            return lista.Select(x => x.Nota).Average();
        }

        public IEnumerable<AvaliacaoEntity> BuscarAvaliacaoPorUsuario(int aIdUsuario)
        {
            if (aIdUsuario == default)
            {
                return new List<AvaliacaoEntity>();
            }

            return new AvaliacaoRepository().BuscarAvaliacaoPorUsuario(aIdUsuario);
        }
    }
}
