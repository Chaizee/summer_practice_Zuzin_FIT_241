using System.Linq;
using System.Reflection;
namespace task07;

public class DisplayNameAttribute : Attribute {
    public string DisplayName = "";

    public DisplayNameAttribute(string displayName) {
        DisplayName = displayName;
    }
}

public class VersionAttribute : Attribute {
    public int Major, Minor;

    public VersionAttribute(string classVersion) {
        string[] versMus = classVersion.Split('.');
        Major = Convert.ToInt32(versMus[0]);
        Minor = Convert.ToInt32(versMus[1]);
    }
}

[DisplayName("Пример класса")]
[Version("1.0")]
public class SampleClass {
    [DisplayName("Числовое свойство")]
    public int Number { get; }

    [DisplayName("Тестовый метод")]
    public void TestMethod() { }
}

public class ReflectionHelper {
    public void PrintTypeInfo(Type type) {
        var displayAttribute = type.GetCustomAttribute<DisplayNameAttribute>();
        var versionAttribute = type.GetCustomAttribute<VersionAttribute>();

        if (displayAttribute != null) {
            Console.WriteLine(displayAttribute.DisplayName);
        }
        if (versionAttribute != null) {
            Console.Write(versionAttribute.Major + "." + versionAttribute.Minor);
        }

        var getMethods = type
            .GetMethods()
            .Where(m => m.GetCustomAttributes<DisplayNameAttribute>().Any())
            .Select(m => m.Name);
        
        foreach (var getMethod in getMethods) {
            Console.WriteLine(getMethod);
        }

        var getPropertys = type
            .GetProperties()
            .Where(m => m.GetCustomAttributes<DisplayNameAttribute>().Any())
            .Select(m => m.Name);
        
        foreach(var getProperty in getPropertys) {
            Console.WriteLine(getProperty);
        }
    }


    
}
