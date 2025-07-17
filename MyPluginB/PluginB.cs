using PluginContracts;

[PluginLoad]

public class MyPluginB : IPlugin
{
    public void Execute()
    {
        Console.WriteLine("Выполняется MyPluginB");
    }
}