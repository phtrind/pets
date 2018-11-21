﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetSaver.Repository {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PetSaver.Repository.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT U.USU_CODIGO, 
        ///       U.USU_NOME, 
        ///       P.PET_NOME, 
        ///       RE.RAC_NOME, 
        ///       C.CID_NOME, 
        ///       E.EST_SIGLA, 
        ///       PTS.PTS_DESCRICAO AS SEXO, 
        ///       PID.PID_DESCRICAO AS IDADE, 
        ///       PPR.PPR_DESCRICAO AS PORTE, 
        ///       P.PET_PESO, 
        ///       COR1.COR_NOME AS COR_PRIMARIA, 
        ///       COR2.COR_NOME AS COR_SECUNDARIA, 
        ///       PPL.PPL_DESCRICAO AS PELO, 
        ///       P.PET_VACINADO, 
        ///       P.PET_VERMIFUGADO, 
        ///       P.PET_CASTRADO, 
        ///       P.PET_DESCRICAO, 
        ///       L.LOC_LATITUDE, 
        ///     [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string AbrirAnuncio {
            get {
                return ResourceManager.GetString("AbrirAnuncio", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE ANF_ANUNCIOFOTOS
        ///  SET 
        ///      ANF_DESTAQUE = 0
        ///WHERE ANU_CODIGO =
        ///(
        ///    SELECT ANU_CODIGO
        ///    FROM ANF_ANUNCIOFOTOS
        ///    WHERE ANF_CODIGO = @IdFoto
        ///);
        ///
        ///UPDATE ANF_ANUNCIOFOTOS
        ///  SET 
        ///      ANF_DESTAQUE = 1
        ///WHERE ANF_CODIGO = @IdFoto.
        /// </summary>
        internal static string AlterarFotoDestaque {
            get {
                return ResourceManager.GetString("AlterarFotoDestaque", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT *
        ///FROM ANG_ANUNCIOSGOSTEI
        ///WHERE ANU_CODIGO = @IdAnuncio
        ///      AND USU_CODIGO = @IdUsuario.
        /// </summary>
        internal static string BuscarAnuncioGosteiPorAnuncioUsuario {
            get {
                return ResourceManager.GetString("BuscarAnuncioGosteiPorAnuncioUsuario", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT P.PET_NOME, 
        ///       PTS.PTS_DESCRICAO, 
        ///       PID.PID_DESCRICAO, 
        ///       E.EST_SIGLA, 
        ///       C.CID_NOME, 
        ///       F.ANF_LINK, 
        ///       ANT.ANT_DESCRICAO, 
        ///       A.ANU_CODIGO
        ///FROM ANU_ANUNCIOS A
        ///     INNER JOIN PET_PETS P ON A.PET_CODIGO = P.PET_CODIGO
        ///     INNER JOIN EST_ESTADOS E ON A.EST_CODIGO = E.EST_CODIGO
        ///     INNER JOIN CID_CIDADES C ON C.CID_CODIGO = A.CID_CODIGO
        ///     LEFT JOIN ANF_ANUNCIOFOTOS F ON F.ANU_CODIGO = A.ANU_CODIGO
        ///                                     AND F.ANF_DESTA [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string BuscarAnuncios {
            get {
                return ResourceManager.GetString("BuscarAnuncios", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT TOP 4 P.PET_NOME, 
        ///             PTS.PTS_DESCRICAO, 
        ///             PID.PID_DESCRICAO, 
        ///             E.EST_SIGLA, 
        ///             C.CID_NOME, 
        ///             F.ANF_LINK, 
        ///             ANT.ANT_DESCRICAO, 
        ///             A.ANU_CODIGO
        ///FROM ANU_ANUNCIOS A
        ///     INNER JOIN PET_PETS P ON A.PET_CODIGO = P.PET_CODIGO
        ///     INNER JOIN EST_ESTADOS E ON A.EST_CODIGO = E.EST_CODIGO
        ///     INNER JOIN CID_CIDADES C ON C.CID_CODIGO = A.CID_CODIGO
        ///     LEFT JOIN ANF_ANUNCIOFOTOS F ON F.ANU_CODIGO = A.ANU_CODIGO
        ///     [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string BuscarAnunciosDestaques {
            get {
                return ResourceManager.GetString("BuscarAnunciosDestaques", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT *
        ///FROM AVA_AVALIACOES
        ///WHERE USU_AVALIADO = @IdUsuario.
        /// </summary>
        internal static string BuscarAvaliacaoPorUsuario {
            get {
                return ResourceManager.GetString("BuscarAvaliacaoPorUsuario", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT *
        ///FROM CID_CIDADES
        ///WHERE EST_CODIGO = @IdEstado
        ///ORDER BY CID_NOME.
        /// </summary>
        internal static string BuscarCidadePorEstado {
            get {
                return ResourceManager.GetString("BuscarCidadePorEstado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT *
        ///FROM DUV_DUVIDAS
        ///WHERE ANU_CODIGO = @IdAnuncio.
        /// </summary>
        internal static string BuscarDuvidasPorAnuncio {
            get {
                return ResourceManager.GetString("BuscarDuvidasPorAnuncio", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT *
        ///FROM ANF_ANUNCIOFOTOS
        ///WHERE ANU_CODIGO = @IdAnuncio.
        /// </summary>
        internal static string BuscarFotosPorAnuncio {
            get {
                return ResourceManager.GetString("BuscarFotosPorAnuncio", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT L.LOG_CODIGO, 
        ///       U.USU_CODIGO, 
        ///       U.USU_NOME
        ///FROM LOG_LOGINS L
        ///     INNER JOIN USU_USUARIOS U ON L.LOG_CODIGO = U.LOG_CODIGO
        ///WHERE L.LOG_EMAIL = @Email.
        /// </summary>
        internal static string BuscarInformacoesSession {
            get {
                return ResourceManager.GetString("BuscarInformacoesSession", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT *
        ///FROM INT_INTERESSES
        ///WHERE USU_CODIGO = @IdUsuario
        ///      AND ANU_CODIGO = @IdAnuncio.
        /// </summary>
        internal static string BuscarInteressePorUsuarioAnuncio {
            get {
                return ResourceManager.GetString("BuscarInteressePorUsuarioAnuncio", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT *
        ///FROM LOG_LOGINS
        ///WHERE LOG_EMAIL = @Email.
        /// </summary>
        internal static string BuscarLoginPorEmail {
            get {
                return ResourceManager.GetString("BuscarLoginPorEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT *
        ///FROM LOG_LOGINS
        ///WHERE LOG_EMAIL = @Email
        ///      AND LOG_SENHA = @Senha.
        /// </summary>
        internal static string BuscarLoginPorEmailSenha {
            get {
                return ResourceManager.GetString("BuscarLoginPorEmailSenha", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT RAC_CODIGO, 
        ///       RAC_NOME
        ///FROM RAC_RACASESPECIES
        ///WHERE ANI_CODIGO = @IdAnimal
        ///ORDER BY RAC_NOME.
        /// </summary>
        internal static string BuscarRacaEspeciePorAnimal {
            get {
                return ResourceManager.GetString("BuscarRacaEspeciePorAnimal", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT *
        ///FROM USU_USUARIOS
        ///WHERE USU_DOCUMENTO = @Documento.
        /// </summary>
        internal static string BuscarUsuarioPorDocumento {
            get {
                return ResourceManager.GetString("BuscarUsuarioPorDocumento", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT *
        ///FROM USU_USUARIOS
        ///WHERE LOG_CODIGO = @IdLogin.
        /// </summary>
        internal static string BuscarUsuarioPorLogin {
            get {
                return ResourceManager.GetString("BuscarUsuarioPorLogin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] estados_cidades {
            get {
                object obj = ResourceManager.GetObject("estados_cidades", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT A.ANU_CODIGO, 
        ///       P.PET_NOME, 
        ///       ANI.ANI_NOME, 
        ///       A.ANU_DTHCADASTRO, 
        ///       ANS.ANS_DESCRICAO,
        ///(
        ///    SELECT COUNT(*)
        ///    FROM AVI_ANUNCIOSVISITAS
        ///    WHERE ANU_CODIGO = A.ANU_CODIGO
        ///) AS VISUALIZACOES, 
        ///(
        ///    SELECT COUNT(*)
        ///    FROM INT_INTERESSES
        ///    WHERE ANU_CODIGO = A.ANU_CODIGO
        ///) AS INTERESSADOS
        ///FROM ANU_ANUNCIOS A
        ///     INNER JOIN PET_PETS P ON A.PET_CODIGO = P.PET_CODIGO
        ///     INNER JOIN ANI_ANIMAIS ANI ON P.ANI_CODIGO = ANI.ANI_CODIGO
        ///     INNER JOIN ANS_ANUNCI [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string RelatorioDoacoes {
            get {
                return ResourceManager.GetString("RelatorioDoacoes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DELETE FROM ANG_ANUNCIOSGOSTEI
        ///WHERE ANU_CODIGO = @IdAnuncio
        ///      AND USU_CODIGO = @IdUsuario.
        /// </summary>
        internal static string RemoverGostei {
            get {
                return ResourceManager.GetString("RemoverGostei", resourceCulture);
            }
        }
    }
}
