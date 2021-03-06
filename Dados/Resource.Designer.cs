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
        ///   Looks up a localized string similar to SELECT TOP 4 P.PET_NOME, 
        ///             P.PTS_CODIGO, 
        ///             P.PID_CODIGO, 
        ///             A.CID_CODIGO, 
        ///             A.EST_CODIGO, 
        ///             F.ANF_LINK
        ///FROM ANU_ANUNCIOS A
        ///     INNER JOIN PET_PETS P ON A.PET_CODIGO = P.PET_CODIGO
        ///     LEFT JOIN ANF_ANUNCIOFOTOS F ON F.ANU_CODIGO = A.ANU_CODIGO
        ///                                     AND F.ANF_DESTAQUE = 1
        ///ORDER BY A.ANU_DTHCADASTRO.
        /// </summary>
        internal static string BuscarAnunciosDestaques {
            get {
                return ResourceManager.GetString("BuscarAnunciosDestaques", resourceCulture);
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
    }
}
