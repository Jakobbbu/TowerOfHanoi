using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hanoi.HanoiClasses;


namespace Hanoi
{
    class Searcher
    {
        private readonly Tower tower;
        public Searcher(Tower t)
        {
            this.tower = t;
        }
        public int SearchShortestPath()
        {
            while(true)
            {
                if (tower.MaxCardinality < tower.SetCurrent.Count)
                    tower.MaxCardinality = tower.SetCurrent.Count;
                
                bool match = false;
                tower.SetCurrent.AsParallel().WithDegreeOfParallelism(Environment.ProcessorCount - 1)
                .ForAll((Action<long>)(num =>
                {
                    if (num == tower.FinalState)
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

                tower.SetPrev = tower.SetCurrent;
                tower.SetCurrent = new HashSet<long>();
                int elts = tower.SetNew.Count;
                for (int i = 0; i < elts; i++)
                {
                    tower.SetCurrent.Add(tower.SetNew.Dequeue());
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
