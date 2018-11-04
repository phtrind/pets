using PetSaver.Business.Usuarios;
using PetSaver.Entity.Usuarios;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace PetSaver.WebApi.Controllers.Usuarios
{
    [Authorize]
    public class UsuarioController : ApiController
    {
        // GET: api/Usuario
        public IEnumerable<UsuarioEntity> Get()
        {
            try
            {
                return new UsuarioBusiness().ListarTodos();
            }
            catch (Exception ex)
            {
                throw Util.TratarErro(ex);
            }
        }

        // GET: api/Usuario/5
        public UsuarioEntity Get(int id)
        {
            try
            {
                return new UsuarioBusiness().Listar(id);
            }
            catch (Exception ex)
            {
                throw Util.TratarErro(ex);
            }
        }

        // POST: api/Usuario
        public int Post([FromBody]UsuarioEntity value)
        {
            try
            {
                return new UsuarioBusiness().Inserir(value);
            }
            catch (Exception ex)
            {
                throw Util.TratarErro(ex);
            }
        }

        // PUT: api/Usuario/5
        public void Put([FromBody]UsuarioEntity value)
        {
            try
            {
                new UsuarioBusiness().Atualizar(value);
            }
            catch (Exception ex)
            {
                throw Util.TratarErro(ex);
            }
        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {
            try
            {
                new UsuarioBusiness().Excluir(id);
            }
            catch (Exception ex)
            {
                throw Util.TratarErro(ex);
            }
        }

        [Authorize]
        [Route("api/Usuario/Cadastrar")]
        [HttpPost]
        public void InformacoesLogin([FromBody]UsuarioEntity value)
        {
            try
            {
                new UsuarioBusiness().Cadastrar(value);
            }
            catch (Exception ex)
            {
                throw Util.TratarErro(ex);
            }
        }
    }
}
