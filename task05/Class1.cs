using System;
using System.Reflection;
using System.Collections.Generic;
namespace task05;

public class ClassAnalyzer
{
    private Type _type;

    public ClassAnalyzer(Type type)
    {
        _type = type;
    }

    public IEnumerable<string> GetPublicMethods() {
        return _type.GetMethods().Where(m => m.IsPublic).Select(m => m.Name);
    }

    public IEnumerable<string> GetMethodParams(string methodname) {
        return _type.GetMethod(methodname).GetParameters().Select(m => m.Name);
    }

    public IEnumerable<string> GetAllFields() {
        return _type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static).Select(m => m.Name);
    }

    public IEnumerable<string> GetProperties() {
        return _type.GetProperties().Select(m => m.Name);
    }

    public bool HasAttribute<T>() where T : Attribute {
        return _type.GetCustomAttributes<T>().Any();
    }    

}
