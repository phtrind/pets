using PetSaver.Business.Localizacao;
using PetSaver.Contracts.Usuario;
using PetSaver.Entity.Enums;
using PetSaver.Entity.Usuarios;
using PetSaver.Repository.Usuarios;
using System.Transactions;

namespace PetSaver.Business.Usuarios
{
    public class UsuarioBusiness : BaseBusiness<UsuarioEntity, UsuarioRepository>
    {
        #region .: Cadastro :.

        public override int Inserir(UsuarioEntity aObjeto)
        {
            using (var transation = new TransactionScope())
            {
                if (aObjeto.Endereco != null && aObjeto.Endereco != default)
                {
                    aObjeto.IdEndereco = new EnderecoBusiness().Inserir(aObjeto.Endereco);
                }
                else
                {
                    aObjeto.IdEndereco = null;
                }

                aObjeto.IdLogin = new LoginRepository().Inserir(aObjeto.Login);

                aObjeto.IdLoginCadastro = aObjeto.IdLogin;

                var usuarioId = base.Inserir(aObjeto);

                transation.Complete();

                return usuarioId;
            }
        }

        public int CadastrarBasico(CadastroBasicoRequest aObjeto)
        {
            var usuario = new UsuarioEntity()
            {
                Nome = aObjeto.Nome,
                Sobrenome = aObjeto.Sobrenome,
                DataNascimento = aObjeto.DataNascimento,
                IdTipo = Utilities.Conversor.EnumParaInt(TiposUsuario.PessoaFisica),
                Login = new LoginEntity()
                {
                    Email = aObjeto.Email,
                    Senha = aObjeto.Senha,
                    IdTipo = Utilities.Conversor.EnumParaInt(TiposLogin.Usuario)
                }
            };

            return Inserir(usuario);
        } 

        #endregion
    }
}
