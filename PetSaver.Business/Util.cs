using PetSaver.Repository;

namespace PetSaver.Business
{
    public static class Util
    {
        public static void MapearBaseDados()
        {
            RegisterMappings.Register();
        }
    }
}
