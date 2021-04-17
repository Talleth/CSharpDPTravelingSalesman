using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingForTSP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create the graph
            int[,] graph = new int[,] { { 0, 10, 15, 20 },
                                        { 10, 0, 35, 25 },
                                        { 15, 35, 0, 30 },
                                        { 20, 25, 30, 0 } };

            Console.WriteLine();
            Console.WriteLine("The short path distance is: " + Program.TravelingSalesman(graph, 4));
        }

        public static int TravelingSalesman(int[,] graph, int rows)
        {
            // Add vertices to list
            List<int> vertices = new List<int>();

            for (int i = 0; i < rows; i++)
                if (i != 0)
                    vertices.Add(i);

            // Create variable to store min weight
            int minWeight = int.MaxValue;

            // Loop through each verticies to get new minWeight
            do
            {
                int currentPath = 0;
                int k = 0;
                for (int i = 0; i < vertices.Count; i++)
                {
                    currentPath += graph[k, vertices[i]];
                    k = vertices[i];
                }

                currentPath += graph[k, 0];

                minWeight = Math.Min(minWeight, currentPath); // Update the value of minimum weight
            }

            while (NextPermutation(vertices));

            return minWeight;
        }

        // Helper function to calculate permutations
        public static bool NextPermutation<T>(IList<T> a) where T : IComparable
        {
            if (a.Count < 2) return false;
            var k = a.Count - 2;

            while (k >= 0 && a[k].CompareTo(a[k + 1]) >= 0) k--;
            if (k < 0) return false;

            var l = a.Count - 1;
            while (l > k && a[l].CompareTo(a[k]) <= 0) l--;

            var tmp = a[k];
            a[k] = a[l];
            a[l] = tmp;

            var i = k + 1;
            var j = a.Count - 1;
            while (i < j)
            {
                tmp = a[i];
                a[i] = a[j];
                a[j] = tmp;
                i++;
                j--;
            }

            return true;
        }
    }
}
