using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProblemaSpectacolelor
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = "Input.txt";
            var outputFile = "Output.txt";
            var shows = ReadInputFile(inputFile);
            var showForDay = new Solver().findShow(shows);
            
            DisplayShows(shows);
            Console.WriteLine("\n\nShows for a day:");
            DisplayShows(showForDay);
            WriteToFile(outputFile, showForDay);
            Console.ReadLine();
        }

        private static List<Show> ReadInputFile(string filePath)
        {
            var shows = new List<Show>();
            var lines = File.ReadAllLines(filePath);
            var numberOfShows = Convert.ToInt32(lines[0]);

            for (int i = 0; i < numberOfShows; i++)
            {
                var details = lines[i + 1].Split(',');
                shows.Add(new Show()
                {
                    Number = i + 1,
                    start = TimeSpan.Parse(details[0]),
                    duration = Convert.ToInt32(details[1]),
                    end = TimeSpan.Parse(details[0]).Add(TimeSpan.FromHours(Convert.ToInt32(details[1])))
                });
            }
            return shows;
        }

        public static void DisplayShows(List<Show> shows)
        {
            for (int i = 0; i < shows.Count; i++)
            {
                Console.Write("Show no #" + shows[i].Number + " (" + shows[i].duration + "h) start at " + shows[i].start + " / end at " + shows[i].end + "\n");
            }
            Console.Write("\n");
        }

        private static void WriteToFile(string filePath, List<Show> shows)
        {
            File.WriteAllText(filePath, "");
            for (int i = 0; i < shows.Count; i++)
            {
                File.AppendAllText(filePath, "Show no #" + shows[i].Number + " (" + shows[i].duration + "h) start at " + shows[i].start + " / end at " + shows[i].end + "\n");
            }
        }
    }
}
