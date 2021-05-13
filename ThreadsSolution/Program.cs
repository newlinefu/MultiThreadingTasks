using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsSolution
{
    class Program
    {
        private static int result = 1;
        static void Main(string[] args)
        {
            
            Task[] workers =
            {
                new Task(() => RepeatTask(() => Interlocked.Increment(ref result), 100)),
                new Task(() => RepeatTask(() => Interlocked.Decrement(ref result), 100))
            };
            
            foreach (var w in workers)
            {
                w.Start();
            }
            
            Task.Factory.ContinueWhenAny(
                workers,
                tsk => Console.WriteLine(result)
            );
            
            Thread.Sleep(10000);
        }

        private static void RepeatTask(Action taskBody, int count)
        {
            Task[] tasks = new Task[count];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new Task(taskBody);
                tasks[i].Start();
            }

            Task.WaitAll(tasks);
        }
    }
}