using System.Text.RegularExpressions;

namespace PetSaver.Utilities
{
    public static class RegexUtility
    {
        public static readonly Regex rgNonDigits = new Regex(@"[^\d]+");
    }
}
