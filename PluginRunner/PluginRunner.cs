using System;
using PluginLoader;

class Program
{
    static void Main(string[] args)
    {
        var manager = new PluginManager();
        var pluginsFolder = Path.Combine(AppContext.BaseDirectory, "Plugins");

        Console.WriteLine($"Ищем плагины в: {pluginsFolder}");

        manager.LoadPlugins(pluginsFolder);
        manager.ExecutePluginsInOrder();
    }
}