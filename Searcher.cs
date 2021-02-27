using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hanoi.HanoiClasses;


namespace Hanoi
{
    class Searcher
    {
        private Tower tower;
        public Searcher(Tower t)
        {
            this.tower = t;
        }

        public int SearchShortestPath()
        {
            while(true)
            {
                if (tower.maxCardinality < tower.setCurrent.Count)
                    tower.maxCardinality = tower.setCurrent.Count;
                
                bool match = false;
                tower.setCurrent.AsParallel().WithDegreeOfParallelism(Environment.ProcessorCount - 1)
                .ForAll(num =>
                {
                    if (num == tower.finalState)
                    {
                        
                        match = true;
                    }
                    byte[] tmpState = tower.LongToState(num); 
                    tower.MakeMoveForSmallDimension(tmpState);
                });

                if (match) return tower.currentDistance;

                long mem = GC.GetTotalMemory(false);
                if (tower.maxMemory < mem)
                {
                    tower.maxMemory = mem;
                }

                tower.setPrev = tower.setCurrent;
                tower.setCurrent = new HashSet<long>();
                int elts = tower.setNew.Count;
                for (int i = 0; i < elts; i++)
                {
                    tower.setCurrent.Add(tower.setNew.Dequeue());
                }

                tower.setNew = new Queue<long>();

                tower.incrementCurrentDistance();

                Console.WriteLine("Current distance: " + tower.currentDistance + "     Maximum cardinality: " + tower.maxCardinality);
                Console.WriteLine("Memory allocation: " + mem / 1000000 + "MB  \t\t Maximum memory: " + tower.maxMemory / 1000000 + "MB");
                Console.CursorTop -= 2;
            }
            
        }

        

    }
}
