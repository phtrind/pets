using Dapper;
using PetSaver.Entity.Enums;
using PetSaver.Entity.Usuarios;
using PetSaver.Exceptions;
using System;
using System.Data.SqlClient;

namespace PetSaver.Repository.Usuarios
{
    public class UsuarioRepository : PessoaRepository<UsuarioEntity>
    {
        #region .: Validações :.

        protected override void ValidarAtributos(UsuarioEntity aObjeto)
        {
            base.ValidarAtributos(aObjeto);

            if (aObjeto.IdTipo == default || !Enum.IsDefined(typeof(TiposUsuario), aObjeto.IdTipo))
            {
                throw new DbValidationException("O Id do tipo de Usuário é inválido.");
            }

            if (!string.IsNullOrEmpty(aObjeto.Documento) && !DocumentoIsValid(Utilities.Conversor.IntParaEnum<TiposUsuario>(aObjeto.IdTipo), aObjeto.Documento))
            {
                throw new BusinessException("O documento do Usuário é inválido.");
            }

            var entidadePorDocumento = BuscarPorDocumento(aObjeto.Documento);

            if (entidadePorDocumento != null && entidadePorDocumento.Id != aObjeto.Id)
            {
                throw new BusinessException("Já existe um usuário relacionado ao Documento informado.");
            }

            var entidadePorLogin = BuscarPorLogin(aObjeto.IdLogin);

            if (entidadePorLogin != null && entidadePorLogin.Id != aObjeto.Id)
            {
                throw new BusinessException("Já existe um usuário relacionado ao Id Login informado.");
            }
        }

        private bool DocumentoIsValid(TiposUsuario aTipo, string aDocumento)
        {
            if (string.IsNullOrEmpty(aDocumento))
            {
                return false;
            }

            switch (aTipo)
            {
                case TiposUsuario.PessoaFisica:
                    return Utilities.Validador.CpfIsValid(aDocumento);
                case TiposUsuario.PessaJuridica:
                    return Utilities.Validador.CnpjIsValid(aDocumento);
                default:
                    return false;
            }
        }

        #endregion

        #region .: Buscas :.

        public UsuarioEntity BuscarPorLogin(int aIdLogin)
        {
            using (var db = new SqlConnection(StringConnection))
            {
                return db.QueryFirstOrDefault<UsuarioEntity>(Resource.BuscarUsuarioPorLogin, new { @IdLogin = aIdLogin });
            }
        }

        public UsuarioEntity BuscarPorDocumento(string aDocumento)
        {
            aDocumento = Utilities.StringUtility.RemoverNaoNumericos(aDocumento);

            using (var db = new SqlConnection(StringConnection))
            {
                return db.QueryFirstOrDefault<UsuarioEntity>(Resource.BuscarUsuarioPorDocumento, new { @Documento = aDocumento });
            }
        }

        public dynamic BuscarInformacoesSession(string aEmail)
        {
            if (string.IsNullOrEmpty(aEmail))
            {
                throw new BusinessException("É obrigatorio informar o e-mail do usuário");
            }

            using (var db = new SqlConnection(StringConnection))
            {
                return db.QueryFirstOrDefault(Resource.BuscarInformacoesSession, new { @Email = aEmail });
            }
        }

        public dynamic BuscarCompleto(int aIdUsuario)
        {
            if (aIdUsuario == default)
            {
                throw new BusinessException("O Id informado é inválido.");
            }

            using (var db = new SqlConnection(StringConnection))
            {
                return db.QueryFirstOrDefault(Resource.BuscarUsuarioCompleto, new { @IdUsuario = aIdUsuario });
            }
        }

        #endregion
    }
}
