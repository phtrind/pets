using PetSaver.Contracts.Base;
using PetSaver.Entity.Localizacao;
using PetSaver.Repository.Localizacao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetSaver.Business.Localizacao
{
    public class CidadeBusiness : BaseBusiness<CidadeEntity, CidadeRepository>
    {
        public IEnumerable<ChaveValorContract> Combo(int aIdEstado)
        {
            return new CidadeRepository().BuscarPorEstado(aIdEstado).Select(x => new ChaveValorContract()
            {
                Chave = Convert.ToString(x.Id),
                Valor = x.Nome
            });
        }
    }
}
