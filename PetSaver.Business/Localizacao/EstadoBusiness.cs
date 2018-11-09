using PetSaver.Contracts.Base;
using PetSaver.Entity.Localizacao;
using PetSaver.Repository.Localizacao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetSaver.Business.Localizacao
{
    public class EstadoBusiness : BaseBusiness<EstadoEntity, EstadoRepository>
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
