using Nalarium.Data.Cached;
using Nalarium.Globalization;
using Nalarium.Properties;

namespace Nalarium.Data.Common
{
    /// <summary>
    ///     Provides quick access to month and day text.
    /// </summary>
    public static class Date
    {
        //+
        //- @Ctor -//
        static Date()
        {
            ResourceAccessor.RegisterResourceManager(AssemblyInfo.AssemblyName, new[]
            {
                "en"
            });
        }

        //+
        //- @GetMonthData -//
        /// <summary>
        ///     Gets the month data.
        /// </summary>
        /// <returns>An Int32StringMap of the month data.</returns>
        public static Int32StringMap GetMonthData()
        {
            if (!CachedDataFactory.Exists(Info.Scope, Culture.TwoCharacterCultureCode, Info.Month))
            {
                var map = new Int32StringMap();
                var resourceManager = ResourceAccessor.LoadResourceManager(AssemblyInfo.AssemblyName, Resource.ResourceManager);
                map.Add(1, resourceManager.GetString(Info.Month + "_" + Info.January));
                map.Add(2, resourceManager.GetString(Info.Month + "_" + Info.February));
                map.Add(3, resourceManager.GetString(Info.Month + "_" + Info.March));
                map.Add(4, resourceManager.GetString(Info.Month + "_" + Info.April));
                map.Add(5, resourceManager.GetString(Info.Month + "_" + Info.May));
                map.Add(6, resourceManager.GetString(Info.Month + "_" + Info.June));
                map.Add(7, resourceManager.GetString(Info.Month + "_" + Info.July));
                map.Add(8, resourceManager.GetString(Info.Month + "_" + Info.August));
                map.Add(9, resourceManager.GetString(Info.Month + "_" + Info.September));
                map.Add(10, resourceManager.GetString(Info.Month + "_" + Info.October));
                map.Add(11, resourceManager.GetString(Info.Month + "_" + Info.November));
                map.Add(12, resourceManager.GetString(Info.Month + "_" + Info.December));
                //+
                CachedDataFactory.Register(Info.Scope, Culture.TwoCharacterCultureCode, Info.Month, map);
            }
            //+
            return CachedDataFactory.Get<Int32StringMap>(Info.Scope, Culture.TwoCharacterCultureCode, Info.Month);
        }

        //- @GetDayData -//
        /// <summary>
        ///     Gets the day data.
        /// </summary>
        /// <returns>An Int32StringMap of the day data.</returns>
        public static Int32StringMap GetDayData()
        {
            if (!CachedDataFactory.Exists(Info.Scope, Culture.TwoCharacterCultureCode, Info.Day))
            {
                var map = new Int32StringMap();
                var resourceManager = ResourceAccessor.LoadResourceManager(AssemblyInfo.AssemblyName, Resource.ResourceManager);
                map.Add(1, resourceManager.GetString(Info.Day + "_" + Info.Sunday));
                map.Add(2, resourceManager.GetString(Info.Day + "_" + Info.Monday));
                map.Add(3, resourceManager.GetString(Info.Day + "_" + Info.Tuesday));
                map.Add(4, resourceManager.GetString(Info.Day + "_" + Info.Wednesday));
                map.Add(5, resourceManager.GetString(Info.Day + "_" + Info.Thursday));
                map.Add(6, resourceManager.GetString(Info.Day + "_" + Info.Friday));
                map.Add(7, resourceManager.GetString(Info.Day + "_" + Info.Saturday));
                //+
                CachedDataFactory.Register(Info.Scope, Culture.TwoCharacterCultureCode, Info.Day, map);
            }
            //+
            return CachedDataFactory.Get<Int32StringMap>(Info.Scope + "::" + Culture.TwoCharacterCultureCode, Info.Day);
        }

        #region Nested type: Info

        private static class Info
        {
            public const string Scope = "Date";
            //+
            public const string Day = "Day";
            public const string Month = "Month";
            //+
            public const string January = "January";
            public const string February = "February";
            public const string March = "March";
            public const string April = "April";
            public const string May = "May";
            public const string June = "June";
            public const string July = "July";
            public const string August = "August";
            public const string September = "September";
            public const string October = "October";
            public const string November = "November";
            public const string December = "December";
            //+
            public const string Sunday = "Sunday";
            public const string Monday = "Monday";
            public const string Tuesday = "Tuesday";
            public const string Wednesday = "Wednesday";
            public const string Thursday = "Thursday";
            public const string Friday = "Friday";
            public const string Saturday = "Saturday";
        }

        #endregion
    }
}