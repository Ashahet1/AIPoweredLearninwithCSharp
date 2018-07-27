using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Data;


namespace MyMultiThreadingProgram1.cs
{
    class Program
    {
        static void Main(string[] args)
        {

            //creating more than one Thread
            Thread T1 = new Thread(FirstFunc);
            Thread T2 = new Thread(SecFunc);
        //    Thread T3 = new Thread(Thirdfunc);
            Thread T3 = new Thread(ThiFunc);

            //Starting Console
            Console.WriteLine("Threading Starting:");
            T1.Start();
            T2.Start();
            T3.Start();

        }

        public static void FirstFunc()
        {
            for (int num = 0; num <= 15; num++) 
            {
                Console.WriteLine("FirstFunc:" + num);
                Thread.Sleep(100);
               
            }
            Console.WriteLine("Thread has exited F1:");
        }

        public static void SecFunc()
        {
            for (int num = 0; num <= 15; num++) 
            {
                Console.WriteLine("SecFunc:" + num);
                if (num == 10)
                {
                    Console.WriteLine("Function 2 is sleeping:");
                    Thread.Sleep(2000);
                    Console.WriteLine("Function 2 has woke up:");
                }
            }
        }

        public static void ThiFunc()
        {
            for (int num = 0; num <= 15; num++) 
            {
                Console.WriteLine("ThirdFunc:" + num);
                Thread.Sleep(500);
             //   Console.WriteLine("thread has exited f3");
            }
            Console.WriteLine("thread has exited f3"); 
            Console.ReadKey();
        }

        
    }
}