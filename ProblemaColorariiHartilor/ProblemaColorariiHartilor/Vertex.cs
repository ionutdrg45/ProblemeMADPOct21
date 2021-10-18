using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemaColorariiHartilor
{
    public class Vertex
    {
        public int Number { get; set; }
        public int Valence { get; set; }
        public List<Neighbor> Neighbors {get; set;}
    }
}
