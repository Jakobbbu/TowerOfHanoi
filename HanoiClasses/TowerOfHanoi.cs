using System;
using System.Collections.Generic;
using System.Text;

namespace HanoiFinal.HanoiClasses
{
    interface TowerOfHanoi
    {
        void AddNewState(byte[] state, int disc, byte toPeg);
        long StateToLong(byte[] state);
        long FinalState();
        byte[] LongToState(long num);
        long StateAllEqual(int pegNumber);
        byte[] ArrayAllEqual(byte pegNumber);
        void ResetArray(bool[] array);
    }

    abstract class Tower : TowerOfHanoi
    {
        protected int NumDiscs { get; }
        protected byte NumPegs { get; }
        protected byte StartPeg { get; }
        protected byte FinalPeg { get; }
        public byte[] startArray { get; protected set; }
        public long finalState { get; protected set; }
        //public byte[] newState { get; protected set; }
        public long currentState { get; protected set; }
        public short currentDistance { get; protected set; }
        protected long initialState { get; set; }
        public long maxCardinality { get; set; }
        public long maxMemory { get; set; }

        public HashSet<long> setIgnore { get; set; }
        public HashSet<long> setPrev { get; set; }
        public HashSet<long> setCurrent { get; set; } 
        public Queue<long> setNew { get; set; }

        public Tower(byte startPeg, byte finalPeg, int numDiscs)
        {
            this.NumDiscs = numDiscs;
            this.StartPeg = startPeg;
            this.FinalPeg = finalPeg;
            this.NumPegs = 4;
        }
        
      
        public abstract void MakeMoveForSmallDimension(byte[] state);

        
        public long StateToLong(byte[] state)
        {
            long num = 0;
            long factor = 1;
            for (int i = state.Length - 1; i >= 0; i--)
            {
                num += state[i] * factor;
                factor *= this.NumPegs;
            }
            return num;
        }
        public long FinalState()
        {
            long num = 0;
            long factor = 1;
            for (int i = NumDiscs - 1; i >= 0; i--)
            {
                num += factor;
                factor *= this.NumPegs;
            }
            return num;
        }
        public byte[] LongToState(long num)
        {
            byte[] tmpState = new byte[this.NumDiscs];
            for (int i = NumDiscs - 1; i >= 0; i--)
            {
                tmpState[i] = (byte)(num % this.NumPegs);
                num = num / this.NumPegs;
            }
            return tmpState;
        }

        public long StateAllEqual(int pegNumber)
        {
            long num = 0;
            long factor = 1;
            for (int i = NumDiscs - 1; i >= 0; i--)
            {
                num += pegNumber * factor;
                factor *= this.NumPegs;
            }
            return num;
        }

        public byte[] ArrayAllEqual(byte pegNumber)//na zacetku
        {
            byte[] arr = new byte[this.NumDiscs];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = pegNumber;
            return arr;
        }

        public void ResetArray(bool[] array)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = true;
        }

        public void AddNewState(byte[] state, int disc, byte toPeg)
        {
            byte[] newState = new byte[state.Length];
            for (int x = 0; x < state.Length; x++)
                newState[x] = state[x];
            newState[disc] = toPeg;
            currentState = StateToLong(newState);
            if (!setPrev.Contains(currentState) && !setIgnore.Contains(currentState))
            {
                setNew.Enqueue(currentState);
            }
        }

        public void incrementCurrentDistance()
        {
            this.currentDistance++;
        }

    }
   
}
