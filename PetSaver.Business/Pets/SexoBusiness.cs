using PetSaver.Contracts.Base;
using PetSaver.Entity.Pets;
using PetSaver.Repository.Pets;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetSaver.Business.Pets
{
    public class SexoBusiness : BaseBusiness<SexoEntity, SexoRepository>
    {
        public IEnumerable<ChaveValorContract> Combo()
        {
            return ListarTodos().OrderBy(x => x.Descricao).Select(x => new ChaveValorContract()
            {
                Chave = Convert.ToString(x.Id),
                Valor = x.Descricao
            });
        }
    }
}
