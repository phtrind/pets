using PetSaver.Contracts.Base;
using PetSaver.Entity.Pets;
using PetSaver.Repository.Pets;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetSaver.Business.Pets
{
    public class IdadeBusiness : BaseBusiness<IdadeEntity, IdadeRepository>
    {
        public IEnumerable<ChaveValorContract> Combo()
        {
            return ListarTodos().OrderBy(x => x.Id).Select(x => new ChaveValorContract()
            {
                Chave = Convert.ToString(x.Id),
                Valor = x.Descricao
            });
        }
    }
}
