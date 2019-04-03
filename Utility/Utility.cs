using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyAOP.Utility
{
    public class Utility
    {
        internal Action<Action> Next = null;
        internal Delegate WorkDelegate;

        public static Utility Entity 
        {
            get { return new Utility(); }
        }

        public void Do(Action work)
        {
            if (this.Next == null)
            {
                work();
            }
            else
            {
                this.Next(work);
            }
        }


        public TReturnType Return<TReturnType>(Func<TReturnType> work)
        {
            //this.WorkDelegate = work;

            if (this.Next == null)
            {
                return work();
            }
            else
            {
                TReturnType returnValue = default(TReturnType);
                this.Next(() =>
                {
                    //Func<TReturnType> workDelegate = WorkDelegate as Func<TReturnType>;
                    returnValue = work();
                });
                return returnValue;
            }
        }


        public Utility Add(Action<Action> Delegate)
        {
            if (this.Next == null)
            {
                this.Next = Delegate;
            }
            else
            {
                Action<Action> existingChain = this.Next;
                Action<Action> callAnother = (work) =>
                    existingChain(() => Delegate(work));
                this.Next = callAnother;
            }
            return this;
        }
    }
}
