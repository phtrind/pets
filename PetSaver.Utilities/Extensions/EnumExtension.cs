using PetSaver.Entity.Enums.Pets;

namespace PetSaver.Utilities.Extensions
{
    public static class EnumExtension
    {
        public static string Traduzir(this Sexos aSexo)
        {
            switch (aSexo)
            {
                case Sexos.Macho:
                    return "Macho";
                case Sexos.Femea:
                    return "Fêmea";
                default:
                    return null;
            }
        }

        public static string Traduzir(this Idades aIdade)
        {
            switch (aIdade)
            {
                case Idades.RecemNascido:
                    return "Recém-nascido";
                case Idades.Jovem:
                    return "Jovem";
                case Idades.Adulto:
                    return "Adulto";
                case Idades.Idoso:
                    return "Idoso";
                default:
                    return null;
            }
        }
    }
}
