#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

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

        private string _fullName;
        private bool _hasChanged;
        private Modifiers _modifier = Modifiers.Normal;

        private object _nonBasicValue;
        private string _value;
        private bool _valueBoolean;
        private byte _valueByte;
        private DateTime _valueDateTime;
        private double _valueDouble;
        private int _valueInt32;
        private long _valueInt64;

        private Value()
        {
        }

        public bool IsBasicType { get; set; }

        public string Scope
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

        public string Name
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

        public bool IsScoped
        {
            get { return _fullName.Contains(":"); }
        }

        public static Value Blank
        {
            get
            {
                var v = Create(string.Empty);
                v._modifier = Modifiers.IsDefault;
                //+
                return v;
            }
        }

        public string AsString
        {
            get
            {
                if ((_modifier & Modifiers.IsDefault) == Modifiers.IsDefault)
                {
                    return string.Empty;
                }
                if (!IsBasicType)
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

        public int AsInt32
        {
            get
            {
                if ((_modifier & Modifiers.IsDefault) == Modifiers.IsDefault)
                {
                    return 0;
                }
                if (!IsBasicType)
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

        public long AsInt64
        {
            get
            {
                if ((_modifier & Modifiers.IsDefault) == Modifiers.IsDefault)
                {
                    return 0;
                }
                if (!IsBasicType)
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

        public byte AsByte
        {
            get
            {
                if ((_modifier & Modifiers.IsDefault) == Modifiers.IsDefault)
                {
                    return 0;
                }
                if (!IsBasicType)
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

        public bool AsBoolean
        {
            get
            {
                if ((_modifier & Modifiers.IsDefault) == Modifiers.IsDefault)
                {
                    return false;
                }
                if (!IsBasicType)
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

        public double AsDouble
        {
            get
            {
                if ((_modifier & Modifiers.IsDefault) == Modifiers.IsDefault)
                {
                    return 0;
                }
                if (!IsBasicType)
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
                if (!IsBasicType)
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

        public object AsObject
        {
            get
            {
                if ((_modifier & Modifiers.IsDefault) == Modifiers.IsDefault)
                {
                    return null;
                }
                if (!IsBasicType)
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
                else if (value is short ||
                         value is int ||
                         value is long ||
                         value is string ||
                         value is double ||
                         value is float ||
                         value is byte ||
                         value is decimal)
                {
                    if (value != null)
                    {
                        _value = value.ToString();
                    }
                    else
                    {
                        _value = string.Empty;
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
                    return typeof (object);
                }
                return _nonBasicValue.GetType();
            }
        }

        public static Value Create(object value)
        {
            return Create(string.Empty, value, Modifiers.None);
        }

        public static Value Create(object value, Modifiers mode)
        {
            return Create(string.Empty, value, mode);
        }

        public static Value Create(string name, object value)
        {
            return Create(name, value, Modifiers.None);
        }

        public static Value Create(string name, object value, Modifiers mode)
        {
            var scope = string.Empty;
            if (name.Contains(":"))
            {
                var partArray = name.Split(':');
                scope = name.Split(':')[0];
                name = name.Split(':')[1];
            }
            return Create(scope, name, value, mode);
        }

        public static Value Create(string scope, string name, object value, Modifiers mode)
        {
            if (scope.Contains(":") || name.Contains(":"))
            {
                throw new InvalidOperationException(Resource.General_ColonNotAllowed);
            }
            if (!string.IsNullOrEmpty(scope))
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
            else if (value is short ||
                     value is int ||
                     value is long ||
                     value is string ||
                     value is double ||
                     value is float ||
                     value is byte ||
                     value is decimal)
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

        public static Value Raw(object value)
        {
            return Create(value, Modifiers.RetainRawValue);
        }

        public static Value Raw(string name, object value)
        {
            return Create(name, value, Modifiers.RetainRawValue);
        }

        public static Value Raw(string scope, string name, object value)
        {
            return Create(scope, name, value, Modifiers.RetainRawValue);
        }

        public override string ToString()
        {
            return _value;
        }

        public static Map<string, Value> ConvertObjectArrayToValueList(object[] objectArray)
        {
            var list = new Map<string, Value>();
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
                        list.Add(string.Empty, v);
                    }
                }
                else
                {
                    foreach (var item in objectArray)
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
                            string name;
                            if (itemAsValue != null && !string.IsNullOrEmpty(itemAsValue.Name))
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