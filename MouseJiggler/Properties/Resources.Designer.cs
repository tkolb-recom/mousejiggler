﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MouseJiggler.Properties {
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
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MouseJiggler.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Set number of seconds for the jiggle interval..
        /// </summary>
        internal static string Console_Interval {
            get {
                return ResourceManager.GetString("Console_Interval", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Start with jiggling enabled..
        /// </summary>
        internal static string Console_Jiggle {
            get {
                return ResourceManager.GetString("Console_Jiggle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Virtually jiggles the mouse, making the computer seem not idle..
        /// </summary>
        internal static string Console_Root {
            get {
                return ResourceManager.GetString("Console_Root", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Start with zen (invisible) jiggling enabled..
        /// </summary>
        internal static string Console_Zen {
            get {
                return ResourceManager.GetString("Console_Zen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mouse Jiggler is already running. Aborting..
        /// </summary>
        internal static string ConsoleError_AlreadyRunning {
            get {
                return ResourceManager.GetString("ConsoleError_AlreadyRunning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Interval cannot be longer than 180 seconds..
        /// </summary>
        internal static string ConsoleError_IntervalTooHigh {
            get {
                return ResourceManager.GetString("ConsoleError_IntervalTooHigh", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Interval cannot be shorter than 1 second..
        /// </summary>
        internal static string ConsoleError_IntervalTooLow {
            get {
                return ResourceManager.GetString("ConsoleError_IntervalTooLow", resourceCulture);
            }
        }
    }
}
