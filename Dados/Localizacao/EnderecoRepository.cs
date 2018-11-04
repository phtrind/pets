using PetSaver.Entity.Localizacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSaver.Repository.Localizacao
{
    public class EnderecoRepository : BaseRepository<EnderecoEntity>
    {
        protected override void ValidarAtributos(EnderecoEntity aObjeto)
        {
            throw new NotImplementedException();
        }
    }
}
