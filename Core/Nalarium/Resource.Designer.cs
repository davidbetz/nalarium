﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.235
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nalarium {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Jampad Technology, Inc. 2007-2013.Resource", typeof(Resource).Assembly);
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
        ///   Looks up a localized string similar to {0} is already defined..
        /// </summary>
        internal static string Activation_TypeAlreadyExists {
            get {
                return ResourceManager.GetString("Activation_TypeAlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid base64 data..
        /// </summary>
        internal static string Base64_InvalidData {
            get {
                return ResourceManager.GetString("Base64_InvalidData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CodeParserId is required when parsers are used..
        /// </summary>
        internal static string CodeParser_CodeParserIdRequired {
            get {
                return ResourceManager.GetString("CodeParser_CodeParserIdRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} is required in the application configuration file..
        /// </summary>
        internal static string Config_SettingRequired {
            get {
                return ResourceManager.GetString("Config_SettingRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Colons (&quot;:&quot;) are not allowed in Value names or scopes..
        /// </summary>
        internal static string General_ColonNotAllowed {
            get {
                return ResourceManager.GetString("General_ColonNotAllowed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Missing element &apos;{0}&apos;.
        /// </summary>
        internal static string General_MissingElement {
            get {
                return ResourceManager.GetString("General_MissingElement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ReportCreator is required for adding data..
        /// </summary>
        internal static string Report_CreatorRequired {
            get {
                return ResourceManager.GetString("Report_CreatorRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Reporter is not initialized..
        /// </summary>
        internal static string Report_NotInitialized {
            get {
                return ResourceManager.GetString("Report_NotInitialized", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} was not set on reporter..
        /// </summary>
        internal static string Report_NotSet {
            get {
                return ResourceManager.GetString("Report_NotSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Configured report {0} is not valid..
        /// </summary>
        internal static string Report_NotValid {
            get {
                return ResourceManager.GetString("Report_NotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to At least one text delimiter is required..
        /// </summary>
        internal static string Text_DelimiterRequired {
            get {
                return ResourceManager.GetString("Text_DelimiterRequired", resourceCulture);
            }
        }
    }
}
