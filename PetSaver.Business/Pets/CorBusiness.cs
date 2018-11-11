using PetSaver.Contracts.Base;
using PetSaver.Entity.Pets;
using PetSaver.Repository.Pets;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetSaver.Business.Pets
{
    public class CorBusiness : BaseBusiness<CorEntity, CorRepository>
    {
        public IEnumerable<ChaveValorContract> Combo()
        {
            return ListarTodos().OrderBy(x => x.Nome).Select(x => new ChaveValorContract()
            {
                Chave = Convert.ToString(x.Id),
                Valor = x.Nome
            });
        }
    }
}
