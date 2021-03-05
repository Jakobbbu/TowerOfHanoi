using System;
using System.Collections.Generic;
using System.Text;

namespace Hanoi.HanoiClasses
{
    class K13_12 : Tower
    {
        public K13_12(byte startPeg, byte endPeg, int numDiscs) : base(startPeg, endPeg, numDiscs)
        {
            StartArray = ArrayAllEqual(StartPeg);
            FinalState = StateAllEqual(FinalPeg);

            setPrev = new HashSet<long>();
            setCurrent = new HashSet<long>();
            setNew = new Queue<long>();


            CurrentDistance = 0;
            InitialState = StateToLong(StartArray);
            setCurrent.Add(InitialState);

            MaxCardinality = 0;
            MaxMemory = 0;
        }

        public override void MakeMoveForSmallDimension(byte[] state)
        {
            bool[] canMoveArray = new bool[this.NumPegs];
            ResetArray(canMoveArray);


            for (int i = 0; i < NumDiscs; i++)
            {
                if (canMoveArray[state[i]])
                {
                    if (state[i] == 0)
                    {
                        for (byte j = 1; j < NumPegs; j++)
                        {
                            if (canMoveArray[j])
                            {
                                lock (setNew)
                                {
                                    AddNewState(state, i, j);
                                }

                            }
                        }
                    }
                    else // From other vertices we can only move to center
                    {
                        if (canMoveArray[0])
                        {
                            lock (setNew)
                            {
                                AddNewState(state, i, 0);
                            }

                        }
                    }
                }
                canMoveArray[state[i]] = false;
            }

        }
    }

}