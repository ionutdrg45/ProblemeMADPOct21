using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ArboreleDeCostMinim
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = "Input.txt";
            var outputFile = "Output.txt";
            var nodes = 0;
            var edges = ReadInputFile(inputFile, ref nodes);

            var solution = Solver.findSolution(edges, nodes);

            Console.WriteLine("Edges: ");
            ShowEdges(edges);

            Console.WriteLine("\n\nMin Cost Edges: ");
            ShowEdges(solution);

            WriteToFile(outputFile, edges);

            Console.ReadLine();
        }

        private static List<Edge> ReadInputFile(string filePath, ref int nodes)
        {
            var edges = new List<Edge>();
            var lines = File.ReadAllLines(filePath);
            nodes = Convert.ToInt32(lines[0]);

            for (int i = 1; i < lines.Count(); i++)
            {
                var details = lines[i].Split(' ');
                edges.Add(new Edge()
                {
                    n1 = Convert.ToInt32(details[0]),
                    n2 = Convert.ToInt32(details[1]),
                    c = Convert.ToInt32(details[2])
                });
            }
            return edges;
        }

        private static void ShowEdges(List<Edge> edges)
        {
            int total_cost = 0;
            for (int i = 0; i < edges.Count(); i++)
            {
                Console.WriteLine("Edge from " + edges[i].n1 + " to " + edges[i].n2 + ", cost: " + edges[i].c);
                total_cost += edges[i].c;
            }
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Total cost: " + total_cost);
        }

        private static void WriteToFile(string filePath, List<Edge> edges)
        {
            File.WriteAllText(filePath, "");
            int total_cost = 0;
            for (int i = 0; i < edges.Count(); i++)
            {
                File.AppendAllText(filePath, "Edge from " + edges[i].n1 + " to " + edges[i].n2 + ", cost: " + edges[i].c + "\n");
                total_cost += edges[i].c;
            }
            File.AppendAllText(filePath, "---------------------------------------\n");
            File.AppendAllText(filePath, "Total cost: " + total_cost + "\n");
        }
    }
}
