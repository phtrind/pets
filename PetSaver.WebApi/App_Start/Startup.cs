using Bugsnag.AspNet.WebApi;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using PetSaver.WebApi.Authentication;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

[assembly: OwinStartup(typeof(PetSaver.WebApi.Startup))]

namespace PetSaver.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            Business.Util.MapearBaseDados();

            config.UseBugsnag(Bugsnag.ConfigurationSection.Configuration.Settings);

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ConfigureAccessToken(app);

            app.UseWebApi(config);

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.Indent = true;
        }

        private void ConfigureAccessToken(IAppBuilder app)
        {
            var optionsConfigurationToken = new OAuthAuthorizationServerOptions()
            {
                //Permitindo acesso ao endereço de fornecimento do token de acesso sem 
                //precisar de HTTPS (AllowInsecureHttp). 
                //Em produção o valor deve ser false.
                AllowInsecureHttp = true,

                //Configurando o endereço do fornecimento do token de acesso (TokenEndpointPath).
                TokenEndpointPath = new PathString("/api/token"),

                //Configurando por quanto tempo um token de acesso já forncedido valerá (AccessTokenExpireTimeSpan).
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(Utilities.Constantes.HorasValidadeToken),

                //Como verificar usuário e senha para fornecer tokens de acesso? Precisamos configurar o Provider dos tokens
                Provider = new ProviderTokenAccess()
            };

            //Estas duas linhas ativam o fornecimento de tokens de acesso numa WebApi
            app.UseOAuthAuthorizationServer(optionsConfigurationToken);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}