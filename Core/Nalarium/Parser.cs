#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright � Jampad Technology, Inc. 2007-2010
#endregion
using System;
//+
namespace Nalarium
{
    /// <summary>
    /// Parses String, Int32, Double, and Boolean information from an object or string with overloads allowing for providing default if parsing fails.
    /// </summary>
    /// <example>
    /// Int32 int32 = Parser.ParseInt32("wrong", 15);
    /// 
    /// System.Console.WriteLine(Int32);
    /// 
    /// //+ Output: 15
    /// 
    /// //+
    /// //++ There is also a generic Parse methed for anyone who prefers that style.
    /// //+
    /// 
    /// </example>
    public static class Parser
    {
        private static Type _booleanType = typeof(Boolean);

        //+
        //- @Parse -//
        /// <summary>
        /// Parses the string as a generic type
        /// </summary>
        /// <typeparam name="T">Type of return data</typeparam>
        /// <param name="data"> data to parse</param>
        /// <returns>Parsed value</returns>
        public static T Parse<T>(String data)
        {
            return Parse<T>(data, default(T));
        }
        /// <summary>
        /// Parses the string as a generic type
        /// </summary>
        /// <typeparam name="T">Type of return data</typeparam>
        /// <param name="data"> data to parse</param>
        /// <param name="defaultValue">Parsed default value to return is null or empty</param>
        /// <returns>Parsed value</returns>
        public static T Parse<T>(String data, T defaultValue)
        {
            try
            {
                if (typeof(T) == _booleanType)
                {
                    switch (data)
                    {
                        case "1":
                        case "1.0":
                        case "yes":
                        case "true":
                        case "active":
                        case "on":
                            data = "true";
                            break;
                        default:
                            data = "false";
                            break;
                    }
                }
                return (T)Convert.ChangeType(data, typeof(T), System.Threading.Thread.CurrentThread.CurrentCulture);
            }
            catch
            {
                return defaultValue;
            }
        }

        //- @ParseString -//
        /// <summary>
        /// Parses the string.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>Parsed value.</returns>
        public static String ParseString(Object value)
        {
            if (value == null)
            {
                return String.Empty;
            }
            String valueString = value as String;
            if (valueString != null)
            {
                return valueString;
            }
            //+
            return value.ToString();
        }
        /// <summary>
        /// Parses the string or sets default.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <param name="defaultValue">Default value to return is null or empty</param>
        /// <returns>Parsed value or default.</returns>
        public static String ParseString(String value, String defaultValue)
        {
            if (String.IsNullOrEmpty(value))
            {
                return defaultValue;
            }
            //+
            return value;
        }
        /// <summary>
        /// Parses the string or, if the string is longer than the max, only returns the portion upto the max.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <param name="defaultValue">Default value to return is null or empty</param>
        /// <param name="max">The max length of the string.</param>
        /// <returns>Parsed value or default.</returns>
        public static String ParseMaxString(String value, String defaultValue, Int32 max)
        {
            if (String.IsNullOrEmpty(value))
            {
                value = defaultValue;
            }
            if (value.Length > max)
            {
                value = value.Substring(0, max);
            }
            //+
            return value;
        }

        //- @ParseByte -//
        /// <summary>
        /// Parses the Byte.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>Parsed value.</returns>
        public static Byte ParseByte(Object value)
        {
            if (value != null)
            {
                return ParseByte(value.ToString());
            }
            //+
            return 0;
        }
        /// <summary>
        /// Parses the Byte.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>Parsed value or 0.</returns>
        public static Byte ParseByte(String value)
        {
            return ParseByte(value, 0);
        }
        /// <summary>
        /// Parses the Byte or sets default.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <param name="defaultValue">Default value to return is value is invalid</param>
        /// <returns>Parsed value or default.</returns>
        public static Byte ParseByte(String value, Byte defaultValue)
        {
            Byte Byte;
            if (Byte.TryParse(value, out Byte))
            {
                return Byte;
            }
            else
            {
                return defaultValue;
            }
        }

        //- @ParseInt32 -//
        /// <summary>
        /// Parses the int32.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>Parsed value.</returns>
        public static Int32 ParseInt32(Object value)
        {
            if (value != null)
            {
                return ParseInt32(value.ToString());
            }
            //+
            return 0;
        }
        /// <summary>
        /// Parses the int32.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>Parsed value or 0.</returns>
        public static Int32 ParseInt32(String value)
        {
            return ParseInt32(value, 0);
        }
        /// <summary>
        /// Parses the int32 or sets default.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <param name="defaultValue">Default value to return is value is invalid</param>
        /// <returns>Parsed value or default.</returns>
        public static Int32 ParseInt32(String value, Int32 defaultValue)
        {
            Int32 int32;
            if (Int32.TryParse(value, out int32))
            {
                return int32;
            }
            else
            {
                return defaultValue;
            }
        }

        //- @ParseInt64 -//
        /// <summary>
        /// Parses the int64.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>Parsed value.</returns>
        public static Int64 ParseInt64(Object value)
        {
            if (value != null)
            {
                return ParseInt64(value.ToString());
            }
            //+
            return 0;
        }
        /// <summary>
        /// Parses the int64.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>Parsed value or 0.</returns>
        public static Int64 ParseInt64(String value)
        {
            return ParseInt64(value, 0);
        }
        /// <summary>
        /// Parses the int64 or sets default.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <param name="defaultValue">Default value to return is value is invalid</param>
        /// <returns>Parsed value or default.</returns>
        public static Int64 ParseInt64(String value, Int64 defaultValue)
        {
            Int64 int64;
            if (Int64.TryParse(value, out int64))
            {
                return int64;
            }
            else
            {
                return defaultValue;
            }
        }

        //- @ParseBoolean -//
        /// <summary>
        /// Parses the boolean.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>true if "yes" or 1 (or variant of 1 like "1" or 1.0); otherwise false</returns>
        public static Boolean ParseBoolean(Object value)
        {
            if (value != null)
            {
                return ParseBoolean(value.ToString());
            }
            return false;
        }
        /// <summary>
        /// Parses the boolean.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>true if 1; false is not 1</returns>
        public static Boolean ParseBoolean(Int32 value)
        {
            return value == 1;
        }
        /// <summary>
        /// Parses the boolean.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>true if "yes" or 1; otherwise false</returns>
        public static Boolean ParseBoolean(String value)
        {
            return ParseBoolean(value, false);
        }
        /// <summary>
        /// Parses the boolean or sets default.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <param name="defaultValue">Default value to return is value is invalid</param>
        /// <returns>true if "yes" or 1; otherwise the specified default</returns>
        public static Boolean ParseBoolean(String value, Boolean defaultValue)
        {
            Boolean boolean;
            if (Boolean.TryParse(value, out boolean))
            {
                return boolean;
            }
            else
            {
                if (value != null)
                {
                    if (value.ToLower(System.Globalization.CultureInfo.CurrentCulture) == "yes" || value == "1" || value == "1.0" || value == "on" || value == "active")
                    {
                        return true;
                    }
                }
                return defaultValue;
            }
        }

        //- @ParseDouble -//
        /// <summary>
        /// Parses the double.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>Parsed value or 0.0.</returns>
        public static Double ParseDouble(Object value)
        {
            if (value != null)
            {
                return ParseDouble(value.ToString());
            }
            return 0.0;
        }
        /// <summary>
        /// Parses the double.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>Parsed value or 0.0.</returns>
        public static Double ParseDouble(String value)
        {
            return ParseDouble(value, 0.0);
        }
        /// <summary>
        /// Parses the double or sets default.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <param name="defaultValue">Default value to return is value is invalid</param>
        /// <returns>Parsed value or default.</returns>
        public static Double ParseDouble(String value, Double defaultValue)
        {
            Double Double;
            if (Double.TryParse(value, out Double))
            {
                return Double;
            }
            else
            {
                return defaultValue;
            }
        }

        //- @ParseDateTime -//
        /// <summary>
        /// Parses the date time.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>Parsed value or DateTime.MinValue.</returns>
        public static DateTime ParseDateTime(Object value)
        {
            if (value != null)
            {
                return ParseDateTime(value.ToString());
            }
            return DateTime.MinValue;
        }
        /// <summary>
        /// Parses the date time.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>Parsed value or DateTime.MinValue.</returns>
        public static DateTime ParseDateTime(String value)
        {
            return ParseDateTime(value, DateTime.MinValue);
        }
        /// <summary>
        /// Parses the date time or sets default.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <param name="defaultValue">Default value to return is value is invalid</param>
        /// <returns>Parsed value or default.</returns>
        /// <returns></returns>
        public static DateTime ParseDateTime(String value, DateTime defaultValue)
        {
            DateTime DateTime;
            if (DateTime.TryParse(value, out DateTime))
            {
                return DateTime;
            }
            else
            {
                return defaultValue;
            }
        }

        //- @ParseUInt16 -//
        /// <summary>
        /// Parses the UInt16.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>Parsed value.</returns>
        public static UInt16 ParseUInt16(Object value)
        {
            if (value != null)
            {
                return ParseUInt16(value.ToString());
            }
            //+
            return 0;
        }
        /// <summary>
        /// Parses the UInt16.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>Parsed value or 0.</returns>
        public static UInt16 ParseUInt16(String value)
        {
            return ParseUInt16(value, 0);
        }
        /// <summary>
        /// Parses the UInt16 or sets default.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <param name="defaultValue">Default value to return is value is invalid</param>
        /// <returns>Parsed value or default.</returns>
        public static UInt16 ParseUInt16(String value, UInt16 defaultValue)
        {
            UInt16 UInt16;
            if (UInt16.TryParse(value, out UInt16))
            {
                return UInt16;
            }
            else
            {
                return defaultValue;
            }
        }

        //- @ParseUInt32 -//
        /// <summary>
        /// Parses the UInt32.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>Parsed value.</returns>
        public static UInt32 ParseUInt32(Object value)
        {
            if (value != null)
            {
                return ParseUInt32(value.ToString());
            }
            //+
            return 0;
        }
        /// <summary>
        /// Parses the UInt32.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>Parsed value or 0.</returns>
        public static UInt32 ParseUInt32(String value)
        {
            return ParseUInt32(value, 0);
        }
        /// <summary>
        /// Parses the UInt32 or sets default.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <param name="defaultValue">Default value to return is value is invalid</param>
        /// <returns>Parsed value or default.</returns>
        public static UInt32 ParseUInt32(String value, UInt32 defaultValue)
        {
            UInt32 UInt32;
            if (UInt32.TryParse(value, out UInt32))
            {
                return UInt32;
            }
            else
            {
                return defaultValue;
            }
        }

        //- @ParseUInt64 -//
        /// <summary>
        /// Parses the UInt64.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>Parsed value.</returns>
        public static UInt64 ParseUInt64(Object value)
        {
            if (value != null)
            {
                return ParseUInt64(value.ToString());
            }
            //+
            return 0;
        }
        /// <summary>
        /// Parses the UInt64.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>Parsed value or 0.</returns>
        public static UInt64 ParseUInt64(String value)
        {
            return ParseUInt64(value, 0);
        }
        /// <summary>
        /// Parses the UInt64 or sets default.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <param name="defaultValue">Default value to return is value is invalid</param>
        /// <returns>Parsed value or default.</returns>
        public static UInt64 ParseUInt64(String value, UInt64 defaultValue)
        {
            UInt64 UInt64;
            if (UInt64.TryParse(value, out UInt64))
            {
                return UInt64;
            }
            else
            {
                return defaultValue;
            }
        }
    }
}