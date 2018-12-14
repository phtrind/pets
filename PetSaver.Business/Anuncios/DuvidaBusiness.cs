using PetSaver.Business.Usuarios;
using PetSaver.Contracts.Anuncios;
using PetSaver.Contracts.Paginas.Response.PetPage;
using PetSaver.Entity.Anuncios;
using PetSaver.Exceptions;
using PetSaver.Repository.Anuncios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetSaver.Business.Anuncios
{
    public class DuvidaBusiness : BaseBusiness<DuvidaEntity, DuvidaRepository>
    {
        public IEnumerable<DuvidaContract> BuscarPorAnuncio(int aIdAnuncio)
        {
            return new DuvidaRepository().BuscarPorAnuncio(aIdAnuncio).Select(x => new DuvidaContract()
            {
                IdDuvida = x.Id,
                Pergunta = x.Pergunta,
                Resposta = x.Resposta
            });
        }

        public int Cadastrar(CadastrarDuvidaRequest aRequest)
        {
            if (aRequest.IdUsuario == default)
            {
                throw new BusinessException("Não é possível cadastrar uma dúvida sem usuário.");
            }

            if (string.IsNullOrEmpty(aRequest.Pergunta))
            {
                throw new BusinessException("Não é possível cadastrar uma dúvida em branco.");
            }

            var usuario = new UsuarioBusiness().Listar(aRequest.IdUsuario);

            if (usuario == null)
            {
                throw new BusinessException("O usuário informado é inválido.");
            }

            var idDuvida = Inserir(new DuvidaEntity()
            {
                IdLoginCadastro = usuario.IdLogin,
                IdUsuario = aRequest.IdUsuario,
                IdAnuncio = aRequest.IdAnuncio,
                Pergunta = aRequest.Pergunta
            });

            var idLogin = new AnuncioBusiness().Listar(aRequest.IdAnuncio).IdLoginCadastro;

            new EmailBusiness().PerguntaRecebida(new LoginBusiness().Listar(idLogin).Email);

            return idDuvida;
        }

        public void CadastrarResposta(CadastrarRespostaRequest aRequest)
        {
            if (aRequest == null)
            {
                throw new BusinessException("O objeto de request é inválido.");
            }

            if (aRequest.IdUsuario == default)
            {
                throw new BusinessException("O Id do usuário é inválido.");
            }

            if (aRequest.IdLogin == default)
            {
                throw new BusinessException("O Id do login é inválido.");
            }

            if (string.IsNullOrEmpty(aRequest.Resposta))
            {
                throw new BusinessException("A resposta é inválida.");
            }

            var duvidaEntity = Listar(aRequest.IdDuvida);

            if (duvidaEntity == null)
            {
                throw new BusinessException("O Id da dúvida é inválido.");
            }

            var anuncioEntity = new AnuncioBusiness().Listar(duvidaEntity.IdAnuncio);

            if (anuncioEntity.IdUsuario != aRequest.IdUsuario)
            {
                throw new BusinessException("O usuário não é o dono do anúncio.");
            }

            duvidaEntity.Resposta = aRequest.Resposta;
            duvidaEntity.IdLoginAlteracao = aRequest.IdLogin;
            duvidaEntity.DataAlteracao = DateTime.Now;

            Atualizar(duvidaEntity);

            new EmailBusiness().PerguntaRespondida(new LoginBusiness().Listar(duvidaEntity.IdLoginCadastro).Email, duvidaEntity.IdAnuncio);
        }
    }
}
