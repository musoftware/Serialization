using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            SerializationClass cc = new SerializationClass();

            for (int i = 0; i < 100; i++)
            {
                var ii = i;
                cc.AddProcess(() =>
                {
                    Console.WriteLine(ii + " Action");
                    if (ii % 10 == 0) throw new Exception("error " + ii);
                    Thread.Sleep(10);
                });
                cc.Run();
            }
            cc.Run();

            Console.ReadLine();
        }
    }
}
