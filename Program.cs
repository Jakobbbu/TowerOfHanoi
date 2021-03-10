using System;
using System.Diagnostics;
using Hanoi.HanoiClasses;

namespace Hanoi
{
    class Program
    {
       
        static void Main(string[] args)
        {
            while (true){
                 Console.WriteLine("*******Tower Of Hanoi*******");
                 HanoiTowerType type = SelectHanoiType();

                 int k;
                 do
                 {
                     Console.Write("Enter number of discs(1 - 15): ");
                     k = int.Parse(Console.ReadLine());
                 }
                 while (k <= 0 || k > 15);

                int c;
                do
                {
                    Console.Write("Enter 0 for one direction search method\nEnter 1 for biderctional search:\n");
                    c = int.Parse(Console.ReadLine());
                }
                while (c < 0 || c > 1);

                Tower tower = Factory.GetTower(type, k);
                int length;
                if (tower != null)
                {
                    Console.WriteLine("*******RUNING PROGRAM*******");
                    Console.WriteLine($"Running case: {type} with {k} discs:");
                    Stopwatch sw = Stopwatch.StartNew();
                    if (c == 0)
                    {
                        Searcher searcher = new Searcher(tower);
                        length = searcher.SearchShortestPath();
                    }
                    else
                    {
                        Searcher2Dir searcher2 = new Searcher2Dir(tower);
                        length = searcher2.SearchShortestPath();
                    }
                    

                    Console.WriteLine();
                    Console.WriteLine($"\n\nDimension: {k}; Steps: {length}; Time: {sw.Elapsed.TotalSeconds} seconds");
                    Console.WriteLine();

                }
                else
                {
                    Console.WriteLine("ni definiran");
                }
            }
        }



        public static HanoiTowerType SelectHanoiType()
        {
            Console.WriteLine(">> Select coloring type:");
            WriteHanoiTypes();
            return (HanoiTowerType)Enum.Parse(typeof(HanoiTowerType), Console.ReadLine());
        }

        private static void WriteHanoiTypes()
        {
            foreach (string s in Enum.GetNames(typeof(HanoiTowerType)))
            {
                Console.WriteLine("\t" + (int)Enum.Parse(typeof(HanoiTowerType), s) + " - " + s);
            }
        }
    }


    public enum HanoiTowerType
    {
        K4,
        K13_01,
        K13_12,
        K13e_01,
        K13e_12,
        K13e_23,
        K13e_30,
        P4_01,
        P4_12,
        P4_23,
        P4_31,
        C4_01,
        C4_12,
        K4e_01,
        K4e_12,
        K4e_23,
    }

}
