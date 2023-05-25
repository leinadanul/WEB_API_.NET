public class HelloworldService : IHelloWorldService

{

    public string GetHelloWorld()
    {
        return " hello world";
    }
}

public interface IHelloWorldService
{
    string GetHelloWorld();
}