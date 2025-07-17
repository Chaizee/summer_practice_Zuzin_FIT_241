using PluginContracts;

[PluginLoad("MyPluginB")]

public class MyPluginA : IPlugin
{
    public void Execute()
    {
        Console.WriteLine("Выполняется MyPluginA");
    }
}