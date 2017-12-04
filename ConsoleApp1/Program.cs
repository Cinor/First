using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("----------------------輸入PID----------------------");
            //Console.Write("PID: ");
            //string PID = Console.ReadLine();
            //int proceID = int.Parse(PID);
            //EnumThreadsForPID(proceID);
            //Console.ReadLine();


            //Thread t = new Thread(Write1To50);
            //t.Start();
            //Thread.Sleep(1000);
            //Write50To100();


            //for (int i = 0; i < 10; i++)
            //{
            //    NewThread1to50(i);
            //}


            //Task<int> task = Task.Run(() =>
            //{
            //    Thread.Sleep(2000);
            //    Console.WriteLine("From.Task.");
            //    return 1;
            //});

            //int result = task.Result;
            //Console.WriteLine(result);

            //Task<int> task = Task.Run(() => Enumerable.Range(1,5000000).Count(n => (n%3) == 0));
            //Console.WriteLine("Task 執行中...");
            //Console.WriteLine("整除3的個數有:" + task.Result);

            //Console.WriteLine(task.IsCompleted);
            //task.Wait();
            //Console.WriteLine(task.IsCompleted);

            //Task<int> task = Task.Run(() => Enumerable.Range(1, 5000000).Count(n => (n % 3) == 0));
            //var awaiter = task.GetAwaiter();

            //awaiter.OnCompleted(() =>
            //{
            //    int result = awaiter.GetResult();
            //    Console.WriteLine("整除3的個數有:" + result);
            //});
            //task.ContinueWith(c =>
            //{
            //    int result = task.Result;
            //    Console.WriteLine("整除3的個數有:" + result);
            ////});
            //Console.WriteLine("Task 執行中...");

            //int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //Parallel.For(0, nums.Length, (i) =>
            //{
            //    Console.WriteLine("索引{0}:陣列{1}", i, nums[i]);
            //});

            List<int> nums2 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Parallel.ForEach(nums2, (i) =>
            {
                Console.WriteLine("集合元素{0}", i);
            });

            Console.ReadKey();
        }


        static void EnumThreadsForPID(int PID)
        {
            Process proc = null;
            try
            {
                proc = Process.GetProcessById(PID);
            }
            catch (ArgumentException Ex)
            {
                Console.WriteLine(Ex.Message);
                return;
            }

            Console.WriteLine("執行緒名稱: {0}", proc.ProcessName);
            ProcessThreadCollection threads = proc.Threads;
            foreach (ProcessThread pt in threads)
            {
                string info = string.Format("Thread ID: {0}\t" + "Start Time: {1}\t" + "Priority: {2}\t", pt.Id, pt.StartTime, pt.PriorityLevel);
                Console.WriteLine(info);

            }
            Console.WriteLine("----------------------");

        }

        static void Write1To50()
        {
            for (int i = 1; i <= 50; i++)
            {
                Console.Write(i + ",");
            }
        }

        static void Write50To100()
        {
            for (int i = 51; i <= 100; i++)
            {
                Console.Write(i + ",");
            }
        }


        private static void NewThread1to50(int i)
        {
            Thread t = new Thread(() =>
            {
                Console.WriteLine(string.Format("{0}:{1}", Thread.CurrentThread.Name, i));
            });
            t.Name = string.Format("執行緒{0}", i);
            t.IsBackground = true;
            t.Start();

        }
    }
}
