using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            SerializationClass cc = new SerializationClass();

            cc.AddProcess(() =>
            {
                Console.WriteLine("1 Action");
                Thread.Sleep(1000);
            });
            cc.Run();
            cc.AddProcess(() =>
            {
                Console.WriteLine("2 Action");
                Thread.Sleep(1000);
            });
            cc.Run();
            cc.AddProcess(() =>
            {
                Console.WriteLine("3 Action");
                Thread.Sleep(1000);
            });

            cc.Run();

            Console.ReadLine();
        }
    }
}
