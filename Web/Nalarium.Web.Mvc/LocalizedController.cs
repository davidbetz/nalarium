﻿using System;
using System.Resources;
//+
namespace Nalarium.Web.Mvc
{
    public abstract class LocalizedController : System.Web.Mvc.Controller, Nalarium.Web.Controls.ILocalizedPage
    {
        //- @AssemblyName -//
        /// <summary>
        /// Represents the name of the assembly from which to pull a resource manager.
        /// </summary>
        public abstract String AssemblyName { get; }

        //- BuiltInCultureArray -//
        /// <summary>
        /// Represents an array of cultures built into the assembly specifies in AssemblyName.
        /// </summary>
        public abstract String[] BuiltInCultureArray { get; }

        //- @DefaultResourceManager -//
        /// <summary>
        /// Represents the resource manager to use if no others are found.
        /// </summary>
        public abstract ResourceManager DefaultResourceManager { get; }

        //- @CurrentResourceManager -//
        /// <summary>
        /// Represents the currently active resource manager.
        /// </summary>
        public System.Resources.ResourceManager CurrentResourceManager
        {
            get
            {
                Nalarium.Globalization.ResourceAccessor.RegisterResourceManager(AssemblyName, BuiltInCultureArray);
                return Nalarium.Globalization.ResourceAccessor.LoadResourceManager(AssemblyName, DefaultResourceManager);
            }
        }
    }
}