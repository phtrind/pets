using PetSaver.Contracts.Base;
using PetSaver.Entity.Anuncios;
using PetSaver.Repository.Anuncios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetSaver.Business.Anuncios
{
    public class AnuncioStatusBusiness : BaseBusiness<AnuncioStatusEntity, AnuncioStatusRepository>
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
