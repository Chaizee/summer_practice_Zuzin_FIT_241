using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.IO;
using System.Reflection;

namespace task11;

public interface ICalculator
{
    public int Add(int a, int b);
    public int Minus(int a, int b);
    public int Mul(int a, int b);
    public int Div(int a, int b);
}   

public class CalcBuilder {
    public static ICalculator CreateCalculator() {
        string calcCode = @"public class Calculator : task11.ICalculator 
        {
            public int Add(int a, int b) => a + b;
            public int Minus(int a, int b) => a - b;
            public int Mul(int a, int b) => a * b;
            public int Div(int a, int b) => a / b;
        }"  ;

        var references = new[]
        {
            MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(ICalculator).Assembly.Location)
        };

        var syntaxTree = CSharpSyntaxTree.ParseText(calcCode);

        var compilation = CSharpCompilation.Create("DinamicCalculator")
            .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
            .AddReferences(references)
            .AddSyntaxTrees(syntaxTree);

        using var stream = new MemoryStream();
        var result = compilation.Emit(stream);

        if (!result.Success) {
            Console.WriteLine("Ошибка компиляции");
        }

        var assembly = Assembly.Load(stream.ToArray());
        var type = assembly.GetType("Calculator");

        dynamic? instance = Activator.CreateInstance(type);

        if (instance != null) {
            return (ICalculator)instance;
        }
        throw new Exception("Не удалось создать экземпляр Calculator");
    }
}
