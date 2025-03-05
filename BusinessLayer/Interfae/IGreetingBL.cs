namespace BusinessLayer.Interface
{
    public interface IGreetingBL
    {
        string GetGreeting(string? firstName, string? lastName);
        void SaveGreeting(string message);

      //  List<string> GetAllGreetings();
    }
}
