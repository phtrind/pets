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
    }
}
