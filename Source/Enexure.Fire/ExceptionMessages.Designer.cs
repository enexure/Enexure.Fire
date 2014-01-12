﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Enexure.Fire {
    using System;
    using System.Reflection;
    
    
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
    internal class ExceptionMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExceptionMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Enexure.Fire.ExceptionMessages", typeof(ExceptionMessages).GetTypeInfo().Assembly);
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
        ///   Looks up a localized string similar to Index provided must be a positive number.
        /// </summary>
        internal static string Enexure_ArgumentOutOfRange_GenericPositive {
            get {
                return ResourceManager.GetString("Enexure_ArgumentOutOfRange_GenericPositive", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Index referes to a location outside the bounds of the array.
        /// </summary>
        internal static string Enexure_ArgumentOutOfRange_Index {
            get {
                return ResourceManager.GetString("Enexure_ArgumentOutOfRange_Index", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Length provided exceeds length of the array.
        /// </summary>
        internal static string Enexure_ArgumentOutOfRange_LengthTooLarge {
            get {
                return ResourceManager.GetString("Enexure_ArgumentOutOfRange_LengthTooLarge", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Selected subsection of the array exceeds the bounds of the array.
        /// </summary>
        internal static string Enexure_ArgumentOutOfRange_SequenceExceedsBounds {
            get {
                return ResourceManager.GetString("Enexure_ArgumentOutOfRange_SequenceExceedsBounds", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value for {0} must not be null.
        /// </summary>
        internal static string Enexure_Fire_Contract_Required_ValueIsNull {
            get {
                return ResourceManager.GetString("Enexure_Fire_Contract_Required_ValueIsNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Target type {0} is not a value type or a non-abstract class.
        /// </summary>
        internal static string Enexure_Fire_Conversion_TypeConverter_Argument_TypeNotSupported {
            get {
                return ResourceManager.GetString("Enexure_Fire_Conversion_TypeConverter_Argument_TypeNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can not convert from {0} to {1}.
        /// </summary>
        internal static string Enexure_Fire_Conversion_TypeConverter_InvalidOperation_NotSupported {
            get {
                return ResourceManager.GetString("Enexure_Fire_Conversion_TypeConverter_InvalidOperation_NotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The key {0} is not valid.
        /// </summary>
        internal static string Enexure_Fire_Database_ConnectonString_KeyNotValid {
            get {
                return ResourceManager.GetString("Enexure_Fire_Database_ConnectonString_KeyNotValid", resourceCulture);
            }
        }
    }
}
