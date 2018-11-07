using PetSaver.Entity.Localizacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSaver.Repository.Localizacao
{
    public class LocalizacaoRepository : BaseRepository<LocalizacaoEntity>
    {
        protected override void ValidarAtributos(LocalizacaoEntity aObjeto)
        {
            throw new NotImplementedException();
        }
    }
}
