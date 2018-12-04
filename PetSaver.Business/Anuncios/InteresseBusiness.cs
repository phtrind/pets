using PetSaver.Business.Usuarios;
using PetSaver.Contracts.Anuncios;
using PetSaver.Entity.Anuncios;
using PetSaver.Entity.Enums.Status;
using PetSaver.Entity.Enums.Tipos;
using PetSaver.Exceptions;
using PetSaver.Repository.Anuncios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace PetSaver.Business.Anuncios
{
    public class InteresseBusiness : BaseBusiness<InteresseEntity, InteresseRepository>
    {
        #region .: Cadastro :.

        public int Cadastrar(CadastrarInteresseRequest aRequest)
        {
            if (aRequest.IdUsuario == default)
            {
                throw new BusinessException("Não é possível cadastrar um interesse sem usuário.");
            }

            if (aRequest.IdAnuncio == default)
            {
                throw new BusinessException("Não é possível cadastrar um interesse sem anúncio.");
            }

            return Inserir(new InteresseEntity()
            {
                IdAnuncio = aRequest.IdAnuncio,
                IdUsuario = aRequest.IdUsuario,
                IdStatus = Utilities.Conversor.EnumParaInt(StatusInteresse.EmAndamento),
                IdLoginCadastro = new UsuarioBusiness().Listar(aRequest.IdUsuario)?.IdLogin ?? default
            });
        }

        public void CancelarInteresse(CancelarInteresseRequest aRequest)
        {
            if (aRequest == null)
            {
                throw new BusinessException("O objeto de request é inválido.");
            }

            if (aRequest.IdInteresse == default)
            {
                throw new BusinessException("O Id do interesse é inválido.");
            }

            if (aRequest.IdUsuario == default)
            {
                throw new BusinessException("O Id do usuário é inválido.");
            }

            if (aRequest.IdLogin == default)
            {
                throw new BusinessException("O Id do login do usuário é inválido.");
            }

            var interesseEntity = Listar(aRequest.IdInteresse);

            if (interesseEntity == null)
            {
                throw new BusinessException("O Id do interesse é inválido.");
            }

            if (interesseEntity.IdUsuario != aRequest.IdUsuario)
            {
                throw new BusinessException("Somente o usuário dono do interesse pode cancelá-lo");
            }

            interesseEntity.IdStatus = Utilities.Conversor.EnumParaInt(StatusInteresse.Finalizado);
            interesseEntity.IdLoginAlteracao = aRequest.IdLogin;
            interesseEntity.DataAlteracao = DateTime.Now;

            Atualizar(interesseEntity);
        }

        public void ConcretizarInteresse(ConcretizarInteresseRequest aRequest, TiposAnuncio aTipoAnuncio)
        {
            if (aRequest == null)
            {
                throw new BusinessException("O objeto de request é inválido.");
            }

            if (aRequest.IdUsuario == default)
            {
                throw new BusinessException("O Id do usuario é inválido.");
            }

            if (aRequest.IdLogin == default)
            {
                throw new BusinessException("O Id do login do usuário é inválido.");
            }

            var interesseEntity = Listar(aRequest.IdInteresse);

            if (interesseEntity == null)
            {
                throw new BusinessException("O Id do interesse é inválido.");
            }

            var anuncioBusiness = new AnuncioBusiness();

            var anuncioEntity = anuncioBusiness.Listar(interesseEntity.IdAnuncio);

            if (anuncioEntity.IdUsuario != aRequest.IdUsuario)
            {
                throw new BusinessException("O Id do usuário informado não é o Id do usuário dono do anúncio.");
            }

            interesseEntity.IdStatus = Utilities.Conversor.EnumParaInt(StatusInteresse.Concretizado);
            interesseEntity.IdLoginAlteracao = aRequest.IdLogin;
            interesseEntity.DataAlteracao = DateTime.Now;

            switch (aTipoAnuncio)
            {
                case TiposAnuncio.Doacao:
                    anuncioEntity.IdStatus = Utilities.Conversor.EnumParaInt(StatusAnuncio.Adotado);
                    break;
                case TiposAnuncio.PetPerdido:
                case TiposAnuncio.PetEncontrado:
                    anuncioEntity.IdStatus = Utilities.Conversor.EnumParaInt(StatusAnuncio.DeVoltaAoLar);
                    break;
                default:
                    throw new BusinessException("Tipo de anúncio não encontrado.");
            }

            anuncioEntity.IdLoginAlteracao = aRequest.IdLogin;
            anuncioEntity.DataAlteracao = DateTime.Now;

            using (var transaction = new TransactionScope())
            {
                Atualizar(interesseEntity);
                anuncioBusiness.Atualizar(anuncioEntity);

                transaction.Complete();
            }

        }

        #endregion

        #region .: Buscas :.

        public InteresseEntity BuscarPorUsuarioAnuncio(int aIdUsuario, int aIdAnuncio)
        {
            if (aIdUsuario == default || aIdAnuncio == default)
            {
                return null;
            }

            return new InteresseRepository().BuscarPorUsuarioAnuncio(aIdUsuario, aIdAnuncio);
        }

        public IEnumerable<RelatorioInteressesContract> BuscarRelatorioInteresses(RelatorioInteressesRequest aRequest)
        {
            if (aRequest == null)
            {
                throw new BusinessException("O objeto do request é inválido.");
            }

            if (aRequest.IdUsuario == default)
            {
                throw new BusinessException("O Id do usuário é inválido.");
            }

            return new InteresseRepository().BuscarRelatorioInteresses(aRequest).Select(x => new RelatorioInteressesContract()
            {
                IdInteresse = Convert.ToInt32(x.INT_CODIGO),
                IdAnuncio = Convert.ToInt32(x.ANU_CODIGO),
                Pet = string.IsNullOrEmpty(x.PET_NOME) ? Utilities.Constantes.Desconhecido : Convert.ToString(x.PET_NOME),
                Animal = Convert.ToString(x.ANI_NOME),
                RacaEspecie = string.IsNullOrEmpty(x.RAC_NOME) ? Utilities.Constantes.Indefinido : Convert.ToString(x.RAC_NOME),
                Data = Convert.ToDateTime(x.INT_DTHCADASTRO).ToString("dd/MM/yyyy"),
                TipoAnuncio = Convert.ToString(x.ANT_DESCRICAO),
                Usuario = Convert.ToString(x.USU_NOME),
                Status = Convert.ToString(x.INS_DESCRICAO)
            });
        }

        public IEnumerable<InteressadosContract> BuscarInteressados(int aIdAnuncio)
        {
            if (aIdAnuncio == default)
            {
                throw new BusinessException("O Id do anúncio é inválido.");
            }

            return new InteresseRepository().BuscarInteressadosPorAnuncio(aIdAnuncio).Select(x => new InteressadosContract()
            {
                IdInteresse = Convert.ToInt32(x.INT_CODIGO),
                Nome = Convert.ToString(x.USU_NOME),
                Data = Convert.ToDateTime(x.INT_DTHCADASTRO).ToString("dd/MM/yyyy"),
                Status = Convert.ToString(x.INS_DESCRICAO)
            });
        }

        #endregion
    }
}
