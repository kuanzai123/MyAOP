using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyAOP.UtilityExtends
{
    public static class UtilityThread
    {
        public static Utility.Utility ThreadStart(this Utility.Utility utility)
        {
            return utility.Add((work) =>
            {
                Thread thread = new Thread(() =>
                {
                    work();
                });
                thread.Start();
            });
        }

        public static Utility.Utility ThreadPoolStart(this Utility.Utility utility)
        {
            return utility.Add((work) =>
            {
                ThreadPool.QueueUserWorkItem(delegate
                {
                    work();
                });
            });
        }
    }
}
