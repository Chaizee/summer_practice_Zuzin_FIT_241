using System;
using System.Reflection;
using task07;
class Program {
static void Main() {
    Assembly assembly = Assembly.LoadFrom("../task07/bin/Debug/net8.0/task07.dll");

    foreach (Type type in assembly.GetTypes()) 
    {
        if (!type.IsClass || type.Namespace != "task07" || type.Name.StartsWith("<>"))
            continue;

        Console.WriteLine($"Класс: {type.Name}");
        Console.WriteLine(" Методы:");
        
        var mets = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(m => !m.IsSpecialName && m.DeclaringType == type);
        foreach (var met in mets) 
        {
            var parametrs = met.GetParameters();
            Console.WriteLine($"  {met.Name}");
            Console.WriteLine("   Параметры: ");
            foreach (var p in parametrs) 
            {
            Console.WriteLine($"    {p.Name}: {p.ParameterType.Name}");
            }
        }

        Console.WriteLine("Атрибуты: ");
        var attributes = type.GetCustomAttributes<DisplayNameAttribute>();
        foreach (var attribute in attributes) {
            Console.WriteLine("  " + attribute);
        }

        Console.WriteLine("Конструкторы: ");
        var constructrs = type.GetConstructors();
        foreach (var constr in constructrs) {
            var parametrs = constr.GetParameters();
            Console.WriteLine($" {constr.Name}");
            Console.WriteLine("  Параметры: ");
            foreach (var par in parametrs) {
                Console.WriteLine($"   {par.Name}");
            }
        }
    }
}
}
