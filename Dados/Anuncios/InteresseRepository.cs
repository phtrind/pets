﻿using Dapper;
using PetSaver.Entity.Anuncios;
using PetSaver.Entity.Enums.Status;
using PetSaver.Exceptions;
using PetSaver.Repository.Usuarios;
using System;
using System.Data.SqlClient;

namespace PetSaver.Repository.Anuncios
{
    public class InteresseRepository : BaseRepository<InteresseEntity>
    {
        protected override void ValidarAtributos(InteresseEntity aObjeto)
        {
            if (aObjeto.IdUsuario == default || new UsuarioRepository().Listar(aObjeto.IdUsuario) == null)
            {
                throw new DbValidationException("O Id do usuário do interesse é inválido.");
            }

            var anuncio = new AnuncioRepository().Listar(aObjeto.IdAnuncio);

            if (aObjeto.IdAnuncio == default || anuncio == null)
            {
                throw new DbValidationException("O Id do anúncio do interesse é inválido.");
            }

            if (anuncio.IdUsuario == aObjeto.IdUsuario)
            {
                throw new BusinessException("Não é possível cadastrar um interesse que seja do mesmo usuário do anúncio.");
            }

            if (!Enum.IsDefined(typeof(StatusInteresse), aObjeto.IdStatus))
            {
                throw new DbValidationException("O Id do status do interesse é inválido.");
            }

            if (BuscarPorUsuarioAnuncio(aObjeto.IdUsuario, aObjeto.IdAnuncio) != null)
            {
                throw new BusinessException("O usuário já tem um interesse cadastrado nesse anúncio.");
            }
        }

        #region .: Consultas :.

        public InteresseEntity BuscarPorUsuarioAnuncio(int aIdUsuario, int aIdAnuncio)
        {
            if (aIdUsuario == default || aIdAnuncio == default)
            {
                return null;
            }

            using (var db = new SqlConnection(StringConnection))
            {
                return db.QueryFirstOrDefault<InteresseEntity>(Resource.BuscarInteressePorUsuarioAnuncio, new { @IdUsuario = aIdUsuario, @IdAnuncio = aIdAnuncio });
            }
        }

        #endregion
    }
}
