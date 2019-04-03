using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MyAOP.UtilityExtends
{
    public static class UTilityLogExtends
    {
        public static Utility.Utility Log(this Utility.Utility utility, TextWriter logWriter = null, string beforeLogText = null, string afterLogText = null)
        {
            if (logWriter == null) logWriter = Console.Out;
            return utility.Add((work) =>
            {
                if (!string.IsNullOrEmpty(beforeLogText))
                {
                    logWriter.Write(DateTime.Now.ToUniversalTime().ToString());
                    logWriter.Write('\t');
                    logWriter.Write(beforeLogText);
                    logWriter.Write(Environment.NewLine);
                }

                work();

                if (!string.IsNullOrEmpty(afterLogText))
                {
                    logWriter.Write(DateTime.Now.ToUniversalTime().ToString());
                    logWriter.Write('\t');
                    logWriter.Write(afterLogText);
                    logWriter.Write(Environment.NewLine);
                }
            });  
        }
    }
}
