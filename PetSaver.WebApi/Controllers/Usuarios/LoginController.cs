﻿using PetSaver.Business.Usuarios;
using PetSaver.Entity.Usuarios;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace PetSaver.WebApi.Controllers.Usuarios
{
    public class LoginController : ApiController
    {
        // GET: api/Login
        public IEnumerable<LoginEntity> Get()
        {
            try
            {
                return new LoginBusiness().ListarTodos();
            }
            catch (Exception ex)
            {
                throw Util.TratarErro(ex);
            }
        }

        // GET: api/Login/5
        public LoginEntity Get(int id)
        {
            try
            {
                return new LoginBusiness().Listar(id);
            }
            catch (Exception ex)
            {
                throw Util.TratarErro(ex);
            }
        }

        // POST: api/Login
        public void Post([FromBody]LoginEntity value)
        {
            try
            {
                new LoginBusiness().Inserir(value);
            }
            catch (Exception ex)
            {
                throw Util.TratarErro(ex);
            }
        }

        // PUT: api/Login/5
        public void Put([FromBody]LoginEntity value)
        {
            try
            {
                new LoginBusiness().Atualizar(value);
            }
            catch (Exception ex)
            {
                throw Util.TratarErro(ex);
            }
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
            try
            {
                new LoginBusiness().Excluir(id);
            }
            catch (Exception ex)
            {
                throw Util.TratarErro(ex);
            }
        }
    }
}
