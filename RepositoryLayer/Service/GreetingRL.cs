using RepositoryLayer.Interface;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;

namespace RepositoryLayer
{
    public class GreetingRL : IGreetingRL
    {
        private readonly GreetingContext _context;

        public GreetingRL(GreetingContext context)
        {
            _context = context;
        }

        public void SaveGreeting(GreetingEntity greeting)
        {
            _context.Greeting.Add(greeting);
            _context.SaveChanges();  // 
            Console.WriteLine($"Greeting Saved: {greeting.Message}");
        }

        
    }
}
