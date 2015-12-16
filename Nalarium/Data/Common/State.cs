#region Copyright

//+ Copyright © David Betz 2008-2013

#endregion

using Nalarium.Data.Cached;

//+

namespace Nalarium.Data.Common
{
    /// <summary>
    ///     Provides quick access to US state text.
    /// </summary>
    public static class State
    {
        //- $Info -//

        //- @GetUSStateData -//
        /// <summary>
        ///     Gets the state data.
        /// </summary>
        /// <returns>An Int32StringMap of state data.</returns>
        public static Int32StringMap GetUsStateData()
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
        ///     Gets the state code data.
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
            public const string Scope = "State";
            //+
            public const string Numeric = "Numeric";
            public const string TwoCharacter = "TwoCharacter";
            //+
            public const string Alabama = "Alabama";
            public const string Alaska = "Alaska";
            public const string Arizona = "Arizona";
            public const string Arkansas = "Arkansas";
            public const string California = "California";
            public const string Colorado = "Colorado";
            public const string Connecticut = "Connecticut";
            public const string Delaware = "Delaware";
            public const string Florida = "Florida";
            public const string Georgia = "Georgia";
            public const string Hawaii = "Hawaii";
            public const string Idaho = "Idaho";
            public const string Illinois = "Illinois";
            public const string Indiana = "Indiana";
            public const string Iowa = "Iowa";
            public const string Kansas = "Kansas";
            public const string Kentucky = "Kentucky";
            public const string Louisiana = "Louisiana";
            public const string Maine = "Maine";
            public const string Maryland = "Maryland";
            public const string Massachusetts = "Massachusetts";
            public const string Michigan = "Michigan";
            public const string Minnesota = "Minnesota";
            public const string Mississippi = "Mississippi";
            public const string Missouri = "Missouri";
            public const string Montana = "Montana";
            public const string Nebraska = "Nebraska";
            public const string Nevada = "Nevada";
            public const string NewHampshire = "New Hampshire";
            public const string NewJersey = "New Jersey";
            public const string NewMexico = "New Mexico";
            public const string NewYork = "New York";
            public const string NorthCarolina = "North Carolina";
            public const string NorthDakota = "North Dakota";
            public const string Ohio = "Ohio";
            public const string Oklahoma = "Oklahoma";
            public const string Oregon = "Oregon";
            public const string Pennsylvania = "Pennsylvania";
            public const string RhodeIsland = "Rhode Island";
            public const string SouthCarolina = "South Carolina";
            public const string SouthDakota = "South Dakota";
            public const string Tennessee = "Tennessee";
            public const string Texas = "Texas";
            public const string Utah = "Utah";
            public const string Vermont = "Vermont";
            public const string Virginia = "Virginia";
            public const string Washington = "Washington";
            public const string WashingtonDC = "Washington DC";
            public const string WestVirginia = "West Virginia";
            public const string Wisconsin = "Wisconsin";
            public const string Wyoming = "Wyoming";
        }

        #endregion
    }
}