using Nalarium.Data.Cached;
using Nalarium.Globalization;
using Nalarium.Properties;

namespace Nalarium.Data.Common
{
    /// <summary>
    ///     Provides quick access to name metadata (i.e. Mr, Mrs, Jr, Sr).
    /// </summary>
    public static class Name
    {
        //- $Info -//

        //+
        //- @Ctor -//
        static Name()
        {
            ResourceAccessor.RegisterResourceManager(AssemblyInfo.AssemblyName, Common.Info.ResourcePattern, new[]
            {
                "en"
            });
        }

        //- @GetPrefixData -//
        /// <summary>
        ///     Gets the name prefix data.
        /// </summary>
        /// <returns>An Int32StringMap of name prefix data.</returns>
        public static Int32StringMap GetPrefixData()
        {
            if (!CachedDataFactory.Exists(Info.Scope, Culture.TwoCharacterCultureCode, Info.Prefix))
            {
                var map = new Int32StringMap();
                var resourceManager = ResourceAccessor.LoadResourceManager(AssemblyInfo.AssemblyName, Resource.ResourceManager);
                map.Add(1, resourceManager.GetString(Info.Prefix + "_" + Info.Mr));
                map.Add(2, resourceManager.GetString(Info.Prefix + "_" + Info.Ms));
                map.Add(3, resourceManager.GetString(Info.Prefix + "_" + Info.Mrs));
                map.Add(4, resourceManager.GetString(Info.Prefix + "_" + Info.Dr));
                //+
                CachedDataFactory.Register(Info.Scope, Culture.TwoCharacterCultureCode, Info.Prefix, map);
            }
            //+
            return CachedDataFactory.Get<Int32StringMap>(Info.Scope, Culture.TwoCharacterCultureCode, Info.Prefix);
        }

        //- @GetSuffixData -//
        /// <summary>
        ///     Gets the name suffix data.
        /// </summary>
        /// <returns>An Int32StringMap of name suffix data.</returns>
        public static Int32StringMap GetSuffixData()
        {
            if (!CachedDataFactory.Exists(Info.Scope, Culture.TwoCharacterCultureCode, Info.Suffix))
            {
                var map = new Int32StringMap();
                var resourceManager = ResourceAccessor.LoadResourceManager(AssemblyInfo.AssemblyName, Resource.ResourceManager);
                map.Add(1, resourceManager.GetString(Info.Suffix + "_" + Info.Jr));
                map.Add(2, resourceManager.GetString(Info.Suffix + "_" + Info.Sr));
                map.Add(3, resourceManager.GetString(Info.Suffix + "_" + Info.I));
                map.Add(4, resourceManager.GetString(Info.Suffix + "_" + Info.II));
                map.Add(5, resourceManager.GetString(Info.Suffix + "_" + Info.III));
                //+
                CachedDataFactory.Register(Info.Scope, Culture.TwoCharacterCultureCode, Info.Suffix, map);
            }
            //+
            return CachedDataFactory.Get<Int32StringMap>(Info.Scope, Culture.TwoCharacterCultureCode, Info.Suffix);
        }

        #region Nested type: Info

        private static class Info
        {
            public const string Scope = "Name";
            //+
            public const string Prefix = "Prefix";
            public const string Suffix = "Suffix";
            //+
            public const string Mr = "Mr";
            public const string Ms = "Ms";
            public const string Mrs = "Mrs";
            public const string Dr = "Dr";
            //+
            public const string Jr = "Jr";
            public const string Sr = "Sr";
            public const string I = "I";
            public const string II = "II";
            public const string III = "III";
        }

        #endregion
    }
}