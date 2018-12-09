using PetSaver.Contracts.FaleConosco;
using PetSaver.Entity.Contato;
using PetSaver.Repository.Contato;

namespace PetSaver.Business.Contato
{
    public class FaleConoscoBusiness : BaseBusiness<FaleConoscoEntity, FaleConoscoRepository>
    {
        public void Cadastrar(CadastrarFaleConoscoRequest aRequest)
        {
            Inserir(new FaleConoscoEntity()
            {
                IdUsuario = aRequest.IdUsuario,
                Email = aRequest.Email,
                Mensagem = aRequest.Mensagem
            });
        }
    }
}
