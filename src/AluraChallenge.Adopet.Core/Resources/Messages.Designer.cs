﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AluraChallenge.Adopet.Core.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AluraChallenge.Adopet.Core.Resources.Messages", typeof(Messages).Assembly);
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
        ///   Looks up a localized string similar to É necessário informar seu nome.
        /// </summary>
        internal static string EmptyNameException {
            get {
                return ResourceManager.GetString("EmptyNameException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Objeto não encontrado.
        /// </summary>
        internal static string EntityNotFoundException {
            get {
                return ResourceManager.GetString("EntityNotFoundException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to As senhas não batem.
        /// </summary>
        internal static string InvalidConfirmationPasswordException {
            get {
                return ResourceManager.GetString("InvalidConfirmationPasswordException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to É necessário informar um e-mail válido.
        /// </summary>
        internal static string InvalidEmailException {
            get {
                return ResourceManager.GetString("InvalidEmailException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A senha deve conter pelo menos uma letra maiúscula, um número e ter entre 6 e 15 caracteres.
        /// </summary>
        internal static string InvalidPasswordException {
            get {
                return ResourceManager.GetString("InvalidPasswordException", resourceCulture);
            }
        }
    }
}
