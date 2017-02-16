using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.IO;

namespace JSONDataStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading data.json");
            var JSONstring = File.ReadAllText("..\\..\\arquivos\\data.json");
            var myList = JsonConvert.DeserializeObject<List<Item>>(JSONstring);

            if (myList == null)
                myList = new List<Item>();

            var input = string.Empty;
            var inputInt = 0;
            var inputString = string.Empty;

            while (input != "q")
            {
                Console.WriteLine("Press 'a' to add new Item");
                Console.WriteLine("Press 'd' to Delete Item");
                Console.WriteLine("Press 's' to Show Content");
                Console.WriteLine("Press 'q' to Quit Program");

                input = Console.ReadLine();

                switch (input)
                {
                    case "a":
                        Console.WriteLine("Adding a new Item");
                        Console.WriteLine("Enter Item name:");
                        inputString = Console.ReadLine();
                        Console.WriteLine("Enter Item prince (Numeric Values Only");
                        inputInt = Convert.ToInt32( Console.ReadLine());
                        myList.Add(new Item(inputString, inputInt));
                        Console.WriteLine(string.Format("Added Item {0} With price {1}", inputString, inputInt));
                        break;

                    case "d":
                        Console.WriteLine("Deleting Item");
                        Console.WriteLine("Enter Item name to delete:");
                        inputString = Console.ReadLine();
                        myList.Remove(new Item(inputString));
                        Console.WriteLine(string.Format("Deleted item with name {0}", inputString));
                        break;

                    case "s":
                        Console.WriteLine("\nShowing Contents");
                        foreach (var item in myList)
                        {
                            Console.WriteLine(string.Format("Item: {0} | R$ {1}",item.name,item.price));
                        }
                        Console.WriteLine("\n");
                        break;
                    case "q":
                        Console.WriteLine("Quit Program");
                        break;
                    default:
                        Console.WriteLine("Incorret command, trye again");
                        break;
                }
            }

            Console.WriteLine("Rewriting data.Json");
            string data = JsonConvert.SerializeObject(myList);
            File.WriteAllText("..\\..\\arquivos\\data.json",data);
            Console.Read(); 
        }
    }

    class Item : IEquatable<Item>
    {
        public string name;
        public int price;
        private string inputString;

        public Item(string name, int prince = 0)
        {
            this.name = name;
            this.price = prince;
        }

        public bool Equals(Item other)
        {
            if (other == null) return false;
            return (this.name.Equals(other.name));
        }
    }
}
