using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi.HanoiClasses
{
    class K13_01FAST : Tower
    {
        public K13_01FAST(byte startPeg, byte endPeg, int numDiscs) : base(startPeg, endPeg, numDiscs)
        {
            startArray = ArrayAllEqual(StartPeg);
            finalState = FinalState();

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
            bool[] canMoveArray = new bool[this.NumPegs];
            ResetArray(canMoveArray);
            byte[] newState;

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
                                lock(setNew){
                                    aAddNewState(state, i, j);
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
                    lock(setNew)
                    {
                        aAddNewState(state, NumDiscs - 2, 2);
                    }
                }
                if (canMoveArray[0] && canMoveArray[3])
                {
                    lock (setNew)
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
                    lock(setNew)
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
                    lock(setNew)
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
                    lock (setNew)
                    {
                        aAddNewState(state, NumDiscs - 1, 1);
                    }
                    
                    //Console.WriteLine("The biggest is moved!\n");
                }
            }

            void aAddNewState(byte[] state, int disc, byte toPeg)
            {
                newState = new byte[state.Length];
                for (int x = 0; x < state.Length; x++)
                    newState[x] = state[x];
                newState[disc] = toPeg;
                currentState = StateToLong(newState);
                if (!setPrev.Contains(currentState) && !setIgnore.Contains(currentState))
                {
                    
                    
                        setNew.Enqueue(currentState);
                    

                }
               
                
            }

            


        }

      
    }
}

