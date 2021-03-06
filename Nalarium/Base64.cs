#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System;
using System.Text;

namespace Nalarium
{
    public static class Base64
    {
        public static string To(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
        }

        public static string From(string base64Text)
        {
            if (string.IsNullOrEmpty(base64Text))
            {
                return string.Empty;
            }
            try
            {
                return Encoding.UTF8.GetString(Convert.FromBase64String(base64Text));
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string Merge(params string[] parameterArray)
        {
            return To(String.Join(String.Empty, parameterArray));
        }

        public static string Merge(char separator, params string[] parameterArray)
        {
            if (Collection.IsNullOrEmpty(parameterArray))
            {
                return string.Empty;
            }
            return To(String.Join(separator.ToString(), parameterArray));
        }
    }
}