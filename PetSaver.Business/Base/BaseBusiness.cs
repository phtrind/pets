using PetSaver.Entity;
using PetSaver.Exceptions;
using PetSaver.Repository;
using System;
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
            try
            {
                return new R().ListarTodos();
            }
            catch (HandledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Exceptions.Util.TratarExcecao(ex);

                return new List<E>();
            }
        }

        /// <summary>
        /// Método para retornar um registro específico de uma entidade
        /// </summary>
        /// <returns></returns>
        public virtual E Listar(int aId)
        {
            try
            {
                return new R().Listar(aId);
            }
            catch (HandledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Exceptions.Util.TratarExcecao(ex);

                return null;
            }
        }

        /// <summary>
        /// Método para inserir uma entidade na base de dados
        /// </summary>
        /// <returns></returns>
        public virtual int Inserir(E aObjeto)
        {
            try
            {
                return new R().Inserir(aObjeto);
            }
            catch (HandledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Exceptions.Util.TratarExcecao(ex);

                return default;
            }
        }

        /// <summary>
        /// Método para atualizar uma entidade na base de dados
        /// </summary>
        /// <returns></returns>
        public virtual void Atualizar(E aObjeto)
        {
            try
            {
                new R().Atualizar(aObjeto);
            }
            catch (HandledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Exceptions.Util.TratarExcecao(ex);
            }
        }

        /// <summary>
        /// Método para excluir uma entidade na base de dados
        /// </summary>
        /// <returns></returns>
        public virtual void Excluir(int aId)
        {
            try
            {
                new R().Excluir(aId);
            }
            catch (HandledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Exceptions.Util.TratarExcecao(ex);
            }
        }
    }
}