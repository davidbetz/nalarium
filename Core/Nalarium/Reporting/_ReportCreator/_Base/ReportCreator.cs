#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
using System.Text;
//+
namespace Nalarium.Reporting
{
    public abstract class ReportCreator : Factory
    {
        private System.Collections.Generic.List<Object> _list;
        
        //- @Result -//
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        public StringBuilder Result { get; set; }

        //- @Formatter -//
        /// <summary>
        /// Gets or sets the formatter.
        /// </summary>
        /// <value>The formatter.</value>
        public Formatter Formatter { get; set; }

        //- @IsException -//
        /// <summary>
        /// States whether the report creator is for exception reporting.
        /// </summary>
        /// <value>True if is exception, false if user defined.</value>
        public virtual Boolean IsException { get { return false; } }

        //- @Data -//
        /// <summary>
        /// Gets or sets the data list .
        /// </summary>
        /// <value>The data list.</value>
        public System.Collections.Generic.List<Object> Data
        {
            get
            {
                if (_list == null)
                {
                    _list = new System.Collections.Generic.List<Object>();
                }
                //+
                return _list;
            }
        }

        //+
        //- @Clear -//
        /// <summary>
        /// Clears the data list
        /// </summary>
        public void Clear()
        {
            this._list = new System.Collections.Generic.List<Object>();
        }

        //- @AddMap -//
        /// <summary>
        /// Adds the specified map to the data list
        /// </summary>
        /// <param name="map">The map to add.</param>
        public void AddMap(Object data)
        {
            this.Data.Add(data);
        }

        //- @InsertMap -//
        /// <summary>
        /// Inserts a map at a particular location.
        /// </summary>
        /// <param name="map">The map to insert into the data list.</param>
        /// <param name="index">The index at which to insert the map.</param>
        public void InsertMap(Map map, Int32 index)
        {
            this.Data.Insert(index, map);
        }

        //- @Create -//
        /// <summary>
        /// Generates the report.
        /// </summary>
        /// <returns></returns>
        public String Create()
        {
            return Create(this.Data);
        }
        /// <summary>
        /// Generates a report.
        /// </summary>
        /// <param name="list">The data list on which to base the report creation.</param>
        /// <returns></returns>
        public String Create(System.Collections.Generic.List<Object> list)
        {
            this.Result = new StringBuilder();
            //+
            if (list.Count > 0)
            {
                CreateHeader();
                foreach (Object data in list)
                {
                    CreateCore(data);
                }
                CreateFooter();
                //+
                return this.Result.ToString();
            }
            //+
            return String.Empty;
        }
        /// <summary>
        /// Generates the report.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <returns></returns>
        public String Create(Object data)
        {
            this.Result = new StringBuilder();
            //+
            return CreateCore(data);
        }
        
        //- #CreateCore -//
        /// <summary>
        /// Generates the report.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <returns></returns>
        protected abstract String CreateCore(Object content);

        //- #CreateHeader -//
        /// <summary>
        /// Creates the header.
        /// </summary>
        protected virtual void CreateHeader() { }

        //- #CreateHeader -//
        /// <summary>
        /// Creates the footer.
        /// </summary>
        protected virtual void CreateFooter() { }

        //- #Write -//
        /// <summary>
        /// Writes the specified text.
        /// </summary>
        /// <param name="formatterType">Type of the formatter.</param>
        protected void Write(FormatterType formatterType)
        {
            this.Write(String.Empty, formatterType);
        }
        /// <summary>
        /// Writes the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="formatterType">Type of the formatter.</param>
        protected void Write(String text, FormatterType formatterType)
        {
            this.Result.Append(this.Formatter.Format(text, formatterType));
        }
        /// <summary>
        /// Writes the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="formatterType">Type of the formatter.</param>
        /// <param name="styles">The styles.</param>
        protected void Write(String text, FormatterType formatterType, StyleTypes styles)
        {
            this.Result.Append(this.Formatter.Format(text, formatterType, styles));
        }

        //- @IsValid -//
        /// <summary>
        /// Determines whether the specified parameter array is valid.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameterArray">The parameter array.</param>
        /// <param name="arg1">The arg1.</param>
        /// <returns>
        /// 	<c>true</c> if the specified parameter array is valid; otherwise, <c>false</c>.
        /// </returns>
        protected Boolean IsValid<T>(Object[] parameterArray, out T arg1) where T : class
        {
            if (!Collection.IsNullOrTooSmall<Object>(parameterArray, 1))
            {
                arg1 = parameterArray[0] as T;
                if (arg1 != null)
                {
                    return true;
                }
            }
            //+
            arg1 = null;
            return false;
        }
        /// <summary>
        /// Determines whether the specified parameter array is valid.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <param name="parameterArray">The parameter array.</param>
        /// <param name="arg1">The arg1.</param>
        /// <param name="arg2">The arg2.</param>
        /// <returns>
        /// 	<c>true</c> if the specified parameter array is valid; otherwise, <c>false</c>.
        /// </returns>
        protected Boolean IsValid<T1, T2>(Object[] parameterArray, out T1 arg1, out T2 arg2)
            where T1 : class
            where T2 : class
        {
            if (!Collection.IsNullOrTooSmall<Object>(parameterArray, 2))
            {
                arg1 = parameterArray[0] as T1;
                arg2 = parameterArray[1] as T2;
                if (arg1 != null && arg2 != null)
                {
                    return true;
                }
            }
            //+
            arg1 = null;
            arg2 = null;
            return false;
        }
    }
}