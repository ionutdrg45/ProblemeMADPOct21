using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemaRucsacului
{
    public class Solver
    {
        public static Backpack FindObjects(List<Object> objects, Backpack backpack)
        {
            var sortedObjects = new List<Object>();
            sortedObjects = objects.OrderByDescending(obj => obj.C / obj.G).ToList();
            var backpackUsedG = backpack.GG;
            var last_added = -1;
            backpack.Objects = new List<Object>();

            for(int i = 0; i < sortedObjects.Count(); i++)
            {
                if(sortedObjects[i].G <= backpackUsedG)
                {
                    backpackUsedG -= sortedObjects[i].G;
                    backpack.Objects.Add(sortedObjects[i]);
                    last_added = i;
                }
            }

            if(backpackUsedG > 0 && last_added != -1 && last_added + 1 < sortedObjects.Count())
            {
                var inital_raport = sortedObjects[last_added + 1].C / sortedObjects[last_added + 1].G;
                sortedObjects[last_added + 1].G = backpackUsedG;
                sortedObjects[last_added + 1].C = sortedObjects[last_added + 1].G * inital_raport;
                backpack.Objects.Add(sortedObjects[last_added + 1]);
            }

            return backpack;
        }
    }
}
