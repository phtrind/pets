using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSaver.Exceptions
{
    public static class Util
    {
        public static readonly string MensagemErroNaoTratado = "Houve um erro inesperado durante o processamento. Entraremos em contato assim que estiver solucionado";

        public static void TratarExcecao(Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
