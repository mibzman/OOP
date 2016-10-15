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

            var json2 = new JValue { Object = new Dictionary<string, JValue>() };
            json2["name2"] = new JValue("Cam Newton2");
            json2["age2"] = new JValue(28);

            List<JValue> jarray1 = new List<JValue>();

            jarray1.Add(new JValue("bob"));
            jarray1.Add(new JValue("tom"));
            jarray1.Add(new JValue("sally"));

            JValue test1 = new JValue(json2.Object);

            //jarray1.Add(test1);

            JValue test2 = new JValue(jarray1);

            json["test"] = test2;
            json["test2"] = json2;




            if (json.Type == JType.Object)
            {
                Debug.WriteLine("{" + json.ToString() + "}");
            }
        }
    }

}