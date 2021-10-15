using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProblemaRucsacului
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = "Input.txt";
            var outputFile = "Output.txt";
            var backpack = new Backpack();

            var objects = ReadInputFile(inputFile, ref backpack);

            Console.WriteLine("Maximum Backpack weight (GG): " + backpack.GG);
            Console.WriteLine("Initial objects readed from file: ");
            ShowObjects(objects);
            Console.WriteLine("\n");

            backpack = Solver.FindObjects(objects, backpack);

            Console.WriteLine("Objects that can fit by their raport: ");
            ShowObjects(backpack.Objects);
            Console.WriteLine("\n");

            WriteToFile(outputFile, backpack.Objects);

            Console.ReadLine();
        }
        private static List<Object> ReadInputFile(string filePath, ref Backpack backpack)
        {
            var objects = new List<Object>();
            var lines = File.ReadAllLines(filePath);
            var backpackRead = new Backpack();
            backpackRead.GG  = Convert.ToDouble(lines[0]);
            backpack = backpackRead;
            var numberOfObjects = Convert.ToInt32(lines[1]);

            for (int i = 2; i < numberOfObjects + 2; i++)
            {
                var details = lines[i].Split(',');
                objects.Add(new Object()
                {
                    Number = i - 1,
                    G = Convert.ToDouble(details[0]),
                    C = Convert.ToDouble(details[1])
                });
            }
            return objects;
        }

        private static void ShowObjects(List<Object> objects)
        {
            double total_price = 0, total_weight = 0;
            for (int i = 0; i < objects.Count(); i++)
            {
                Console.WriteLine("Object [#" + objects[i].Number + "]: weight: " + Math.Round(objects[i].G, 2) + ", price: " + Math.Round(objects[i].C, 2) + " - raport: " + Math.Round(objects[i].C / objects[i].G, 2));
                total_price += objects[i].C;
                total_weight += objects[i].G;
            }
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Total weight: " + Math.Round(total_weight, 2) + " / Total price: " + Math.Round(total_price, 2));
        }

        private static void WriteToFile(string filePath, List<Object> objects)
        {
            File.WriteAllText(filePath, "");
            double total_price = 0, total_weight = 0;
            for (int i = 0; i < objects.Count(); i++)
            {
                File.AppendAllText(filePath, "Object [#" + objects[i].Number + "]: weight: " + Math.Round(objects[i].G, 2) + ", price: " + Math.Round(objects[i].C, 2) + " - raport: " + Math.Round(objects[i].C / objects[i].G, 2) + "\n");
                total_price += objects[i].C;
                total_weight += objects[i].G;
            }
            File.AppendAllText(filePath, "---------------------------------------\n");
            File.AppendAllText(filePath, "Total weight: " + Math.Round(total_weight, 2) + " / Total price: " + Math.Round(total_price, 2) + "\n");
        }
    }
}
