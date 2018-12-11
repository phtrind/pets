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
        public void AnuncioPublicado(int aIdAnuncio, string aEmail)
        {
            new Email().EnviarEmail("Olá Saver, seu anúncio está ativo!", Resources.EmailAnuncioAprovado, aEmail, true);
        }
    }
}
