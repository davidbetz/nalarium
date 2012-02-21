using System;
using System.Diagnostics;

namespace Nalarium
{
    [DebuggerDisplay("{Scope}, {Name}")]
    public class Value
    {
        #region Modifiers enum

        [Flags]
        public enum Modifiers
        {
            None = 0x00,
            Normal = 0x01,
            IsDefault = 0x02,
            RetainRawValue = 0x04
        }

        #endregion

        private String _fullName;
        private Boolean _hasChanged;
        private Modifiers _modifier = Modifiers.Normal;

        private Object _nonBasicValue;
        private String _value;
        private Boolean _valueBoolean;
        private Byte _valueByte;
        private DateTime _valueDateTime;
        private Double _valueDouble;
        private Int32 _valueInt32;
        private Int64 _valueInt64;

        private Value()
        {
        }

        public Boolean IsBasicType { get; set; }

        public String Scope
        {
            get
            {
                if (!IsScoped)
                {
                    return _fullName;
                }
                return _fullName.Split(':')[0];
            }
        }

        public String Name
        {
            get
            {
                if (!IsScoped)
                {
                    return _fullName;
                }
                return _fullName.Split(':')[1];
            }
        }

        public Boolean IsScoped
        {
            get
            {
                return _fullName.Contains(":");
            }
        }

        public static Value Blank
        {
            get
            {
                Value v = Create(String.Empty);
                v._modifier = Modifiers.IsDefault;
                //+
                return v;
            }
        }

        public String AsString
        {
            get
            {
                if ((_modifier & Modifiers.IsDefault) == Modifiers.IsDefault)
                {
                    return String.Empty;
                }
                else if (!IsBasicType)
                {
                    return Parser.ParseString(_nonBasicValue);
                }
                //+
                return _value;
            }
            set
            {
                _value = value;
                _hasChanged = true;
                _modifier = Modifiers.Normal;
            }
        }

        public Int32 AsInt32
        {
            get
            {
                if ((_modifier & Modifiers.IsDefault) == Modifiers.IsDefault)
                {
                    return 0;
                }
                else if (!IsBasicType)
                {
                    return Parser.ParseInt32(_nonBasicValue);
                }
                //+
                if (_hasChanged)
                {
                    _valueInt32 = Parser.ParseInt32(_value);
                    _hasChanged = false;
                }
                //+
                return _valueInt32;
            }
            set
            {
                _value = value.ToString();
                _hasChanged = true;
                _modifier = Modifiers.Normal;
            }
        }

        public Int64 AsInt64
        {
            get
            {
                if ((_modifier & Modifiers.IsDefault) == Modifiers.IsDefault)
                {
                    return 0;
                }
                else if (!IsBasicType)
                {
                    return Parser.ParseInt64(_nonBasicValue);
                }
                //+
                if (_hasChanged)
                {
                    _valueInt64 = Parser.ParseInt64(_value);
                    _hasChanged = false;
                }
                //+
                return _valueInt64;
            }
            set
            {
                _value = value.ToString();
                _hasChanged = true;
                _modifier = Modifiers.Normal;
            }
        }

        public Byte AsByte
        {
            get
            {
                if ((_modifier & Modifiers.IsDefault) == Modifiers.IsDefault)
                {
                    return 0;
                }
                else if (!IsBasicType)
                {
                    return Parser.ParseByte(_nonBasicValue);
                }
                //+
                if (_hasChanged)
                {
                    _valueByte = Parser.ParseByte(_value);
                    _hasChanged = false;
                }
                //+
                return _valueByte;
            }
            set
            {
                _value = value.ToString();
                _hasChanged = true;
                _modifier = Modifiers.Normal;
            }
        }

        public Boolean AsBoolean
        {
            get
            {
                if ((_modifier & Modifiers.IsDefault) == Modifiers.IsDefault)
                {
                    return false;
                }
                else if (!IsBasicType)
                {
                    return Parser.ParseBoolean(_nonBasicValue);
                }
                //+
                if (_hasChanged)
                {
                    _valueBoolean = Parser.ParseBoolean(_value);
                    _hasChanged = false;
                }
                //+
                return _valueBoolean;
            }
            set
            {
                _value = value.ToString();
                _hasChanged = true;
                _modifier = Modifiers.Normal;
            }
        }

        public Double AsDouble
        {
            get
            {
                if ((_modifier & Modifiers.IsDefault) == Modifiers.IsDefault)
                {
                    return 0;
                }
                else if (!IsBasicType)
                {
                    return Parser.ParseDouble(_nonBasicValue);
                }
                //+
                if (_hasChanged)
                {
                    _valueDouble = Parser.ParseDouble(_value);
                    _hasChanged = false;
                }
                //+
                return _valueDouble;
            }
            set
            {
                _value = value.ToString();
                _hasChanged = true;
                _modifier = Modifiers.Normal;
            }
        }

        public DateTime AsDateTime
        {
            get
            {
                if ((_modifier & Modifiers.IsDefault) == Modifiers.IsDefault)
                {
                    return default(DateTime);
                }
                else if (!IsBasicType)
                {
                    return Parser.ParseDateTime(_nonBasicValue);
                }
                //+
                if (_hasChanged)
                {
                    _valueDateTime = Parser.ParseDateTime(_value);
                    _hasChanged = false;
                }
                //+
                return _valueDateTime;
            }
            set
            {
                _value = value.ToString();
                _hasChanged = true;
                _modifier = Modifiers.Normal;
            }
        }

        public Object AsObject
        {
            get
            {
                if ((_modifier & Modifiers.IsDefault) == Modifiers.IsDefault)
                {
                    return null;
                }
                else if (!IsBasicType)
                {
                    return _nonBasicValue;
                }
                //+
                return _value;
            }
            set
            {
                if ((_modifier & Modifiers.RetainRawValue) == Modifiers.RetainRawValue)
                {
                    _nonBasicValue = value;
                    _hasChanged = true;
                }
                else if (value is Int16 ||
                         value is Int32 ||
                         value is Int64 ||
                         value is String ||
                         value is Double ||
                         value is Single ||
                         value is Byte ||
                         value is Decimal)
                {
                    if (value != null)
                    {
                        _value = value.ToString();
                    }
                    else
                    {
                        _value = String.Empty;
                    }
                    _hasChanged = true;
                    _modifier = Modifiers.Normal;
                    IsBasicType = true;
                }
                else
                {
                    _nonBasicValue = value;
                    _hasChanged = true;
                }
            }
        }

        public Type Type
        {
            get
            {
                if (_nonBasicValue == null)
                {
                    return typeof(object);
                }
                return _nonBasicValue.GetType();
            }
        }

        public static Value Create(Object value)
        {
            return Create(String.Empty, value, Modifiers.None);
        }

        public static Value Create(Object value, Modifiers mode)
        {
            return Create(String.Empty, value, mode);
        }

        public static Value Create(String name, Object value)
        {
            return Create(name, value, Modifiers.None);
        }

        public static Value Create(String name, Object value, Modifiers mode)
        {
            String scope = String.Empty;
            if (name.Contains(":"))
            {
                string[] partArray = name.Split(':');
                scope = name.Split(':')[0];
                name = name.Split(':')[1];
            }
            return Create(scope, name, value, mode);
        }

        public static Value Create(String scope, String name, Object value, Modifiers mode)
        {
            if (scope.Contains(":") || name.Contains(":"))
            {
                throw new InvalidOperationException(Resource.General_ColonNotAllowed);
            }
            if (!String.IsNullOrEmpty(scope))
            {
                name = scope + ":" + name;
            }
            var v = new Value
                    {
                        _fullName = name
                    };
            if ((mode & Modifiers.RetainRawValue) == Modifiers.RetainRawValue)
            {
                v._nonBasicValue = value;
            }
            else if (value is Int16 ||
                     value is Int32 ||
                     value is Int64 ||
                     value is String ||
                     value is Double ||
                     value is Single ||
                     value is Byte ||
                     value is Decimal)
            {
                v._value = value.ToString();
                v.IsBasicType = true;
            }
            else
            {
                v._nonBasicValue = value;
            }
            v._hasChanged = true;
            //+
            return v;
        }

        public static Value Raw(Object value)
        {
            return Create(value, Modifiers.RetainRawValue);
        }
        public static Value Raw(String name, Object value)
        {
            return Create(name, value, Modifiers.RetainRawValue);
        }
        public static Value Raw(String scope, String name, Object value)
        {
            return Create(scope, name, value, Modifiers.RetainRawValue);
        }

        public override string ToString()
        {
            return _value;
        }

        public static Map<String, Value> ConvertObjectArrayToValueList(Object[] objectArray)
        {
            var list = new Map<String, Value>();
            if (objectArray != null)
            {
                if (objectArray.Length == 1)
                {
                    var v = objectArray[0] as Value;
                    if (v != null)
                    {
                        list.Add(v.Name, v);
                    }
                    else
                    {
                        v = new Value();
                        v.AsObject = objectArray[0];
                        //+
                        list.Add(String.Empty, v);
                    }
                }
                else
                {
                    foreach (Object item in objectArray)
                    {
                        var v = item as Value;
                        if (v != null)
                        {
                            list.Add(v.Name, v);
                        }
                        else
                        {
                            if (item == null)
                            {
                                continue;
                            }
                            var itemAsValue = item as Value;
                            String name;
                            if (itemAsValue != null && !String.IsNullOrEmpty(itemAsValue.Name))
                            {
                                name = itemAsValue.Name;
                            }
                            else
                            {
                                name = "__#" + GuidCreator.GetNewGuid();
                            }
                            v = new Value();
                            v.AsObject = item;
                            list.Add(name, v);
                        }
                    }
                }
            }
            //+
            return list;
        }
    }
}