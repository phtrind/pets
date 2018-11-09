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
                config.AddMap(new HistoricoLoginMap());
                config.AddMap(new TipoUsuarioMap());
                config.AddMap(new UsuarioMap());
                config.AddMap(new EnderecoMap());
                config.AddMap(new CidadeMap());
                config.AddMap(new EstadoMap());
                config.AddMap(new LocalizacaoMap());
                config.AddMap(new AnimalMap());
                config.AddMap(new RacaEspecieMap());
                config.AddMap(new CorMap());
                config.AddMap(new PetMap());
                config.AddMap(new SexoMap());
                config.AddMap(new AnuncioMap());
                config.AddMap(new InteresseMap());
                config.ForDommel();
            });
        }
    }
}
