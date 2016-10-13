using System;
using System.Collections.Generic;

namespace JSON
{
    public enum JType
    {
        Null,
        Bool,
        Number,
        String,
        Array,
        Object,
    }

    public class JValue
    {
        public JType Type { get; private set; }
        private JsonValue Value { get; set; }


        public JValue()
        {
            Type = JType.Null;
        }

        public JValue(bool value)
        {
            Type = JType.Bool;
            Value = new JsonBool { Value = value };
        }

        public JValue(double value)
        {
            Type = JType.Number;
            Value = new JsonNumber { Value = value };
        }

        public JValue(string value)
        {
            Type = JType.String;
            Value = new JsonString { Value = value };
        }

        public JValue(List<JValue> values)
        {
            Type = JType.Array;
            Value = new JsonArray { Values = values };
        }

        public JValue(Dictionary<string, JValue> values)
        {
            Type = JType.Object;
            Value = new JsonObject { Values = values };
        }

        public bool Null
        {
            get { return Type == JType.Null; }
            set { Type = JType.Null; Value = null; }
        }

        public bool Bool
        {
            get
            {
                if (Type != JType.Bool) throw new InvalidCastException();
                return ((JsonBool)Value).Value;
            }
            set
            {
                Type = JType.Bool;
                Value = new JsonBool { Value = value };
            }
        }

        public double Number
        {
            get
            {
                if (Type != JType.Number) throw new InvalidCastException();
                return ((JsonNumber)Value).Value;
            }
            set
            {
                Type = JType.Number;
                Value = new JsonNumber { Value = value };
            }
        }

        public string String
        {
            get
            {
                if (Type != JType.String) throw new InvalidCastException();
                return ((JsonString)Value).Value;
            }
        }

        public List<JValue> Array
        {
            get
            {
                if (Type != JType.Array) throw new InvalidCastException();
                return ((JsonArray)Value).Values;
            }
            set
            {
                Type = JType.Array;
                Value = new JsonArray { Values = value };
            }
        }

        public Dictionary<string, JValue> Object
        {
            get
            {
                if (Type != JType.Object) throw new InvalidCastException();
                return ((JsonObject)Value).Values;
            }
            set
            {
                Type = JType.Object;
                Value = new JsonObject { Values = value };
            }
        }


        public JValue this[string key]
        {
            get { return Object[key]; }
            set { Object[key] = value; }
        }

        public int Count
        {
            get { return Array.Count; }
        }

        public JValue this[int index]
        {
            get { return Array[index]; }
            set { Array[index] = value; }
        }

        public override string ToString()
        {
            return Value.ToString();
        }

    }



    internal class JsonValue
    {
    }

    internal class JsonBool : JsonValue
    {
        public bool Value;

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    internal class JsonNumber : JsonValue
    {
        public double Value;

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    internal class JsonString : JsonValue
    {
        public string Value;

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    internal class JsonArray : JsonValue
    {
        public List<JValue> Values;

        public override string ToString()
        {
            return Values.ToString();
        }
    }

    internal class JsonObject : JsonValue
    {
        public Dictionary<string, JValue> Values;

        public override string ToString()
        {
            return Values.ToString();
        }
    }

    internal class JsonBlob : JsonValue
    {
        public Byte[] Value;

        public override string ToString()
        {
            return System.Convert.ToBase64String(Value);
        }
    }


}
