using System.Web.Script.Serialization;
using System.IO;
using System;

namespace JSONCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var ser = new JavaScriptSerializer();
            var JSONstring = File.ReadAllText("..\\..\\arquivos\\JSON.json");
            Person p1 = ser.Deserialize<Person>(JSONstring);
            Console.WriteLine(p1);
            Console.ReadKey();

            var p2 = new Person() { Name = "Vinicius",Age = 10};
            var outputJSON = ser.Serialize(p2);
            File.WriteAllText("..\\..\\arquivos\\JSON.json", outputJSON);

            Console.WriteLine(p2);
            Console.ReadKey();
        }
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
