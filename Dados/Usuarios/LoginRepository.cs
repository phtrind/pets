﻿using Dapper;
using PetSaver.Entity.Enums;
using PetSaver.Entity.Usuarios;
using PetSaver.Exceptions;
using System;
using System.Data.SqlClient;

namespace PetSaver.Repository.Usuarios
{
    public class LoginRepository : BaseRepository<LoginEntity>
    {
        protected override void ValidarCadastro(LoginEntity aObjeto)
        {
            if (aObjeto.Id != default)
            {
                throw new DbValidationException("Não é possível cadastrar um objeto que já tenha um Id definido");
            }

            if (aObjeto.DataCadastro == default)
            {
                throw new DbValidationException("Data de cadastro inválida.");
            }

            if (aObjeto.DataAlteracao.HasValue)
            {
                throw new DbValidationException("Não é possível cadastrar um objeto que já tenha uma Data de Alteração definida.");
            }

            if (aObjeto.IdLoginAlteracao.HasValue)
            {
                throw new DbValidationException("Não é possível cadastrar um objeto que já tenha um Login de Alteração definido.");
            }

            if (BuscarPorEmail(aObjeto.Email) != null)
            {
                throw new BusinessException("O e-mail do Login já está cadastrado no sistema.");
            }

            ValidarAtributos(aObjeto);
        }

        #region .: Buscas :.

        /// <summary>
        /// Retorna a entidade de login referente ao e-mail informado
        /// </summary>
        /// <param name="aEmail">E-mail a ser buscado na base</param>
        /// <returns></returns>
        public LoginEntity BuscarPorEmail(string aEmail)
        {
            using (var db = new SqlConnection(StringConnection))
            {
                return db.QueryFirstOrDefault<LoginEntity>(Resource.BuscarLoginPorEmail, new { @Email = aEmail });
            }
        }

        /// <summary>
        /// Retorna a entidade de login referente ao e-mail e senha informados
        /// </summary>
        /// <param name="aEmail">E-mail a ser buscado na base</param>
        /// <param name="aSenha">Senha a ser buscada na base</param>
        /// <returns></returns>
        public LoginEntity BuscarPorEmailSenha(string aEmail, string aSenha)
        {
            using (var db = new SqlConnection(StringConnection))
            {
                return db.QueryFirstOrDefault<LoginEntity>(Resource.BuscarLoginPorEmailSenha, new { @Email = aEmail, @Senha = aSenha });
            }
        }

        #endregion

        #region .: Validações :

        protected override void ValidarAtributos(LoginEntity aObjeto)
        {
            if (!Utilities.Validador.EmailIsValid(aObjeto.Email))
            {
                throw new BusinessException("E-mail do Login inválido.");
            }

            if (!Utilities.Validador.PasswordIsValid(aObjeto.Senha))
            {
                throw new BusinessException("Senha do Login inválida.");
            }

            if (aObjeto.IdTipo == default || !Enum.IsDefined(typeof(TiposLogin), aObjeto.IdTipo))
            {
                throw new DbValidationException("Id do tipo de login inválido.");
            }
        }

        #endregion
    }
}
