using PetSaver.Contracts.Base;
using PetSaver.Entity.Pets;
using PetSaver.Exceptions;
using PetSaver.Repository.Pets;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetSaver.Business.Pets
{
    public class RacaEspecieBusiness : BaseBusiness<RacaEspecieEntity, RacaEspecieRepository>
    {
        public IEnumerable<ChaveValorContract> BuscarPorAnimal(int aIdAnimal)
        {
            if (aIdAnimal == default)
            {
                throw new BusinessException("O Id do animal é inválido.");
            }

            return new RacaEspecieRepository().BuscarPorAnimal(aIdAnimal).Select(x => new ChaveValorContract()
            {
                Chave = Convert.ToString(x.RAC_CODIGO),
                Valor = Convert.ToString(x.RAC_NOME)
            });
        }
    }
}
