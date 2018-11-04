using Microsoft.Owin.Security.OAuth;
using PetSaver.Business.Usuarios;
using PetSaver.Exceptions;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PetSaver.WebApi.Authentication
{
    internal class ProviderTokenAccess : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication
            (OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                new LoginBusiness().ValidarLogin(context.UserName, context.Password);

                var identyUser = new ClaimsIdentity(context.Options.AuthenticationType);

                identyUser.AddClaim(new Claim(ClaimTypes.Role, "user"));

                context.Validated(identyUser);
            }
            catch (BusinessException ex)
            {
                context.SetError("Unauthorized", ex.Message);
            }
            catch (Exception ex)
            {
                Util.TratarExcecao(ex);

                context.SetError("UnexpectedError", Util.MensagemErroNaoTratado);
            }
        }
    }
}