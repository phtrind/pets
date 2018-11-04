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
                config.AddMap(new TipoLoginMap());
                config.AddMap(new TipoUsuarioMap());
                config.AddMap(new UsuarioMap());
                config.ForDommel();
            });
        }
    }
}
