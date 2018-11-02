using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSaver.Utilities
{
    public static class Conversor
    {
        public static int EnumParaInt(Enum @enum)
        {
            return Convert.ToInt32(@enum);
        }
    }
}
