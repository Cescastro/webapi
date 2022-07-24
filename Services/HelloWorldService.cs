public class HelloWorldService : IHelloWorldService
{
    public string GetHelloWorld()
    {
        return "Hello";
    }

    public string GetAnotherHello()
    {
       return "Other"; 
    }
}

public interface IHelloWorldService
{
    string GetHelloWorld();
}