using PetSaver.Entity.Pets;
using PetSaver.Repository.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetSaver.WebApi.Controllers.Pets
{
    [Authorize]
    public class PetController : BaseController
    {
        // GET: api/Pet
        public IEnumerable<PetEntity> Get()
        {
            try
            {
                return new PetRepository().ListarTodos();
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        // GET: api/Pet/5
        public PetEntity Get(int id)
        {
            try
            {
                return new PetRepository().Listar(id);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        // POST: api/Pet
        public int Post([FromBody]PetEntity value)
        {
            try
            {
                return new PetRepository().Inserir(value);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        // PUT: api/Pet/5
        public void Put([FromBody]PetEntity value)
        {
            try
            {
                new PetRepository().Atualizar(value);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }

        // DELETE: api/Pet/5
        public void Delete(int id)
        {
            try
            {
                new PetRepository().Excluir(id);
            }
            catch (Exception ex)
            {
                throw TratarErro(ex);
            }
        }
    }
}
