using PetSaver.Business.Usuarios;
using PetSaver.Contracts.Anuncios;
using PetSaver.Entity.Anuncios;
using PetSaver.Exceptions;
using PetSaver.Repository.Anuncios;
using System.Collections.Generic;

namespace PetSaver.Business.Anuncios
{
    public class DuvidaBusiness : BaseBusiness<DuvidaEntity, DuvidaRepository>
    {
        public IEnumerable<DuvidaEntity> BuscarPorAnuncio(int aIdAnuncio)
        {
            return new DuvidaRepository().BuscarPorAnuncio(aIdAnuncio);
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

            return Inserir(new DuvidaEntity()
            {
                IdLoginCadastro = usuario.IdLogin,
                IdUsuario = aRequest.IdUsuario,
                IdAnuncio = aRequest.IdAnuncio,
                Pergunta = aRequest.Pergunta
            });
        }
    }
}
