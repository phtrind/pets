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

        public int CadastrarBasico(CadastroBasicoRequest aObjeto)
        {
            using (var transaction = new TransactionScope())
            {
                var idLogin = new LoginBusiness().Inserir(new LoginEntity()
                {
                    Email = aObjeto.Email,
                    Senha = aObjeto.Senha,
                    IdTipo = Utilities.Conversor.EnumParaInt(TiposLogin.Usuario)
                });

                var idUsuario = new UsuarioBusiness().Inserir(new UsuarioEntity()
                {
                    Nome = aObjeto.Nome,
                    Sobrenome = aObjeto.Sobrenome,
                    DataNascimento = aObjeto.DataNascimento,
                    IdTipo = Utilities.Conversor.EnumParaInt(TiposUsuario.PessoaFisica),
                    IdLogin = idLogin,
                    IdLoginCadastro = idLogin
                });

                transaction.Complete();

                return idUsuario;
            }
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
                Nome = Convert.ToString(teste.USU_NOME),    
                DthValidadeToken = DateTime.Now.AddHours(Utilities.Constantes.HorasValidadeToken - 0.5)
            };
        }

        #endregion
    }
}
