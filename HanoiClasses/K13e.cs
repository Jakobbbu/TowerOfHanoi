using System;
using System.Collections.Generic;
using System.Text;

namespace Hanoi.HanoiClasses
{
    class K13e : Tower
    {
        public K13e(byte startPeg, byte endPeg, int numDiscs) : base(startPeg, endPeg, numDiscs) { }
        
        public override void MakeMoveForSmallDimension(byte[] state)
        {
            bool[] InnercanMoveArray = new bool[this.NumPegs];
            ResetArray(InnercanMoveArray); 
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
                        if (InnercanMoveArray[0])
                        {
                            innernewState = new byte[state.Length];
                            for (int x = 0; x < state.Length; x++)
                                innernewState[x] = state[x];
                            innernewState[i] = 0;
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
                            if (InnercanMoveArray[j])
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
                InnercanMoveArray[state[i]] = false;
            }
        }
    }
}
