﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadsSolution
{
    public class UserManager
    {
        public UserManager()
        {
        }

        public List<User> InitializeAll(int size = 1500)
        {
            List<User> users = new List<User>();
            
            for (int i = 0; i < size; i++)
            {
                users.Add(new User($"User {i}"));
            }

            return users;
        }
        
        public void DoWork(List<User> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
                Thread.Sleep(10);
            }
        }
    }
}