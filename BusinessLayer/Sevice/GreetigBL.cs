using BusinessLayer.Interface;
using RepositoryLayer.Interface;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Service
{
    public class GreetingBL : IGreetingBL
    {
        private readonly IGreetingRL _greetingRL;

        public GreetingBL(IGreetingRL greetingRL)
        {
            _greetingRL = greetingRL;
        }

        public string GetGreeting(string? firstName, string? lastName)
        {
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
                return $"Hello {firstName} {lastName}!";
            else if (!string.IsNullOrEmpty(firstName))
                return $"Hello {firstName}!";
            else if (!string.IsNullOrEmpty(lastName))
                return $"Hello {lastName}!";
            return "Hello World!";
        }

        public void SaveGreeting(string message)
        {
            _greetingRL.SaveGreeting(new GreetingEntity { Message = message });
        }

        //public List<string> GetAllGreetings()
        //{
        //    return _greetingRL.GetGreetings().ConvertAll(g => g.Message);
        //}
    }
}
