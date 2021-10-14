using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemaSpectacolelor
{
    public class Solver
    {
        public List<Show> findShow(List<Show> shows)
        {
            var results = new List<Show>();
            var showsByEndTime = shows;
            showsByEndTime = showsByEndTime.OrderBy(s => s.end).ToList();

            results.Add(showsByEndTime[0]);
            var last_show_end = results[0].end;

            for(int i = 1; i < showsByEndTime.Count(); i++)
            {
                if(TimeSpan.Compare(last_show_end, showsByEndTime[i].start) <= 0)
                {
                    results.Add(showsByEndTime[i]);
                    last_show_end = showsByEndTime[i].end;
                }
            }

            return results;
        }
    }
}
