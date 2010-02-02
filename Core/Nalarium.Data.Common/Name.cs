#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
using System.Resources;
//+
using Nalarium.Data.Cached;
using Nalarium.Globalization;
using Nalarium.Configuration;
//+
namespace Nalarium.Data.Common
{
    /// <summary>
    /// Provides quick access to name metadata (i.e. Mr, Mrs, Jr, Sr).
    /// </summary>
    public static class Name
    {
        //- $Info -//
        private static class Info
        {
            public const String Scope = "Name";
            //+
            public const String Prefix = "Prefix";
            public const String Suffix = "Suffix";
            //+
            public const String Mr = "Mr";
            public const String Ms = "Ms";
            public const String Mrs = "Mrs";
            public const String Dr = "Dr";
            //+
            public const String Jr = "Jr";
            public const String Sr = "Sr";
            public const String I = "I";
            public const String II = "II";
            public const String III = "III";
        }

        //+
        //- @Ctor -//
        static Name()
        {
            ResourceAccessor.RegisterResourceManager(AssemblyInfo.AssemblyName, Common.Info.ResourcePattern, new String[] { "en" });
        }

        //- @GetPrefixData -//
        /// <summary>
        /// Gets the name prefix data.
        /// </summary>
        /// <returns>An Int32StringMap of name prefix data.</returns>
        public static Int32StringMap GetPrefixData()
        {
            if (!CachedDataFactory.Exists(Info.Scope, Culture.TwoCharacterCultureCode, Info.Prefix))
            {
                Int32StringMap map = new Int32StringMap();
                ResourceManager resourceManager = ResourceAccessor.LoadResourceManager(AssemblyInfo.AssemblyName, Resource.ResourceManager);
                map.Add(1, resourceManager.GetString(Info.Prefix + "_" + Info.Mr));
                map.Add(2, resourceManager.GetString(Info.Prefix + "_" + Info.Ms));
                map.Add(3, resourceManager.GetString(Info.Prefix + "_" + Info.Mrs));
                map.Add(4, resourceManager.GetString(Info.Prefix + "_" + Info.Dr));
                //+
                CachedDataFactory.Register<Int32StringMap>(Info.Scope, Culture.TwoCharacterCultureCode, Info.Prefix, map);
            }
            //+
            return CachedDataFactory.Get<Int32StringMap>(Info.Scope, Culture.TwoCharacterCultureCode, Info.Prefix);
        }

        //- @GetSuffixData -//
        /// <summary>
        /// Gets the name suffix data.
        /// </summary>
        /// <returns>An Int32StringMap of name suffix data.</returns>
        public static Int32StringMap GetSuffixData()
        {
            if (!CachedDataFactory.Exists(Info.Scope, Culture.TwoCharacterCultureCode, Info.Suffix))
            {
                Int32StringMap map = new Int32StringMap();
                ResourceManager resourceManager = ResourceAccessor.LoadResourceManager(AssemblyInfo.AssemblyName, Resource.ResourceManager);
                map.Add(1, resourceManager.GetString(Info.Suffix + "_" + Info.Jr));
                map.Add(2, resourceManager.GetString(Info.Suffix + "_" + Info.Sr));
                map.Add(3, resourceManager.GetString(Info.Suffix + "_" + Info.I));
                map.Add(4, resourceManager.GetString(Info.Suffix + "_" + Info.II));
                map.Add(5, resourceManager.GetString(Info.Suffix + "_" + Info.III));
                //+
                CachedDataFactory.Register<Int32StringMap>(Info.Scope, Culture.TwoCharacterCultureCode, Info.Suffix, map);
            }
            //+
            return CachedDataFactory.Get<Int32StringMap>(Info.Scope, Culture.TwoCharacterCultureCode, Info.Suffix);
        }
    }
}