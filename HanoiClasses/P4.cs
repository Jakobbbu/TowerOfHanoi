using System;
using System.Collections.Generic;
using System.Text;

namespace HanoiFinal.HanoiClasses
{
    class P4 : Tower
    {
        public P4(byte startPeg, byte endPeg, int numDiscs) : base(startPeg, endPeg, numDiscs)
        {
            startArray = ArrayAllEqual(StartPeg);
            finalState = StateAllEqual(FinalPeg);

            setIgnore = new HashSet<long>();
            setPrev = new HashSet<long>();
            setCurrent = new HashSet<long>();
            setNew = new Queue<long>();


            currentDistance = 0;
            initialState = StateToLong(startArray);
            setCurrent.Add(initialState);

            maxCardinality = 0;
            maxMemory = 0;
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
                        foreach (byte j in new byte[] {  3 })
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
                        foreach (byte j in new byte[] { 2 })
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
                        foreach (byte j in new byte[] { 1, 3 })
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
                        foreach (byte j in new byte[] { 0, 2 })
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
