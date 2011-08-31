#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010

#endregion

using System;

namespace Nalarium.Activation
{
    public class PropertyData<T> : PropertyDataBase
    {
        protected Type _type;

        //- @Value -//
        /// <summary>
        /// Property value.
        /// </summary>
        public T Value { get; set; }

        //+
        //- @Type -//
        /// <summary>
        /// Property type.
        /// </summary>
        public override Type Type
        {
            get
            {
                if (_type == null)
                {
                    _type = typeof(T);
                }
                //+
                return _type;
            }

            set
            {
                if (_type != null)
                {
                    throw new InvalidOperationException("Type is already set.");
                }
                //+
                _type = value;
            }
        }
    }

    public class PropertyData : PropertyData<Object>
    {
    }
}