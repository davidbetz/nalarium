#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2008-2013

#endregion

using System;
using System.Resources;
using Nalarium.Data.Cached;
using Nalarium.Data.Common.Properties;
using Nalarium.Globalization;
//+

namespace Nalarium.Data.Common
{
    /// <summary>
    /// Provides quick access to month and day text.
    /// </summary>
    public static class Date
    {
        //- $Info -//

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
        /// Gets the month data.
        /// </summary>
        /// <returns>An Int32StringMap of the month data.</returns>
        public static Int32StringMap GetMonthData()
        {
            if (!CachedDataFactory.Exists(Info.Scope, Culture.TwoCharacterCultureCode, Info.Month))
            {
                var map = new Int32StringMap();
                ResourceManager resourceManager = ResourceAccessor.LoadResourceManager(AssemblyInfo.AssemblyName, Resource.ResourceManager);
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
        /// Gets the day data.
        /// </summary>
        /// <returns>An Int32StringMap of the day data.</returns>
        public static Int32StringMap GetDayData()
        {
            if (!CachedDataFactory.Exists(Info.Scope, Culture.TwoCharacterCultureCode, Info.Day))
            {
                var map = new Int32StringMap();
                ResourceManager resourceManager = ResourceAccessor.LoadResourceManager(AssemblyInfo.AssemblyName, Resource.ResourceManager);
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
            public const String Scope = "Date";
            //+
            public const String Day = "Day";
            public const String Month = "Month";
            //+
            public const String January = "January";
            public const String February = "February";
            public const String March = "March";
            public const String April = "April";
            public const String May = "May";
            public const String June = "June";
            public const String July = "July";
            public const String August = "August";
            public const String September = "September";
            public const String October = "October";
            public const String November = "November";
            public const String December = "December";
            //+
            public const String Sunday = "Sunday";
            public const String Monday = "Monday";
            public const String Tuesday = "Tuesday";
            public const String Wednesday = "Wednesday";
            public const String Thursday = "Thursday";
            public const String Friday = "Friday";
            public const String Saturday = "Saturday";
        }

        #endregion
    }
}