using PetSaver.Contracts.Anuncios;
using PetSaver.Entity.Pets;
using PetSaver.Exceptions;
using PetSaver.Repository.Pets;

namespace PetSaver.Business.Pets
{
    public class PetBusiness : BaseBusiness<PetEntity, PetRepository>
    {
        public int Cadastrar(int aIdLogin, CadastroPetContract aRequest)
        {
            if (aRequest == null)
            {
                throw new BusinessException("O objeto do Pet não pode ser nulo.");
            }

            return Inserir(new PetEntity()
            {
                IdLoginCadastro = aIdLogin,
                IdAnimal = aRequest.IdAnimal,
                IdRacaEspecie = aRequest.IdRacaEspecie,
                IdSexo = aRequest.IdSexo,
                IdIdade = aRequest.IdIdade,
                IdPorte = aRequest.IdPorte,
                IdPelo = aRequest.IdPelo,
                IdCorPrimaria = aRequest.IdCorPrimaria,
                IdCorSecundaria = aRequest.IdCorSecundaria,
                Nome = aRequest.Nome,
                Peso = aRequest.Peso,
                Vacinado = aRequest.Vacinado,
                Vermifugado = aRequest.Vermifugado,
                Castrado = aRequest.Castrado,
                Descricao = aRequest.Descricao
            });
        }
    }
}
