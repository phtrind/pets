using Dommel;
using PetSaver.Entity;
using PetSaver.Exceptions;
using PetSaver.Repository.Interface;
using PetSaver.Repository.Usuarios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace PetSaver.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        public string StringConnection { get; } = ConfigurationManager.ConnectionStrings["petsaver"].ConnectionString;

        #region .: Base de Dados :.

        public virtual IEnumerable<T> ListarTodos()
        {
            using (var db = new SqlConnection(StringConnection))
            {
                return db.GetAll<T>();
            }
        }

        public virtual T Listar(int aCodigo)
        {
            using (var db = new SqlConnection(StringConnection))
            {
                return db.Get<T>(aCodigo);
            }
        }

        public virtual int Inserir(T aObjeto)
        {
            using (var db = new SqlConnection(StringConnection))
            {
                aObjeto.DataCadastro = DateTime.Now;

                ValidarCadastro(aObjeto);

                return Convert.ToInt32(db.Insert(aObjeto));
            }
        }

        public virtual void Atualizar(T aObjeto)
        {
            using (var db = new SqlConnection(StringConnection))
            {
                aObjeto.DataAlteracao = DateTime.Now;

                ValidarAtualizacao(aObjeto);

                db.Update(aObjeto);
            }
        }

        public virtual void Excluir(int aId)
        {
            using (var db = new SqlConnection(StringConnection))
            {
                var entity = Listar(aId);

                if (entity != null)
                {
                    db.Delete(entity);
                }
                else
                {
                    throw new DbValidationException("O registro a ser excluído não foi encontrado");
                }
            }
        }

        #endregion

        #region .: Validações :.

        protected abstract void ValidarAtributos(T aObjeto);

        protected virtual void ValidarCadastro(T aObjeto)
        {
            if (aObjeto.Id != default)
            {
                throw new DbValidationException("Não é possível cadastrar um objeto que já tenha um Id definido");
            }

            if (aObjeto.DataCadastro == default)
            {
                throw new DbValidationException("Data de cadastro inválida.");
            }

            if (aObjeto.IdLoginCadastro == default || !LoginExiste(aObjeto.IdLoginCadastro))
            {
                throw new DbValidationException("O Id do usuário responsável pelo cadastro é inválido.");
            }

            if (aObjeto.DataAlteracao.HasValue)
            {
                throw new DbValidationException("Não é possível cadastrar um objeto que já tenha uma Data de Alteração definida.");
            }

            if (aObjeto.IdLoginAlteracao.HasValue)
            {
                throw new DbValidationException("Não é possível cadastrar um objeto que já tenha um Login de Alteração definido.");
            }

            ValidarAtributos(aObjeto);
        }

        protected virtual void ValidarAtualizacao(T aObjeto)
        {
            if (aObjeto.Id == default)
            {
                throw new DbValidationException("Não é possível editar um objeto que não tenha um Id definido");
            }

            if (aObjeto.DataCadastro == default)
            {
                throw new DbValidationException("Data de cadastro inválida.");
            }

            if (aObjeto.IdLoginCadastro == default || !LoginExiste(aObjeto.IdLoginCadastro))
            {
                throw new DbValidationException("O Id do usuário responsável pelo cadastro é inválido.");
            }

            if (aObjeto.IdLoginCadastro != Listar(aObjeto.Id).IdLoginCadastro)
            {
                throw new DbValidationException("Não é possível editar o usuário responsável pelo cadastro.");
            }

            if (!aObjeto.DataAlteracao.HasValue)
            {
                throw new DbValidationException("Data de alteração inválida.");
            }

            if (!aObjeto.IdLoginAlteracao.HasValue || !LoginExiste(aObjeto.IdLoginAlteracao.Value))
            {
                throw new DbValidationException("O Id do usuário responsável pela edição é inválido.");
            }

            ValidarAtributos(aObjeto);
        }

        protected bool LoginExiste(int idLoginCadastro)
        {
            return !(idLoginCadastro == default || new LoginRepository().Listar(idLoginCadastro) == null);
        }

        #endregion
    }
}
