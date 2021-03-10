using System;
using System.Collections.Generic;
using System.Text;
using Hanoi.HanoiClasses;
using System.Linq;

namespace Hanoi
{
    class Searcher2Dir
    {
        
        private readonly Tower tower;
        public Searcher2Dir (Tower t)
        {
            this.tower = t;
            tower.SetCurrent2 = new HashSet<long>
            {
                tower.FinalState
            };
        }

        public int SearchShortestPath()
        {
            while (true)
            {
                if (tower.MaxCardinality < tower.SetCurrent.Count)
                    tower.MaxCardinality = tower.SetCurrent.Count;

                if (!tower.IsMoved)
                {

                    tower.SetCurrent.AsParallel().WithDegreeOfParallelism(Environment.ProcessorCount - 1)
                    .ForAll((Action<long>)(num =>
                    {
                        byte[] tmpState = tower.LongToState(num);
                        tower.MakeMoveForSmallDimension(tmpState);
                    }));


                    long memo = GC.GetTotalMemory(false);
                    if (tower.MaxMemory < memo)
                    {
                        tower.MaxMemory = memo;
                    }

                    tower.SetPrev = tower.SetCurrent;
                    tower.SetCurrent = new HashSet<long>();
                    int elt = tower.SetNew.Count;
                    for (int i = 0; i < elt; i++)
                    {
                        tower.SetCurrent.Add(tower.SetNew.Dequeue());
                    }

                    tower.SetNew = new Queue<long>();

                    tower.IncrementCurrentDistance();

                    Console.WriteLine("Current distance: " + tower.CurrentDistance + "     Maximum cardinality: " + tower.MaxCardinality);
                    Console.WriteLine("Memory allocation: " + memo / 1000000 + "MB  \t\t Maximum memory: " + tower.MaxMemory / 1000000 + "MB");
                    Console.CursorTop -= 2;

                    continue;

                }  

                if (tower.IsMoved)
                {

                    bool match = false;

                    tower.SetCurrent2.AsParallel().WithDegreeOfParallelism(Environment.ProcessorCount - 1)
                    .ForAll((Action<long>)(num =>
                    {
                        if (tower.SetCurrent.Contains(num))
                        {
                            match = true;
                        }
                        byte[] tmpState = tower.LongToState(num);
                        tower.MakeMoveForSmallDimension(tmpState);
                    }));

                    if (match) return tower.CurrentDistance;

                    long mem = GC.GetTotalMemory(false);
                    if (tower.MaxMemory < mem)
                    {
                        tower.MaxMemory = mem;
                    }

                    tower.SetPrev = tower.SetCurrent2;
                    tower.SetCurrent2 = new HashSet<long>();
                    int elts = tower.SetNew.Count;
                    for (int i = 0; i < elts; i++)
                    {
                        tower.SetCurrent2.Add(tower.SetNew.Dequeue());
                    }

                    tower.SetNew = new Queue<long>();

                    tower.IncrementCurrentDistance();

                    Console.WriteLine("Current distance: " + tower.CurrentDistance + "     Maximum cardinality: " + tower.MaxCardinality);
                    Console.WriteLine("Memory allocation: " + mem / 1000000 + "MB  \t\t Maximum memory: " + tower.MaxMemory / 1000000 + "MB");
                    Console.CursorTop -= 2;
                }

            }
        }
    }
}

