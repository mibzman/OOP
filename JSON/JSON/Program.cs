using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace JSON
{

    public class Program
    {
        public static void Main()
        {
            var json = new JValue { Object = new Dictionary<string, JValue>() };
            json["name"] = new JValue("Cam Newton");
            json["age"] = new JValue(26);

            if (json.Type == JType.Object)
            {
                foreach (var value in json.Object)
                {
                    Debug.WriteLine(value.ToString());
                }
            }
        }
    }

}