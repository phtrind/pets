using System.Collections.Generic;

namespace PetSaver.Utilities
{
    public static class MimeTypeHelper
    {
        /// <summary>
        /// Lista dos MimeTypes suportados pela aplicação
        /// </summary>
        private static readonly List<string> SupportedTypes = new List<string>
        {
            "image/gif",
            "image/jpeg",
            "image/jpg",
            "image/png"
        };

        /// <summary>
        /// Valida o MimeType recebido de acordo com a lista de tipos suportados
        /// </summary>
        /// <param name="aMimeType"></param>
        /// <returns></returns>
        public static bool MimeIsValid(string aMimeType)
        {
            return SupportedTypes.Contains(aMimeType);
        }

        /// <summary>
        /// Retorna a extensão referente ao MimeType recebido
        /// </summary>
        /// <param name="aMimeType"></param>
        /// <returns></returns>
        public static string GetExtension(string aMimeType)
        {
            if (string.IsNullOrEmpty(aMimeType))
            {
                return null;
            }

            return aMimeType.Replace("image/", ".");
        }

    }
}
