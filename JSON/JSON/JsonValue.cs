using System;
using System.Collections.Generic;
using System.Text;

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
        internal JsonValue Value { get; set; }


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
            StringBuilder output = new StringBuilder();
            String val = Value.ToString();


            //this is the best I can do formatting wise.  The output is correct json, but I can't debug indents because the VS debug window handles indentation strangley
            int tabCounter = 1;
            bool doNothing = false;
            foreach (char n in val)
            {
                output.Append(n);

                if (n.Equals('{'))
                {
                    tabCounter++;
                    output.Append("\n");
                    for (int i = 0; i <= tabCounter; i++)
                    {
                        output.Append("\t");
                    }
                    doNothing = true;
                }
                else if (n.Equals('}'))
                {
                    tabCounter--;
                    doNothing = false;
                }
                else if (n.Equals('['))
                {
                    tabCounter++;
                }
                else if (n.Equals(']'))
                {
                    tabCounter--;
                }
                
                if (doNothing)
                {
                    if (n.Equals(','))
                    {
                        output.Append("\n");
                        for (int i = 0; i <= tabCounter; i++)
                        {
                            output.Append("\t");
                        }
                    }
                }
            }
            return output.ToString();

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
                StringBuilder output = new StringBuilder();
                foreach (JValue value in Values)
                {
                    output.Append("\"" + value.ToString() + "\",");

                }
                output.Length--;
                return output.ToString();
            }
        }

        internal class JsonObject : JsonValue
        {
            public Dictionary<string, JValue> Values;

            public override string ToString()
            {
                StringBuilder output = new StringBuilder();
                //output.Append("");
                foreach (KeyValuePair<string, JValue> ThisValue in Values)
                {
                    output.Append("\"" + ThisValue.Key + "\":");
                    if (ThisValue.Value.Value is JsonArray) //maybe not so A+ naming
                    {
                        output.Append("[" + ThisValue.Value.ToString() + "],");
                    }
                    else if (ThisValue.Value.Value is JsonObject)
                    {
                        output.Append("{" + ThisValue.Value.ToString() + "},");
                    }
                    else
                    {
                        output.Append("\"" + ThisValue.Value.ToString() + "\"" + ",");
                    }


                }
                output.Length--;
                return output.ToString();
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

        //internal class JFormatter
        //{

        //    string write(List<JValue> list)
        //    {
        //        foreach (value in list) {
        //            write(value)
        //        }
        //    }
        //}


    }
}
