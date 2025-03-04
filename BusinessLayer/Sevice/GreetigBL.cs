using BusinessLayer.Interface;

namespace BusinessLayer.Service
{
    public class GreetingBL : IGreetingBL
    {
        public string GetGreeting(string? firstName, string? lastName)
        {
            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
                return $"Hello, {firstName} {lastName}!";

            if (!string.IsNullOrWhiteSpace(firstName))
                return $"Hello, {firstName}!";

            if (!string.IsNullOrWhiteSpace(lastName))
                return $"Hello, Mr./Ms. {lastName}!";

            return "Hello, World!";
        }
    }
}
