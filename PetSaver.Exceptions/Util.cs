using System;

namespace PetSaver.Exceptions
{
    public static class Util
    {
        public static readonly string MensagemErroNaoTratado = "Houve um erro inesperado durante o processamento.";

        public static void TratarExcecao(Exception ex)
        {
            if (!(ex is HandledException))
            {
                Bugsnag.AspNet.Client.Current.Notify(ex);
            }
        }
    }
}
