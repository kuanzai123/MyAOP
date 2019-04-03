using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyAOP.UtilityExtends
{
    public static class UtilityCheckExtends
    {
        public static Utility.Utility MustBeNotNull(this Utility.Utility utility, params object[] args)
        {
            return utility.Add((work) =>
            {
                for (int i = 0; i < args.Length; i++)
                {
                    object arg = args[i];
                    if (arg == null)
                    {
                        throw new ArgumentException(string.Format("Parameter at index {0} is null", i));
                    }
                }
                work();
            });
        }

        public static Utility.Utility MustBeNotDefault<T>(this Utility.Utility utility, params T[] args)
        {
            return utility.Add((work) =>
            {
                for (int i = 0; i < args.Length; i++)
                {
                    T arg = args[i];
                    if (arg == null || arg.Equals(default(T)))
                    {
                        throw new ArgumentException(string.Format("Parameter at index {0} is default", i));
                    }
                }
                work();
            });
        }
    }
}
