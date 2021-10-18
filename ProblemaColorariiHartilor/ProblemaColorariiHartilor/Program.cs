using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProblemaColorariiHartilor
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "Input.txt";
            var output = "Output.txt";
            var nodes = 0;

            var vertexList = ReadInputFile(input, ref nodes);

            Console.WriteLine("Solution #1");
            var answer_1 = Solver.findSolution_1(vertexList);
            ShowSolution(answer_1);

            Console.WriteLine("\n\nSolution #2");
            var answer_2 = Solver.findSolution_2(vertexList);
            ShowSolution(answer_2);

            WriteToFile(output, answer_1, answer_2);

            Console.ReadLine();
        }

        private static List<Vertex> ReadInputFile(string filePath, ref int nodes)
        {
            var vertexList = new List<Vertex>();
            var lines = File.ReadAllLines(filePath);

            nodes = Convert.ToInt32(lines[0]);
            var current_vertex = Convert.ToInt32(lines[1].Split(' ')[0]);
            var temp_neighbors = new List<Neighbor>();

            for (int i = 1; i < lines.Count(); i++)
            {
                var details = lines[i].Split(' ');
                if (vertexList.Find(vertex => vertex.Number == Convert.ToInt32(details[0])) == null)
                {
                    vertexList.Add(new Vertex()
                    {
                        Number = Convert.ToInt32(details[0]),
                        Valence = 0,
                        Neighbors = new List<Neighbor>()
                    });
                }
                if (vertexList.Find(vertex => vertex.Number == Convert.ToInt32(details[1])) == null)
                {
                    vertexList.Add(new Vertex()
                    {
                        Number = Convert.ToInt32(details[1]),
                        Valence = 0,
                        Neighbors = new List<Neighbor>()
                    });
                }
                if (current_vertex != Convert.ToInt32(details[0]))
                {
                    for(int j = 0; j < temp_neighbors.Count(); j++)
                    {
                        vertexList.Find(vertex => vertex.Number == temp_neighbors[j].n1.Number).Neighbors.Add(temp_neighbors[j]);
                        vertexList.Find(vertex => vertex.Number == temp_neighbors[j].n1.Number).Valence += 1;

                        vertexList.Find(vertex => vertex.Number == temp_neighbors[j].n2.Number).Neighbors.Add(temp_neighbors[j]);
                        vertexList.Find(vertex => vertex.Number == temp_neighbors[j].n2.Number).Valence += 1;
                    }

                    current_vertex = Convert.ToInt32(details[0]);
                    temp_neighbors.Clear();
                }

                temp_neighbors.Add(new Neighbor()
                {
                    n1 = vertexList.Find(vertex => vertex.Number == Convert.ToInt32(details[0])),
                    n2 = vertexList.Find(vertex => vertex.Number == Convert.ToInt32(details[1]))
                });
            }
            for (int j = 0; j < temp_neighbors.Count(); j++)
            {
                vertexList.Find(vertex => vertex.Number == temp_neighbors[j].n1.Number).Neighbors.Add(temp_neighbors[j]);
                vertexList.Find(vertex => vertex.Number == temp_neighbors[j].n1.Number).Valence += 1;

                vertexList.Find(vertex => vertex.Number == temp_neighbors[j].n2.Number).Neighbors.Add(temp_neighbors[j]);
                vertexList.Find(vertex => vertex.Number == temp_neighbors[j].n2.Number).Valence += 1;
            }

            return vertexList;
        }

        private static void ShowSolution(List<Color> colors)
        {
            for (int i = 0; i < colors.Count(); i++)
            {
                Console.WriteLine("Color #" + colors[i].Number + ":");
                for(int j = 0; j < colors[i].VertexList.Count(); j++)
                {
                    Console.WriteLine("\tvertex #" + colors[i].VertexList[j].Number + " (valence: " + colors[i].VertexList[j].Valence + ")");
                }
            }
        }

        private static void WriteToFile(string filePath, List<Color> colors, List<Color> colors2)
        {
            File.WriteAllText(filePath, "");
            for (int i = 0; i < colors.Count(); i++)
            {
                File.AppendAllText(filePath, "Color #" + colors[i].Number + ":\n");
                for (int j = 0; j < colors[i].VertexList.Count(); j++)
                {
                    File.AppendAllText(filePath, "\tvertex #" + colors[i].VertexList[j].Number + " (valence: " + colors[i].VertexList[j].Valence + ")\n");
                }
            }
            File.AppendAllText(filePath, "\n\n");
            for (int i = 0; i < colors2.Count(); i++)
            {
                File.AppendAllText(filePath, "Color #" + colors2[i].Number + ":\n");
                for (int j = 0; j < colors2[i].VertexList.Count(); j++)
                {
                    File.AppendAllText(filePath, "\tvertex #" + colors2[i].VertexList[j].Number + " (valence: " + colors2[i].VertexList[j].Valence + ")\n");
                }
            }
        }
    }
}
