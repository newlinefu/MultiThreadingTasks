using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ThreadsSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            UserManager um = new UserManager();
            var users = um.InitializeAll(150);

            List<User> firstPart = users.Take(50).ToList();
            List<User> secondPart = users.Skip(50).Take(50).ToList();
            List<User> thirdPart = users.Skip(100).Take(50).ToList();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            
            um.DoWork(firstPart);
            Console.WriteLine(sw.Elapsed);
            
            sw.Reset();
            sw.Start();
            
            um.DoWork(secondPart);
            Console.WriteLine(sw.Elapsed);
            
            sw.Reset();
            sw.Start();
            
            um.DoWork(thirdPart);
            Console.WriteLine(sw.Elapsed);
            
            sw.Reset();
        }
    }
}