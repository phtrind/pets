using PetSaver.Business.Anuncios;
using PetSaver.Business.Usuarios;
using PetSaver.Contracts.Chat;
using PetSaver.Entity.Chat;
using PetSaver.Exceptions;
using PetSaver.Repository.Chat;
using System.Collections.Generic;
using System.Linq;

namespace PetSaver.Business.Chat
{
    public class InboxBusiness : BaseBusiness<InboxEntity, InboxRepository>
    {
        #region .: Cadastro :.

        public void NovaMensagem(CadastroInboxRequest aRequest)
        {
            ValidarNovaMensagem(aRequest);

            var interesseEntity = new InteresseBusiness().Listar(aRequest.IdInteresse);

            if (interesseEntity == null)
            {
                throw new BusinessException("O Id do interesse é inválido.");
            }

            var inboxEntity = new InboxEntity()
            {
                IdInteresse = aRequest.IdInteresse,
                IdRemetente = aRequest.IdUsuario,
                Mensagem = aRequest.Mensagem,
                FoiLida = false
            };

            if (aRequest.IdUsuario != interesseEntity.IdUsuario)
            {
                inboxEntity.IdDestinatário = interesseEntity.IdUsuario;
            }
            else
            {
                var anuncioEntity = new AnuncioBusiness().Listar(interesseEntity.IdAnuncio);

                if (anuncioEntity == null)
                {
                    throw new BusinessException("O anúncio não foi encontrado.");
                }

                inboxEntity.IdDestinatário = anuncioEntity.IdUsuario;
            }

            Inserir(inboxEntity);

            var idLogin = new UsuarioBusiness().Listar(inboxEntity.IdDestinatário).IdLogin;

            new EmailBusiness().ChatRespondido(new LoginBusiness().Listar(idLogin).Email);
        }

        private void ValidarNovaMensagem(CadastroInboxRequest aRequest)
        {
            if (aRequest == null)
            {
                throw new BusinessException("O objeto de request é inválido.");
            }

            if (aRequest.IdLogin == default)
            {
                throw new BusinessException("O Id do login do usuário é inválido.");
            }

            if (aRequest.IdUsuario == default)
            {
                throw new BusinessException("O Id do usuário é inválido.");
            }

            if (aRequest.IdInteresse == default)
            {
                throw new BusinessException("O Id do interesse é inválido.");
            }

            if (string.IsNullOrEmpty(aRequest.Mensagem))
            {
                throw new BusinessException("A mensagem é inválida.");
            }
        }

        #endregion

        #region .: Buscas :.

        public IEnumerable<InboxResponseContract> BuscarTodasMensagens(int aIdInteresse, int aIdUsuario)
        {
            if (aIdInteresse == default)
            {
                throw new BusinessException("O Id do interesse é inválido.");
            }

            if (aIdUsuario == default)
            {
                throw new BusinessException("O Id do usuário é inválido.");
            }

            return new InboxRepository().BuscarMensagensPorInteresse(aIdInteresse).OrderBy(x => x.DataCadastro).Select(x => new InboxResponseContract()
            {
                Mensagem = x.Mensagem,
                Enviada = x.IdRemetente == aIdUsuario
            });
        }

        #endregion
    }
}
