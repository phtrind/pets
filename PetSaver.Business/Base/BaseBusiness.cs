using PetSaver.Entity;
using PetSaver.Repository;
using System.Collections.Generic;

namespace PetSaver.Business
{
    public abstract class BaseBusiness<E, R> where E : BaseEntity where R : BaseRepository<E>, new()
    {
        /// <summary>
        /// Método para retornar todos os registros de uma entidade
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<E> ListarTodos()
        {
            return new R().ListarTodos();
        }

        /// <summary>
        /// Método para retornar um registro específico de uma entidade
        /// </summary>
        /// <returns></returns>
        public virtual E Listar(int aId)
        {
            return new R().Listar(aId);
        }

        /// <summary>
        /// Método para inserir uma entidade na base de dados
        /// </summary>
        /// <returns></returns>
        public virtual int Inserir(E aObjeto)
        {
            return new R().Inserir(aObjeto);
        }

        /// <summary>
        /// Método para atualizar uma entidade na base de dados
        /// </summary>
        /// <returns></returns>
        public virtual void Atualizar(E aObjeto)
        {
            new R().Atualizar(aObjeto);
        }

        /// <summary>
        /// Método para excluir uma entidade na base de dados
        /// </summary>
        /// <returns></returns>
        public virtual void Excluir(int aId)
        {
            new R().Excluir(aId);
        }
    }
}