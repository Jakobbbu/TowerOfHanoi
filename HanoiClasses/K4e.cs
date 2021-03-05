using System;
using System.Collections.Generic;
using System.Text;

namespace Hanoi.HanoiClasses
{
    class K4e : Tower
    {
        public K4e(byte startPeg, byte endPeg, int numDiscs) : base(startPeg, endPeg, numDiscs)
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
            bool[] innercanMoveArray = new bool[this.NumPegs];
            ResetArray(innercanMoveArray);
            byte[] innernewState;

            for (int i = 0; i < NumDiscs; i++)
            {
                if (innercanMoveArray[state[i]])
                {
                    if (state[i] == 0)
                    {
                        foreach (byte j in new byte[] { 1, 2, 3 })
                        {
                            if (innercanMoveArray[j])
                            {
                                innernewState = new byte[state.Length];
                                for (int x = 0; x < state.Length; x++)
                                    innernewState[x] = state[x];
                                innernewState[i] = j;
                                long innercurrentState = StateToLong(innernewState);
                                if (!setPrev.Contains(innercurrentState))
                                {
                                    lock (setNew)
                                    {
                                        setNew.Enqueue(innercurrentState);
                                    }
                                }


                            }
                        }
                    }
                    else if (state[i] == 1)
                    {
                        foreach (byte j in new byte[] {0, 2, 3 })
                        {
                            if (innercanMoveArray[j])
                            {
                                innernewState = new byte[state.Length];
                                for (int x = 0; x < state.Length; x++)
                                    innernewState[x] = state[x];
                                innernewState[i] = j;
                                long innercurrentState = StateToLong(innernewState);
                                if (!setPrev.Contains(innercurrentState))
                                {
                                    lock (setNew)
                                    {
                                        setNew.Enqueue(innercurrentState);
                                    }
                                }

                            }
                        }
                    }
                    else if (state[i] == 2)
                    {
                        foreach (byte j in new byte[] { 0, 1 })
                        {
                            if (innercanMoveArray[j])
                            {
                                innernewState = new byte[state.Length];
                                for (int x = 0; x < state.Length; x++)
                                    innernewState[x] = state[x];
                                innernewState[i] = j;
                                long innercurrentState = StateToLong(innernewState);
                                if (!setPrev.Contains(innercurrentState))
                                {
                                    lock (setNew)
                                    {
                                        setNew.Enqueue(innercurrentState);
                                    }
                                }

                            }
                        }
                    }
                    else if (state[i] == 3)
                    {
                        foreach (byte j in new byte[] { 0, 1 })
                        {
                            if (innercanMoveArray[j])
                            {
                                innernewState = new byte[state.Length];
                                for (int x = 0; x < state.Length; x++)
                                    innernewState[x] = state[x];
                                innernewState[i] = j;
                                long innercurrentState = StateToLong(innernewState);
                                if (!setPrev.Contains(innercurrentState))
                                {
                                    lock (setNew)
                                    {
                                        setNew.Enqueue(innercurrentState);
                                    }

                                }

                            }
                        }
                    }
                }
                innercanMoveArray[state[i]] = false;
            }
        }

    }
}

