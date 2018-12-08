using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using PetSaver.Entity.Chat;
using PetSaver.Exceptions;
using PetSaver.Repository.Anuncios;

namespace PetSaver.Repository.Chat
{
    public class InboxRepository : BaseRepository<InboxEntity>
    {
        protected override void ValidarCadastro(InboxEntity aObjeto)
        {
            if (aObjeto.Id != default)
            {
                throw new DbValidationException("Não é possível cadastrar um objeto que já tenha um Id definido");
            }

            if (aObjeto.DataCadastro == default)
            {
                throw new DbValidationException("Data de cadastro inválida.");
            }
        }

        protected override void ValidarAtributos(InboxEntity aObjeto)
        {
            if (aObjeto.IdInteresse == default)
            {
                throw new DbValidationException("O Id do interesse é inválido.");
            }

            if (aObjeto.IdRemetente == default)
            {
                throw new DbValidationException("O Id do remetente é inválido.");
            }

            if (aObjeto.IdDestinatário == default)
            {
                throw new DbValidationException("O Id do destinatário é inválido.");
            }

            var interesseEntity = new InteresseRepository().Listar(aObjeto.IdInteresse);

            if (interesseEntity == null)
            {
                throw new DbValidationException("O Id do interesse é inválido.");
            }

            if (interesseEntity.IdUsuario != aObjeto.IdRemetente &&
                interesseEntity.IdUsuario != aObjeto.IdDestinatário)
            {
                throw new BusinessException("Nem o Id do remetente nem o Id do destinatário são referentes ao interesse.");
            }

            var anuncio = new AnuncioRepository().Listar(interesseEntity.IdAnuncio);

            if (anuncio == null)
            {
                throw new BusinessException("O anúncio referente ao chat não foi encontrado.");
            }

            if (anuncio.IdUsuario != aObjeto.IdRemetente &&
                anuncio.IdUsuario != aObjeto.IdDestinatário)
            {
                throw new BusinessException("Nem o Id do remetente nem o Id do destinatário são referentes ao anúncio.");
            }

            if (aObjeto.FoiLida)
            {
                throw new BusinessException("Não é possível inserir uma mensagem como lida.");
            }
        }

        public IEnumerable<InboxEntity> BuscarMensagensPorInteresse(int aIdInteresse)
        {
            if (aIdInteresse == default)
            {
                return new List<InboxEntity>();
            }

            using (var db = new SqlConnection(StringConnection))
            {
                return db.Query<InboxEntity>(Resource.BuscarInboxPorInteresse, new { @IdInteresse = aIdInteresse });
            }
        }
    }
}
