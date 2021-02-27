using System;
using System.Collections.Generic;
using System.Text;

namespace Hanoi.HanoiClasses
{
    class K13e : Tower
    {
        public K13e(byte startPeg, byte endPeg, int numDiscs) : base(startPeg, endPeg, numDiscs)
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
            bool[] InnercanMoveArray = new bool[this.NumPegs];
            ResetArray(InnercanMoveArray); //can move array je globalna
            byte[] innernewState;

            for (int i = 0; i < NumDiscs; i++)
            {
                if (InnercanMoveArray[state[i]])
                {
                    if (state[i] == 0)
                    {
                        for (byte j = 1; j < NumPegs; j++)
                        {
                            if (InnercanMoveArray[j])
                            {
                                innernewState = new byte[state.Length];
                                for (int x = 0; x < state.Length; x++)
                                    innernewState[x] = state[x];
                                innernewState[i] = j;
                                long innercurrentState = StateToLong(innernewState); // new state je globalna
                                // Zaradi takih preverjanj potrebujemo hitro iskanje!
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
                        if (InnercanMoveArray[0])
                        {
                            innernewState = new byte[state.Length];
                            for (int x = 0; x < state.Length; x++)
                                innernewState[x] = state[x];
                            innernewState[i] = 0;
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
                    else if (state[i] == 2)
                    {
                        foreach (byte j in new byte[] { 0, 3 })
                        {
                            if (InnercanMoveArray[j])
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
                            if (InnercanMoveArray[j])
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
                InnercanMoveArray[state[i]] = false;
            }
        }
    }
}
