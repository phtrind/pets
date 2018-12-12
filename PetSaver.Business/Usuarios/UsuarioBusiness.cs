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
            int idUsuario;

            using (var transaction = new TransactionScope())
            {
                var idLogin = new LoginBusiness().Inserir(new LoginEntity()
                {
                    Email = aObjeto.Email,
                    Senha = aObjeto.Senha,
                    IdTipo = Utilities.Conversor.EnumParaInt(TiposLogin.Usuario)
                });

                idUsuario = new UsuarioBusiness().Inserir(new UsuarioEntity()
                {
                    Nome = aObjeto.Nome,
                    Sobrenome = aObjeto.Sobrenome,
                    DataNascimento = aObjeto.DataNascimento,
                    IdTipo = Utilities.Conversor.EnumParaInt(TiposUsuario.PessoaFisica),
                    IdLogin = idLogin,
                    IdLoginCadastro = idLogin
                });

                transaction.Complete();
            }

            new EmailBusiness().CadastroUsuarioAprovado(aObjeto.Email);

            return idUsuario;
        }

        public void Editar(CadastroEdicaoRequest aRequest)
        {
            if (aRequest.IdUsuario == default)
            {
                throw new BusinessException("O Id do usuário é inválido.");
            }

            if (aRequest.IdLogin == default)
            {
                throw new BusinessException("O Id do login é inválido.");
            }

            var usuarioEntity = Listar(aRequest.IdUsuario);

            usuarioEntity.Nome = aRequest.Nome;
            usuarioEntity.Sobrenome = aRequest.Sobrenome;
            usuarioEntity.Sexo = aRequest.Sexo;
            usuarioEntity.Documento = aRequest.Documento;
            usuarioEntity.IdLoginAlteracao = aRequest.IdLogin;

            var loginBusiness = new LoginBusiness();

            var loginEntity = loginBusiness.Listar(usuarioEntity.IdLogin);

            loginEntity.Senha = aRequest.Senha;
            loginEntity.IdLoginAlteracao = aRequest.IdLogin;

            using (var transaction = new TransactionScope())
            {
                Atualizar(usuarioEntity);

                loginBusiness.Atualizar(loginEntity);

                transaction.Complete();
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

            dynamic retornoDb = new UsuarioRepository().BuscarInformacoesSession(aEmail);

            if (retornoDb == null)
            {
                throw new BusinessException("O usuário não foi encontrado.");
            }

            return new UsuarioSessionContract()
            {
                IdLogin = Convert.ToInt32(retornoDb.LOG_CODIGO),
                IdUsuario = Convert.ToInt32(retornoDb.USU_CODIGO),
                Nome = Convert.ToString(retornoDb.USU_NOME),
                DthValidadeToken = DateTime.Now.AddHours(Utilities.Constantes.HorasValidadeToken - 0.5)
            };
        }

        public UsuarioCompletoResponse BuscarCompleto(int aIdUsuario)
        {
            if (aIdUsuario == default)
            {
                throw new BusinessException("O Id é inválido.");
            }

            dynamic retornoDb = new UsuarioRepository().BuscarCompleto(aIdUsuario);

            if (retornoDb == null)
            {
                throw new BusinessException("O usuário não foi encontrado.");
            }

            return new UsuarioCompletoResponse()
            {
                IdUsuario = Convert.ToInt32(retornoDb.USU_CODIGO),
                Nome = Convert.ToString(retornoDb.USU_NOME),
                Sobrenome = Convert.ToString(retornoDb.USU_SOBRENOME),
                Nascimento = Convert.ToDateTime(retornoDb.USU_DTHNASCIMENTO),
                Sexo = retornoDb.USU_SEXO != null ? Convert.ToString(retornoDb.USU_SEXO) : null,
                Documento = Convert.ToString(retornoDb.USU_DOCUMENTO),
                Email = Convert.ToString(retornoDb.LOG_EMAIL),
                Senha = Convert.ToString(retornoDb.LOG_SENHA)
            };
        }

        #endregion
    }
}
