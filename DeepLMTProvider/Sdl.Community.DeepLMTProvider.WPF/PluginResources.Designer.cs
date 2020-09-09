﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sdl.Community.DeepLMTProvider.WPF {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class PluginResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal PluginResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Sdl.Community.DeepLMTProvider.WPF.PluginResources", typeof(PluginResources).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Looks up a localized string similar to The DeepL provider is returning a 403 forbidden status. This means there is a problem with your API key accessing the services you have requested. Please check you have a valid API key..
        /// </summary>
        public static string Forbidden_Message {
            get {
                return ResourceManager.GetString("Forbidden_Message", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sets whether the translated text should lean towards formal or informal language.
        ///This feature currently works for all target languages except &quot;ES&quot; (Spanish), &quot;JA&quot; (Japanese) and &quot;ZH&quot; (Chinese)..
        /// </summary>
        public static string FormalityNotAvailableReason {
            get {
                return ResourceManager.GetString("FormalityNotAvailableReason", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to *Not all languages are compatible with this option....
        /// </summary>
        public static string FormalityNotAvailableText {
            get {
                return ResourceManager.GetString("FormalityNotAvailableText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Looks up a localized string similar to The DeepL provider is returning a &amp;apos;{0}&amp;apos; status. This means is a problem on accessing the services you have requested. Please check you have a valid API key and also the internet connectivity..
        /// </summary>
        public static string ServerGeneralResponse_Message {
            get {
                return ResourceManager.GetString("ServerGeneralResponse_Message", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Settings Updated.
        /// </summary>
        public static string SettingsUpdated {
            get {
                return ResourceManager.GetString("SettingsUpdated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to In order for the new settings to take effect, you have to reopen the file for editing.
        /// </summary>
        public static string SettingsUpdated_ReopenFilesForEditing {
            get {
                return ResourceManager.GetString("SettingsUpdated_ReopenFilesForEditing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Close.
        /// </summary>
        public static string WindowsControl_Close {
            get {
                return ResourceManager.GetString("WindowsControl_Close", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Minimize.
        /// </summary>
        public static string WindowsControl_Minimize {
            get {
                return ResourceManager.GetString("WindowsControl_Minimize", resourceCulture);
            }
        }
    }
}
