using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MinMaxValExpresie
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = "inputFile.txt";
            var outputFile = "outputFile.txt";
            int n = 0, m = 0;
            int[] A = new int[10];
            int[] B = new int[10];

            ReadDataFromFile(inputFile, ref m, ref n, ref A, ref B);

            Array.Resize<int>(ref A, n);
            Array.Resize<int>(ref B, m);

            Array.Sort(A);
            Array.Sort(B);

            var text = "Minimum: " + GetMinimumExpression(m, n, A, B) + " / Maximum: " + GetMaximumExpression(m, n, A, B);

            Console.Write(text);
            WriteToFile(outputFile, text);
            ShowArrays(m, n, A, B);

            Console.ReadLine();
        }

        private static void ReadDataFromFile(string inputFile, ref int m, ref int n, ref int[] A, ref int[] B)
        {
            var allLines = File.ReadAllLines(inputFile);
            m = Convert.ToInt32(allLines[0].Split(',')[0]);
            n = Convert.ToInt32(allLines[0].Split(',')[1]);
            
            var BVals = allLines[1].Split(',');
            var AVals = allLines[2].Split(',');

            for (int i = 0; i < AVals.Count(); i++)
            {
                A[i] = Convert.ToInt32(AVals[i]);
            }
            for (int i = 0; i < BVals.Count(); i++)
            {
                B[i] = Convert.ToInt32(BVals[i]);
            }
        }

        private static int GetMaximumExpression(int m, int n, int[] A, int[] B)
        {
            int i = n-1, j = m-1, expr = 0;
            while(A[i] > 0 && j >= 0)
            {
                expr = expr + A[i] * B[j];
                i--;
                j--;
                if(i < 0 || j < 0)
                {
                    break;
                }
            }
            return expr;
        }

        private static int GetMinimumExpression(int m, int n, int[] A, int[] B)
        {
            int i = 0, j = 0, expr = 0;
            while (j < m)
            {
                expr = expr + A[i] * B[j];
                i++;
                j++;
            }
            return expr;
        }


        private static void ShowArrays(int m, int n, int[] A, int[] B)
        {
            Console.Write("\nM: " + m + " N: " + n + "\n");
            
            Console.WriteLine("\nB: ");
            foreach (int value in B)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine("\nA: ");
            foreach (int value in A)
            {
                Console.Write(value + " ");
            }
        }

        private static void WriteToFile(string filePath, string text)
        {
            File.WriteAllText(filePath, "");
            File.AppendAllText(filePath, text);
        }
    }
}
