using System.Collections.Generic;

namespace Hanoi.HanoiClasses
{
    interface ITowerOfHanoi
    {
        void AddNewState(byte[] state, int disc, byte toPeg);
        long StateToLong(byte[] state);
        long FinalStateReturn();
        byte[] LongToState(long num);
        long StateAllEqual(int pegNumber);
        byte[] ArrayAllEqual(byte pegNumber);
        void ResetArray(bool[] array);
    }

    abstract class Tower : ITowerOfHanoi
    {
        protected int NumDiscs { get; }
        protected byte NumPegs { get; }
        protected byte StartPeg { get; }
        protected byte FinalPeg { get; }
        public byte[] StartArray { get; protected set; }
        public long FinalState { get; protected set; }

        public bool IsMoved = false;
       
        public long CurrentState { get; protected set; }
        public short CurrentDistance { get; protected set; }
        protected long InitialState { get; set; }
        public long MaxCardinality { get; set; }
        public long MaxMemory { get; set; }

        public HashSet<long> SetPrev { get; set; }
        public HashSet<long> SetCurrent { get; set; }
        public HashSet<long> SetCurrent2 { get; set; }
        public Queue<long> SetNew { get; set; }

        public Tower(byte startPeg, byte finalPeg, int numDiscs)
        {
            this.NumDiscs = numDiscs;
            this.StartPeg = startPeg;
            this.FinalPeg = finalPeg;
            this.NumPegs = 4;

            SetPrev = new HashSet<long>();
            SetCurrent = new HashSet<long>();            
            SetNew = new Queue<long>();

            CurrentDistance = 0;
            MaxCardinality = 0;
            MaxMemory = 0;

            StartArray = ArrayAllEqual(StartPeg);
            FinalState = StateAllEqual(FinalPeg);
            InitialState = StateToLong(StartArray);
            SetCurrent.Add(InitialState);
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
        public long FinalStateReturn()
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
                num /= this.NumPegs;
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

        public byte[] ArrayAllEqual(byte pegNumber)
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
            byte [] newState = new byte[state.Length];
            for (int x = 0; x < state.Length; x++)
                newState[x] = state[x];
            newState[disc] = toPeg;
            CurrentState = StateToLong(newState);
            if (!SetPrev.Contains(CurrentState))
            {
                if (disc == NumDiscs - 1 && !IsMoved)
                {
                    IsMoved = true;
                }
                lock (SetNew)
                {
                    SetNew.Enqueue(CurrentState);
                }
                
            }
        }
        
        public void IncrementCurrentDistance()
        {
            this.CurrentDistance++;
        }

    }
   
}
