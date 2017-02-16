using Newtonsoft.Json;
using System;
using System.IO;

namespace JSONNET
{
    class Program
    {
        static void Main(string[] args)
        {
            var JSONstring = File.ReadAllText("..\\..\\arquivos\\JSON.json");
            Person p1 = JsonConvert.DeserializeObject<Person>(JSONstring);
            Console.WriteLine(p1);
            Console.ReadKey();

            var p2 = new Person() { Name = "Julia", Age = 8 };
            var outputJSONNET = JsonConvert.SerializeObject(p2);

            File.WriteAllText("..\\..\\arquivos\\JSONNET.json", outputJSONNET);
            Console.WriteLine(p2);
            Console.ReadKey();
        }

        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public override string ToString()
            {
                return string.Format("Name: {0} \nAge: {1}", Name, Age);
            }
        }
    }
}
