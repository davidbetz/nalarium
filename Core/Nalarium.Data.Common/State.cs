#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2008-2013

#endregion

using System;
using Nalarium.Data.Cached;
//+

namespace Nalarium.Data.Common
{
    /// <summary>
    /// Provides quick access to US state text.
    /// </summary>
    public static class State
    {
        //- $Info -//

        //- @GetUSStateData -//
        /// <summary>
        /// Gets the state data.
        /// </summary>
        /// <returns>An Int32StringMap of state data.</returns>
        public static Int32StringMap GetUSStateData()
        {
            if (!CachedDataFactory.Exists(Info.Scope, Info.Numeric))
            {
                var map = new Int32StringMap();
                map.Add(1, Info.Alabama);
                map.Add(2, Info.Alaska);
                map.Add(3, Info.Arizona);
                map.Add(4, Info.Arkansas);
                map.Add(5, Info.California);
                map.Add(6, Info.Colorado);
                map.Add(7, Info.Connecticut);
                map.Add(8, Info.Delaware);
                map.Add(9, Info.Florida);
                map.Add(10, Info.Georgia);
                map.Add(11, Info.Hawaii);
                map.Add(12, Info.Idaho);
                map.Add(13, Info.Illinois);
                map.Add(14, Info.Indiana);
                map.Add(15, Info.Iowa);
                map.Add(16, Info.Kansas);
                map.Add(17, Info.Kentucky);
                map.Add(18, Info.Louisiana);
                map.Add(19, Info.Maine);
                map.Add(20, Info.Maryland);
                map.Add(21, Info.Massachusetts);
                map.Add(22, Info.Michigan);
                map.Add(23, Info.Minnesota);
                map.Add(24, Info.Mississippi);
                map.Add(25, Info.Missouri);
                map.Add(26, Info.Montana);
                map.Add(27, Info.Nebraska);
                map.Add(28, Info.Nevada);
                map.Add(29, Info.NewHampshire);
                map.Add(30, Info.NewJersey);
                map.Add(31, Info.NewMexico);
                map.Add(32, Info.NewYork);
                map.Add(33, Info.NorthCarolina);
                map.Add(34, Info.NorthDakota);
                map.Add(35, Info.Ohio);
                map.Add(36, Info.Oklahoma);
                map.Add(37, Info.Oregon);
                map.Add(38, Info.Pennsylvania);
                map.Add(39, Info.RhodeIsland);
                map.Add(40, Info.SouthCarolina);
                map.Add(41, Info.SouthDakota);
                map.Add(42, Info.Tennessee);
                map.Add(43, Info.Texas);
                map.Add(44, Info.Utah);
                map.Add(45, Info.Vermont);
                map.Add(46, Info.Virginia);
                map.Add(47, Info.Washington);
                map.Add(51, Info.WashingtonDC);
                map.Add(48, Info.WestVirginia);
                map.Add(49, Info.Wisconsin);
                map.Add(50, Info.Wyoming);
                //+
                CachedDataFactory.Register(Info.Scope, Info.Numeric, map);
            }
            //+
            return CachedDataFactory.Get<Int32StringMap>(Info.Scope, Info.Numeric);
        }

        //- @GetUSStateCodeData -//
        /// <summary>
        /// Gets the state code data.
        /// </summary>
        /// <returns>A map of state data.</returns>
        public static Map GetUSStateCodeData()
        {
            if (!CachedDataFactory.Exists(Info.Scope, Info.TwoCharacter))
            {
                var map = new Map();
                map.Add("AL", Info.Alabama);
                map.Add("AK", Info.Alaska);
                map.Add("AZ", Info.Arizona);
                map.Add("AR", Info.Arkansas);
                map.Add("CA", Info.California);
                map.Add("CO", Info.Colorado);
                map.Add("CT", Info.Connecticut);
                map.Add("DE", Info.Delaware);
                map.Add("FL", Info.Florida);
                map.Add("GA", Info.Georgia);
                map.Add("HI", Info.Hawaii);
                map.Add("ID", Info.Idaho);
                map.Add("IL", Info.Illinois);
                map.Add("IN", Info.Indiana);
                map.Add("IA", Info.Iowa);
                map.Add("KS", Info.Kansas);
                map.Add("KY", Info.Kentucky);
                map.Add("LA", Info.Louisiana);
                map.Add("ME", Info.Maine);
                map.Add("MD", Info.Maryland);
                map.Add("MA", Info.Massachusetts);
                map.Add("MI", Info.Michigan);
                map.Add("MN", Info.Minnesota);
                map.Add("MS", Info.Mississippi);
                map.Add("MO", Info.Missouri);
                map.Add("MT", Info.Montana);
                map.Add("NE", Info.Nebraska);
                map.Add("NV", Info.Nevada);
                map.Add("NH", Info.NewHampshire);
                map.Add("NJ", Info.NewJersey);
                map.Add("NM", Info.NewMexico);
                map.Add("NY", Info.NewYork);
                map.Add("NC", Info.NorthCarolina);
                map.Add("ND", Info.NorthDakota);
                map.Add("OH", Info.Ohio);
                map.Add("OK", Info.Oklahoma);
                map.Add("OR", Info.Oregon);
                map.Add("PA", Info.Pennsylvania);
                map.Add("RI", Info.RhodeIsland);
                map.Add("SC", Info.SouthCarolina);
                map.Add("SD", Info.SouthDakota);
                map.Add("TN", Info.Tennessee);
                map.Add("TX", Info.Texas);
                map.Add("UT", Info.Utah);
                map.Add("VT", Info.Vermont);
                map.Add("VA", Info.Virginia);
                map.Add("WA", Info.Washington);
                map.Add("DC", Info.WashingtonDC);
                map.Add("WV", Info.WestVirginia);
                map.Add("WI", Info.Wisconsin);
                map.Add("WY", Info.Wyoming);
                //+
                CachedDataFactory.Register(Info.Scope, Info.TwoCharacter, map);
            }
            //+
            return CachedDataFactory.Get<Map>(Info.Scope, Info.TwoCharacter);
        }

        #region Nested type: Info

        private static class Info
        {
            public const String Scope = "State";
            //+
            public const String Numeric = "Numeric";
            public const String TwoCharacter = "TwoCharacter";
            //+
            public const String Alabama = "Alabama";
            public const String Alaska = "Alaska";
            public const String Arizona = "Arizona";
            public const String Arkansas = "Arkansas";
            public const String California = "California";
            public const String Colorado = "Colorado";
            public const String Connecticut = "Connecticut";
            public const String Delaware = "Delaware";
            public const String Florida = "Florida";
            public const String Georgia = "Georgia";
            public const String Hawaii = "Hawaii";
            public const String Idaho = "Idaho";
            public const String Illinois = "Illinois";
            public const String Indiana = "Indiana";
            public const String Iowa = "Iowa";
            public const String Kansas = "Kansas";
            public const String Kentucky = "Kentucky";
            public const String Louisiana = "Louisiana";
            public const String Maine = "Maine";
            public const String Maryland = "Maryland";
            public const String Massachusetts = "Massachusetts";
            public const String Michigan = "Michigan";
            public const String Minnesota = "Minnesota";
            public const String Mississippi = "Mississippi";
            public const String Missouri = "Missouri";
            public const String Montana = "Montana";
            public const String Nebraska = "Nebraska";
            public const String Nevada = "Nevada";
            public const String NewHampshire = "New Hampshire";
            public const String NewJersey = "New Jersey";
            public const String NewMexico = "New Mexico";
            public const String NewYork = "New York";
            public const String NorthCarolina = "North Carolina";
            public const String NorthDakota = "North Dakota";
            public const String Ohio = "Ohio";
            public const String Oklahoma = "Oklahoma";
            public const String Oregon = "Oregon";
            public const String Pennsylvania = "Pennsylvania";
            public const String RhodeIsland = "Rhode Island";
            public const String SouthCarolina = "South Carolina";
            public const String SouthDakota = "South Dakota";
            public const String Tennessee = "Tennessee";
            public const String Texas = "Texas";
            public const String Utah = "Utah";
            public const String Vermont = "Vermont";
            public const String Virginia = "Virginia";
            public const String Washington = "Washington";
            public const String WashingtonDC = "Washington DC";
            public const String WestVirginia = "West Virginia";
            public const String Wisconsin = "Wisconsin";
            public const String Wyoming = "Wyoming";
        }

        #endregion
    }
}