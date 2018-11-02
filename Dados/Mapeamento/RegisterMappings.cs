using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;

namespace PetSaver.Repository
{
    public static class RegisterMappings
    {
        public static void Register()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new LoginMap());
                config.ForDommel();
            });
        }
    }
}
