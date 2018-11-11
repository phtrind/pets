using PetSaver.Business.Localizacao;
using PetSaver.Contracts.Usuario;
using PetSaver.Entity.Enums;
using PetSaver.Entity.Usuarios;
using PetSaver.Exceptions;
using PetSaver.Repository.Usuarios;
using System;
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

        #region .: Buscas :.

        public UsuarioSessionContract BuscarInformacoesSession(string aEmail)
        {
            if (string.IsNullOrEmpty(aEmail))
            {
                throw new BusinessException("É obrigatorio informar o e-mail do usuário.");
            }

            dynamic teste = new UsuarioRepository().BuscarInformacoesSession(aEmail);

            if (teste == null)
            {
                throw new BusinessException("O usuário não foi encontrado.");
            }

            return new UsuarioSessionContract()
            {
                IdLogin = Convert.ToInt32(teste.LOG_CODIGO),
                IdUsuario = Convert.ToInt32(teste.USU_CODIGO),
                Nome = Convert.ToString(teste.USU_NOME)
            };
        }

        #endregion
    }
}
