using PetSaver.Entity;
using System.Collections.Generic;

namespace PetSaver.Repository.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> ListarTodos();

        T Listar(int aCodigo);

        int Inserir(T aObjeto);

        void Atualizar(T aObjeto);

        void Excluir(int aId);
    }
}
