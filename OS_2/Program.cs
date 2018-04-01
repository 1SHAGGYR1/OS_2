using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OS_2
{
    class Program
    {
        static bool thread1 = true, thread2 = true;
        static Semaphore sem = new Semaphore(1,1);
        static void One()
        {
            while (thread1)
            {
                sem.WaitOne();
                for (int i = 0; i < 5; i++)
                    Console.Write('1');
                Thread.Sleep(200);
                sem.Release();
            }
        }
        static void Two()
        {
            while (thread2)
            {
                sem.WaitOne();
                for (int i = 0; i < 5; i++)
                    Console.Write('2');
                Thread.Sleep(200);
                sem.Release();
            }                
        }
        static void Main(string[] args)
        {
            Thread firstthread = new Thread(One);
            firstthread.Start();
            Thread secondthread = new Thread(Two);
            secondthread.Start();
            Console.ReadKey();
            thread1 = thread2 = false;
            Console.WriteLine("Threads had stopped.");
            Console.ReadKey();
        }
    }
}
