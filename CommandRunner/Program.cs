using System.IO;
using System.Reflection;
using CommandLib;

static void Main(string[] args) {

    string path = Path.Combain($"{Directory.GetCurrentDirectory()}", "TestDir");

    Assambly assambly = Assambly.LoadFrom("../FileSystemCommands/bin/Debug/net8.0/FileSystemCommands.dll"); 

    var DirectSizeType = assambly.GetType("FileSystemComands.DirectorySizeCommand");
    var DirectSizeInstance = (ICommand)Activator.CreateInstance(DirectSizeTypeype, path);
    DirectSizeInstance.Execute();

    var FindFilesType = assambly.GetType("FileSystemComands.FindFilesCommand");
    var FindFilesInstance = (ICommand)Activator.CreateInstance(FindFilesType, path);
    FindFilesInstance.Execute();

}