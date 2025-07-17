using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using PluginContracts;

namespace PluginLoader
{
    public class PluginManager
    {
        private readonly Dictionary<string, Type> _pluginTypes = new();
        private readonly Dictionary<string, string[]> _dependencies = new();

        public void LoadPlugins(string folderPath)
        {
            var files = Directory.GetFiles(folderPath, "*.dll");

            foreach (var file in files)
            {
                try
                {
                    var assembly = Assembly.LoadFrom(file);

                    foreach (var type in assembly.GetTypes())
                    {
                        var attr = (PluginLoadAttribute)Attribute.GetCustomAttribute(
                            type,
                            typeof(PluginLoadAttribute));

                        if (attr != null && typeof(IPlugin).IsAssignableFrom(type))
                        {
                            var pluginName = type.FullName;
                            _pluginTypes[pluginName] = type;
                            _dependencies[pluginName] = attr.Dependencies;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при загрузке {file}: {ex.Message}");
                }
            }
        }

        public void ExecutePluginsInOrder()
        {
            var sortedPlugins = TopologicalSort(_dependencies);
            foreach (var pluginName in sortedPlugins)
            {
                try
                {
                    var type = _pluginTypes[pluginName];
                    var plugin = (IPlugin)Activator.CreateInstance(type);
                    plugin.Execute();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при выполнении {pluginName}: {ex.Message}");
                }
            }
        }

        private List<string> TopologicalSort(Dictionary<string, string[]> dependencies)
        {
            var result = new List<string>();
            var visited = new HashSet<string>();
            var visiting = new HashSet<string>();

            foreach (var node in dependencies.Keys.ToList())
            {
                Visit(node, dependencies, visited, visiting, result);
            }

            return result;
        }

        private void Visit(
            string node,
            Dictionary<string, string[]> dependencies,
            HashSet<string> visited,
            HashSet<string> visiting,
            List<string> result)
        {
            if (visiting.Contains(node))
                throw new InvalidOperationException("Циклическая зависимость в плагинах.");

            if (visited.Contains(node)) return;

            visiting.Add(node);

            if (dependencies.TryGetValue(node, out var deps))
            {
                foreach (var dep in deps)
                {
                    Visit(dep, dependencies, visited, visiting, result);
                }
            }

            visiting.Remove(node);
            visited.Add(node);
            result.Add(node);
        }
    }
}