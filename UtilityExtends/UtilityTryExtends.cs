using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyAOP.UtilityExtends
{
    public static class UtilityTryExtends
    {
        public static Utility.Utility Try(this Utility.Utility utility, Action<Exception> onError = null)
        {
            return utility.Add((work) =>
            {
                try
                {
                    work();
                }
                catch (Exception ex)
                {
                    if (onError != null)
                    {
                        onError(ex);
                    }
                }
            });
        }
        public static void Try(this Utility.Utility utility, Action work, Action<Exception> onError = null)
        {
            try
            {
                if (utility.Next == null)
                {
                    work();
                }
                else
                {
                    utility.Next(work);
                }
            }
            catch (Exception ex)
            {
                if (onError != null)
                {
                    onError(ex);
                }
            }
        }
        public static TReturnType TryReturn<TReturnType>(this Utility.Utility utility, Func<TReturnType> work, TReturnType ErrorReturnValue = default(TReturnType), Action<Exception> onError = null)
        {
            try
            {
                utility.WorkDelegate = work;

                if (utility.Next == null)
                {
                    return work();
                }
                else
                {
                    TReturnType returnValue = default(TReturnType);
                    utility.Next(() =>
                    {
                        Func<TReturnType> workDelegate = utility.WorkDelegate as Func<TReturnType>;
                        returnValue = workDelegate();
                    });
                    return returnValue;
                }
            }
            catch (Exception ex)
            {
                if (onError != null)
                {
                    onError(ex);
                }
                
                return ErrorReturnValue;
            }
        }
    }
}
