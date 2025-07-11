using CommandLib;

namespace FileSystemCommands;

public class DirectorySizeCommand : ICommand
{
    public string DirectoryPath;
    public long Size;

    public DirectorySizeCommand(string directoryPath) {
        this.DirectoryPath = directoryPath;
    }

    public void Execute() {
        var dirs = new DirectoryInfo(DirectoryPath);

        long resultSize = DirectSize(dirs);
        this.Size = resultSize;
    }

    public long DirectSize(DirectoryInfo dires) {

        long result = 0;

        DirectoryInfo[] dirs= dires.GetDirectories();
        FileInfo[] files = dires.GetFiles();

        foreach (var file in files )
        {
            result += file.Length;
        }

        foreach (var dir in dirs) {
            result += DirectSize(dir);
        }

        return result;
    }
}

public class FindFilesCommand : ICommand
{
    public string path;
    public string mask;
    public string[]? foundFiles;

    public FindFilesCommand(string path, string mask) {
        this.path = path;
        this.mask = mask;
    }

    public void Execute() {
        string[] files = Directory.GetFiles(path, mask);
        this.foundFiles = files;
    }
}