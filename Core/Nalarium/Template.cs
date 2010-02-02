#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
using System.Text;
//++
//
// See Map.cs for usage
//
//++
namespace Nalarium
{
    /// <summary>
    /// Creates a pattern which allows interpolation with map data to create mass output.
    /// </summary>
    public class Template
    {
        //- @Common -//
        /// <summary>
        /// Contains common templates for quick access
        /// </summary>
        public class Common
        {
            public const String Link = @"<a href=""{Link}"">{Text}</a>";
            public const String Image = @"<img src=""{Source}"" alt=""{Text}"" />";

            //- #Ctor -//
            protected Common() { }
        }

        //- @Value -//
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public StringBuilder Value { get; set; }

        //+
        //- @Ctor -//
        /// <summary>
        /// Initializes a new instance of the <see cref="Template"/> class.
        /// </summary>
        public Template()
            : this(String.Empty)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Template"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Template(String value)
        {
            this.Value = new StringBuilder(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Template"/> class.
        /// </summary>
        public static Template Create()
        {
            return new Template();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Template"/> class.
        /// </summary>
        /// <param name="value">Template text.</param>
        public static Template Create(String value)
        {
            return new Template(value);
        }

        //+
        //- @AppendText -//
        /// <summary>
        /// Appends the text.
        /// </summary>
        /// <param name="value">Template text.</param>
        public void AppendText(String text)
        {
            this.Value.Append(text);
        }

        //- @Interpolate -//
        /// <summary>
        /// Interpolates the specified pair array.
        /// </summary>
        /// <param name="templateValue">Template text.</param>
        /// <param name="map">The map.</param>
        /// <returns>Templated result string.</returns>
        public static String Interpolate(String templateValue, Map map)
        {
            if (map == null)
            {
                return String.Empty;
            }
            if (String.IsNullOrEmpty(templateValue))
            {
                return String.Empty;
            }
            //+
            return Template.Create(templateValue).Interpolate(map);
        }
        /// <summary>
        /// Interpolates the specified pair array.
        /// </summary>
        /// <param name="templateValue">Template text.</param>
        /// <param name="mapEntryArray">A pair (i.e. "a=b") parameter array.</param>
        /// <returns>Templated result string.</returns>
        public static String Interpolate(String templateValue, params MapEntry[] parameterArray)
        {
            if (parameterArray == null)
            {
                return String.Empty;
            }
            if (String.IsNullOrEmpty(templateValue))
            {
                return String.Empty;
            }
            //+
            return Template.Create(templateValue).Interpolate(new Map(parameterArray));
        }
        /// <summary>
        /// Interpolates the specified map entry array.
        /// </summary>
        /// <param name="mapEntryArray">A MapEntry parameter array.</param>
        /// <returns>Templated result string.</returns>
        public String Interpolate(params MapEntry[] parameterArray)
        {
            if (parameterArray == null)
            {
                return String.Empty;
            }
            //+
            return Interpolate(new Map(parameterArray));
        }
        /// <summary>
        /// Interpolates the specified map.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <returns>Templated result string.</returns>
        public String Interpolate(Map map)
        {
            String result = this.Value.ToString();
            foreach (String name in map.GetKeyList())
            {
                result = result.Replace("{" + name + "}", map[name]);
            }
            return result;
        }
        /// <summary>
        /// Interpolates the specified pair array.
        /// </summary>
        /// <param name="pairArray">The pair array.</param>
        /// <returns>Templated result string.</returns>
        public String Interpolate(String[] pairArray)
        {
            if (pairArray == null)
            {
                return String.Empty;
            }
            String result = Value.ToString();
            foreach (String mapping in pairArray)
            {
                String name = String.Empty;
                String value = String.Empty;
                String[] parts = mapping.Split('=');
                if (parts.Length == 2)
                {
                    name = parts[0];
                    value = parts[1];
                }
                else if (parts.Length == 1)
                {
                    name = parts[0];
                    value = parts[0];
                }
                //+
                if (!String.IsNullOrEmpty(name))
                {
                    if (!String.IsNullOrEmpty(value))
                    {
                        value = value.Trim();
                        result = result.Replace("{" + name + "}", value);
                    }
                }
            }
            //+
            return result;
        }
    }
}