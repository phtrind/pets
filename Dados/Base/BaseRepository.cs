using Dommel;
using PetSaver.Entity;
using PetSaver.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace PetSaver.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        public string StringConnection { get; } = ConfigurationManager.ConnectionStrings["petsaver"].ConnectionString;

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
                return Convert.ToInt32(db.Insert(aObjeto));
            }
        }

        public virtual void Atualizar(T aObjeto)
        {
            using (var db = new SqlConnection(StringConnection))
            {
                db.Update<T>(aObjeto);
            }
        }

        public virtual void Excluir(T aObjeto)
        {
            using (var db = new SqlConnection(StringConnection))
            {
                db.Delete<T>(aObjeto);
            }
        }
    }
}
