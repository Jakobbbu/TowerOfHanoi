using System;
using System.Collections.Generic;
using System.Text;

namespace Hanoi.HanoiClasses
{
    class P4 : Tower
    {
        public P4(byte startPeg, byte endPeg, int numDiscs) : base(startPeg, endPeg, numDiscs) { }
       
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
                                if (!SetPrev.Contains(innercurrentState))
                                {
                                    if (i == NumDiscs - 1 && !IsMoved)
                                    {
                                        IsMoved = true;
                                    }
                                    lock (SetNew)
                                    {
                                        SetNew.Enqueue(innercurrentState);
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
                                if (!SetPrev.Contains(innercurrentState))
                                {
                                    if (i == NumDiscs - 1 && !IsMoved)
                                    {
                                        IsMoved = true;
                                    }
                                    lock (SetNew)
                                    {
                                        SetNew.Enqueue(innercurrentState);
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
                                if (!SetPrev.Contains(innercurrentState))
                                {
                                    if (i == NumDiscs - 1 && !IsMoved)
                                    {
                                        IsMoved = true;
                                    }
                                    lock (SetNew)
                                    {
                                        SetNew.Enqueue(innercurrentState);
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
                                if (!SetPrev.Contains(innercurrentState))
                                {
                                    if (i == NumDiscs - 1 && !IsMoved)
                                    {
                                        IsMoved = true;
                                    }
                                    lock (SetNew)
                                    {
                                        SetNew.Enqueue(innercurrentState);
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
