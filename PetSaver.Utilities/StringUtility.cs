namespace PetSaver.Utilities
{
    public static class StringUtility
    {
        /// <summary>
        /// Método que remove os caracteres não numéricos de uma string
        /// </summary>
        /// <param name="aString">String a ser tratada</param>
        /// <returns></returns>
        public static string RemoverNaoNumericos(string aString)
        {
            return RegexUtility.rgNonDigits.Replace(aString, "");
        }
    }
}
