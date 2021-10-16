using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArboreleDeCostMinim
{
    public class Solver
    {
        public static List<Edge> findSolution(List<Edge> edges, int nodes)
        {
            var finalEdges = new List<Edge>();
            int[] visited = new int[nodes + 1];

            for (int i = 0; i < nodes + 1; i++)
                visited[i] = -1;

            for(int i = 0; i < edges.Count() - 1; i++)
            {
                for(int j = i + 1; j < edges.Count(); j++)
                {
                    if(edges[i].c > edges[j].c)
                    {
                        var aux = edges[i];
                        edges[i] = edges[j];
                        edges[j] = aux;
                    }
                }
            }

            visited[1] = 1;
            for(int i = 0; i < nodes-1; i++)
            {
                for(int j = 0; j < edges.Count(); j++)
                {
                    if ((visited[edges[j].n1] == -1 && visited[edges[j].n2] == 1) || (visited[edges[j].n1] == 1 && visited[edges[j].n2] == -1))
                    {
                        finalEdges.Add(edges[j]);
                        visited[edges[j].n1] = 1;
                        visited[edges[j].n2] = 1;
                        break;
                    }
                }
            }

            return finalEdges;
        }
    }
}
