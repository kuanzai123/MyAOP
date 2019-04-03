using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyAOP.UtilityExtends;

namespace MyAOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Code1();
            Code2();
            //核心代码
            //Action<Action> action;
            //action = (work) => { Console.WriteLine("Action1 Start"); work(); Console.WriteLine("Action1 End"); };
            //Action<Action> existingChain = action;
            ////action = (work) => { Console.WriteLine("Action2 Start"); existingChain(work); Console.WriteLine("Action2 End"); };
            //action = (work) =>
            //{
            //    existingChain(() =>
            //    {
            //        Console.WriteLine("Action2 Start"); 
            //        work(); 
            //        Console.WriteLine("Action2 End");
            //    });
            //};
            //action(() => { Console.WriteLine("Working"); });
            Console.Read();
        }

        static void Code1()
        {
            string input1 = null;
            string input2 = "InputString";

            try
            {
                Console.WriteLine("Start");
                if (input1 == null || input2 == null)
                {
                    throw new ArgumentException("Parameter is null");
                }

                Console.WriteLine(input1 + input2);

                Console.WriteLine("End");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Code2()
        {
            string input1 = null;
            string input2 = "InputString";

            Utility.Utility.Entity.Try(onError)
                .Log(null, "Start", "End")
                .MustBeNotNull(input1)
                .Do(() =>
                {
                    Console.WriteLine(input1 + input2);
                });
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="ex"></param>
        static void onError(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
