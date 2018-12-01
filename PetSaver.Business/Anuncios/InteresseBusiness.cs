using System;
using System.Collections.Generic;
using System.Linq;
using PetSaver.Business.Usuarios;
using PetSaver.Contracts.Anuncios;
using PetSaver.Entity.Anuncios;
using PetSaver.Entity.Enums.Status;
using PetSaver.Exceptions;
using PetSaver.Repository.Anuncios;

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
                IdAnuncio = Convert.ToInt32(x.ANU_CODIGO),
                Pet = string.IsNullOrEmpty(x.PET_NOME) ? Utilities.Constantes.Desconhecido : Convert.ToString(x.PET_NOME),
                Animal = Convert.ToString(x.ANI_NOME),
                RacaEspecie = string.IsNullOrEmpty(x.RAC_NOME) ? Utilities.Constantes.Indefinido : Convert.ToString(x.RAC_NOME),
                Data = Convert.ToDateTime(x.INT_DTHCADASTRO).ToString("dd/MM/yyyy"),
                TipoAnuncio = Convert.ToString(x.ANT_DESCRICAO),
                Usuario = Convert.ToString(x.USU_NOME)
            });
        }

        #endregion
    }
}
