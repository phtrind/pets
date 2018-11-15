using System;

namespace PetSaver.Utilities
{
    public static class Conversor
    {
        public static int EnumParaInt(Enum aEnum)
        {
            return Convert.ToInt32(aEnum);
        }

        public static T IntParaEnum<T>(int aInteiro) where T : Enum
        {
            return (T)Enum.Parse(typeof(T), Convert.ToString(aInteiro));
        }

        public static int? EnumParaInt(object tiposAnuncios)
        {
            throw new NotImplementedException();
        }

        public static string DbBooleanToString(dynamic aDbBoolean)
        {
            try
            {
                if (aDbBoolean == null)
                {
                    return Constantes.Indefinido;
                }
                else if (Convert.ToBoolean(aDbBoolean))
                {
                    return "Sim";
                }
                else
                {
                    return "Não";
                }
            }
            catch (Exception)
            {
                return Constantes.Indefinido;
            }
        }
    }
}
