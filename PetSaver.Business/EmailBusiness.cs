using PetSaver.Business.Properties;
using PetSaver.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSaver.Business
{
    public class EmailBusiness
    {
        public void AnuncioAprovado(int aIdAnuncio, string aEmail)
        {
            string conteudo = Resources.EmailAnuncioAprovado
                                            .Replace("__LinkAnuncio__", $"{Constantes.LinkPetSaver}pet.html?idAnuncio={aIdAnuncio}")
                                            .Replace("__LinkPetSaver__", Constantes.LinkPetSaver)
                                            .Replace("__LinkInstagram__", Constantes.LinkInstagram);

            new Email().EnviarEmail("Olá Saver, seu anúncio está ativo!", conteudo, aEmail, true);
        }

        public void CadastroUsuarioAprovado(string aEmail)
        {
            string conteudo = Resources.EmailCadastroUsuarioAprovado
                                            .Replace("__LinkPetSaver__", Constantes.LinkPetSaver)
                                            .Replace("__LinkInstagram__", Constantes.LinkInstagram);

            new Email().EnviarEmail("Olá Saver, seja bem vindo!", conteudo, aEmail, true);
        }

        public void AlteracaoStatusAnuncio(string aEmail)
        {
            string conteudo = Resources.EmailAlteracaoStatusAnuncio
                                            .Replace("__LinkPetSaver__", Constantes.LinkPetSaver);

            new Email().EnviarEmail("Olá Saver, status alterado com sucesso!", conteudo, aEmail, true);
        }

        public void InteresseDemonstrado(string aEmail)
        {
            string conteudo = Resources.EmailInteresseDemonstrado
                                            .Replace("__LinkPetSaver__", Constantes.LinkPetSaver);

            new Email().EnviarEmail("Olá Saver, recebemos o seu interesse!", conteudo, aEmail, true);
        }

        public void InteresseRemovido(string aEmail)
        {
            string conteudo = Resources.EmailInteresseRemovido
                                            .Replace("__LinkPetSaver__", Constantes.LinkPetSaver);

            new Email().EnviarEmail("Olá Saver, seu interesse foi cancelado!", conteudo, aEmail, true);
        }

        public void InteresseRecebido(string aEmail)
        {
            string conteudo = Resources.EmailInteresseRecebido
                                            .Replace("__LinkPetSaver__", Constantes.LinkPetSaver);

            new Email().EnviarEmail("Olá Saver, encontramos um interessado no seu anúncio!", conteudo, aEmail, true);
        }
    }
}
