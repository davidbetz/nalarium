using System;
//+
namespace Nalarium
{
    public class Value
    {
        [Flags]
        public enum Modifiers
        {
            Normal = 0,
            IsDefault = 1
        }

        private Object _nonBasicValue;
        private String _value;
        private Byte _valueByte;
        private Int32 _valueInt32;
        private Int64 _valueInt64;
        private DateTime _valueDateTime;
        private Double _valueDouble;
        private Boolean _valueBoolean;

        public Boolean IsBasicType { get; set; }
        public String Name { get; set; }

        private Modifiers _modifier = Modifiers.Normal;
        private Boolean _hasChanged = false;

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

        private Value()
        {
        }

        public static Value Create(Object value)
        {
            Value v = new Value();
            if (value is Int16 ||
                value is Int32 ||
                value is Int64 ||
                value is String ||
                value is Double ||
                value is Single ||
                value is Byte ||
                value is Decimal)
            {
                if (value == null)
                {
                    v._value = String.Empty;
                }
                else
                {
                    v._value = value.ToString();
                    //+
                }
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
        public static Value Create(Object value, Modifiers defaultMode)
        {
            Value v = Create(value);
            v._modifier = defaultMode;
            //+
            return v;
        }
        public static Value Create(String name, Object value)
        {
            Value v = Create(value);
            v.Name = name;
            //+
            return v;
        }
        public static Value Create(String name, Object value, Modifiers defaultMode)
        {
            Value v = Create(name, value);
            v.Name = name;
            v._modifier = defaultMode;
            //+
            return v;
        }

        public String AsString
        {
            get
            {
                if (_modifier == Modifiers.IsDefault)
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
                if (_modifier == Modifiers.IsDefault)
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
                if (_modifier == Modifiers.IsDefault)
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
                if (_modifier == Modifiers.IsDefault)
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
                if (_modifier == Modifiers.IsDefault)
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
                if (_modifier == Modifiers.IsDefault)
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
                if (_modifier == Modifiers.IsDefault)
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
                if (_modifier == Modifiers.IsDefault)
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
                if (value is Int16 ||
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

        public override string ToString()
        {
            return _value;
        }

        public static Map<String, Value> ConvertObjectArrayToValueList(Object[] objectArray)
        {
            Map<String, Value> list = new Map<String, Value>();
            if (objectArray != null)
            {
                if (objectArray.Length == 1)
                {
                    Value v = objectArray[0] as Value;
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
                        Value v = item as Value;
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
                            Value itemAsValue = item as Value;
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