using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi.HanoiClasses
{
    class K13_01FAST : Tower
    {
        public K13_01FAST(byte startPeg, byte endPeg, int numDiscs) : base(startPeg, endPeg, numDiscs) { }
       
        public override void MakeMoveForSmallDimension(byte[] state)
        {
            bool[] canMoveArray = new bool[this.NumPegs];
            ResetArray(canMoveArray);

            if (NumDiscs == 1)
            {
                IsMoved = true;
                aAddNewState(state, NumDiscs - 1, 1);
                return;
            }

            if (!IsMoved)
            {
              
                for (int i = 0; i < NumDiscs - 2; i++)
                {
                    if (canMoveArray[state[i]])
                    {
                        if (state[i] == 0)
                        {
                            for (byte j = 1; j < NumPegs; j++)
                            {
                                if (canMoveArray[j])
                                {

                                    lock (SetNew)
                                    {
                                        aAddNewState(state, i, j);
                                    }

                                }
                            }
                        }
                        else // From other vertices we can only move to center
                        {
                            if (canMoveArray[0])
                            {
                                lock (SetNew)
                                {
                                    aAddNewState(state, i, 0);
                                }

                            }
                        }
                    }
                    canMoveArray[state[i]] = false;
                }
                // The second biggest:
                if (state[NumDiscs - 2] == 0 && state[NumDiscs - 1] == 0)
                {
                    if (canMoveArray[0] && canMoveArray[2])
                    {
                        lock (SetNew)
                        {
                            aAddNewState(state, NumDiscs - 2, 2);
                        }
                    }
                    if (canMoveArray[0] && canMoveArray[3])
                    {
                        lock (SetNew)
                        {
                            aAddNewState(state, NumDiscs - 2, 3);
                        }
                    }
                    canMoveArray[0] = false;
                }
                else if (state[NumDiscs - 2] == 0 && state[NumDiscs - 1] == 1)
                {
                    if (canMoveArray[0] && canMoveArray[1])
                    {
                        lock (SetNew)
                        {
                            aAddNewState(state, NumDiscs - 2, 1);
                        }

                    }
                    canMoveArray[0] = false;
                }
                else if (state[NumDiscs - 2] > 1 && state[NumDiscs - 1] == 1)
                {
                    if (canMoveArray[state[NumDiscs - 2]] && canMoveArray[0])
                    {
                        lock (SetNew)
                        {
                            aAddNewState(state, NumDiscs - 2, 0);
                        }

                    }
                    canMoveArray[state[NumDiscs - 2]] = false;
                }
                // Biggest disk is moved only once
                if (state[NumDiscs - 1] == 0)
                {
                    if (canMoveArray[0] && canMoveArray[1])
                    {
                        IsMoved = true;

                        lock (SetNew)
                        {
                            aAddNewState(state, NumDiscs - 1, 1);
                        }

                    }
                }
             
            }
            if (IsMoved)  
            {

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

                                    lock (SetNew)
                                    {
                                        aAddNewState(state, i, j);
                                    }

                                }
                            }
                        }
                        else // From other vertices we can only move to center
                        {
                            if (canMoveArray[0])
                            {
                                lock (SetNew)
                                {
                                    aAddNewState(state, i, 0);
                                }

                            }
                        }
                    }
                    canMoveArray[state[i]] = false;
                }
                                
            }
            void aAddNewState(byte[] state, int disc, byte toPeg)
            {
                byte[] newState;
                newState = new byte[state.Length];
                for (int x = 0; x < state.Length; x++)
                    newState[x] = state[x];
                newState[disc] = toPeg;
                CurrentState = StateToLong(newState);
                if (!SetPrev.Contains(CurrentState))
                {
                    lock (SetNew)
                    {
                        SetNew.Enqueue(CurrentState);
                    }

                }

            }

        }

    }
}

