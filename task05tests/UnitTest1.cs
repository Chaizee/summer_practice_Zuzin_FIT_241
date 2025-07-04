using Xunit;
using System;
using task05;
namespace task05tests;

public class TestClass
{
    public int PublicField;
    private string _privateField;
    public int Property { get; set; }

    public void Method() { }
}

[Serializable]
public class AttributedClass { }

public class ClassAnalyzerTests
{
    [Fact]
    public void GetPublicMethods_ReturnsCorrectMethods()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var methods = analyzer.GetPublicMethods();

        Assert.Contains("Method", methods);
    }

    [Fact]
    public void GetAllFields_IncludesPrivateFields()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var fields = analyzer.GetAllFields();

        Assert.Contains("_privateField", fields);
    }

    [Fact]
    public void GetMathodParams_ReturnsCorrectParams() {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var param = analyzer.GetMethodParams(nameof(TestClass.Method));

        Assert.Empty(param);
    }

    [Fact]
    public void GetProperties_ReturnsCorrectProps() {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var props = analyzer.GetProperties();

        Assert.Contains("Property", props);
    }
    
    [Fact]
    public void HasAttribute_ReturnsCorrectAttributes(){
        var analyzer = new ClassAnalyzer(typeof(AttributedClass));
        var attribute = analyzer.HasAttribute<SerializableAttribute>();

        Assert.True(attribute);
    }
}
