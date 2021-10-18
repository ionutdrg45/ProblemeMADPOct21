using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemaColorariiHartilor
{
    public class Solver
    {
        public static List<Color> findSolution_1(List<Vertex> vertexList)
        {
            var finalColors = new List<Color>();
            vertexList = vertexList.OrderByDescending(vertex => vertex.Valence).ToList();
            var current_color = 1;
            var nodes_with_colors = 0;

            while(nodes_with_colors < vertexList.Count())
            {
                var color = new Color()
                {
                    Number = current_color,
                    VertexList = new List<Vertex>()
                };
                if (nodes_with_colors == 0)
                {
                    color.VertexList.Add(vertexList[0]);
                    nodes_with_colors++;
                }

                //Console.WriteLine("\nStart while with nodeswithcolors " + nodes_with_colors + " current color " + color.Number);
                for(int i = 1; i < vertexList.Count(); i++)
                {
                    //Console.WriteLine("\tfor vertex: " + vertexList[i].Number);
                    var can_be_added = 1;
                    var can_be_added_2 = 1;

                    for (int j = 0; j < finalColors.Count(); j++)
                    {
                        //Console.WriteLine("\t\tsearch finalcolors found vertex ");
                        for(int k = 0; k < finalColors[j].VertexList.Count;k++)
                        {
                            //Console.WriteLine("\t\t\t" + finalColors[j].VertexList[k].Number);
                        }
                        if (finalColors[j].VertexList.Find(vertex => vertex.Number == vertexList[i].Number) != null)
                        {
                            can_be_added = 0;
                            can_be_added_2 = 0;
                            //Console.WriteLine("\t\t\tCannot be added " + vertexList[i].Number);
                        }
                    }

                    if(can_be_added_2 == 1)
                    {
                        for (int j = 0; j < color.VertexList.Count(); j++)
                        {
                            //Console.WriteLine("\t\tfor vertex: " + color.VertexList[j].Number + " color vertex list count " + color.VertexList.Count());
                            if (color.VertexList[j].Neighbors.Find(n => n.n1.Number == vertexList[i].Number) != null || color.VertexList[j].Neighbors.Find(n => n.n2.Number == vertexList[i].Number) != null)
                            {
                                //Console.WriteLine("\t\t\tDetected that " + vertexList[i].Number + " is a neighbor");
                                can_be_added = 0;
                            }
                        }
                    }

                    if(can_be_added == 1 || (color.VertexList.Count() == 0 && can_be_added_2 == 1))
                    {
                        color.VertexList.Add(vertexList[i]);
                        //Console.WriteLine("added " + vertexList[i].Number + " for color " + color.Number);
                        nodes_with_colors++;
                    }
                }
                if(nodes_with_colors <= vertexList.Count())
                {
                    finalColors.Add(color);
                    current_color++;
                }
            }
            return finalColors;
        }

        public static List<Color> findSolution_2(List<Vertex> vertexList)
        {
            var finalColors = new List<Color>();
            int[] colors = new int[vertexList.Count()];

            for(int i = 0; i < vertexList.Count(); i++)
            {
                colors[i] = 1;
                for(int j = 0; j < i; j++)
                {
                    if ((vertexList[i].Neighbors.Find(n => n.n1.Number == vertexList[j].Number) != null || vertexList[i].Neighbors.Find(n => n.n2.Number == vertexList[j].Number) != null) && colors[j] == colors[i]) colors[i]++;
                }
            }

            var number_of_colors = colors.Max();

            for(int i = 1; i <= number_of_colors; i++)
            {
                finalColors.Add(new Color()
                {
                    Number = i
                });
                finalColors[i - 1].VertexList = new List<Vertex>();
                for(int j = 0; j < vertexList.Count(); j++)
                {
                    if(colors[j] == i)
                    {
                        finalColors[i - 1].VertexList.Add(vertexList[j]);
                    }
                }
            }

            return finalColors;
        }
    }
}
