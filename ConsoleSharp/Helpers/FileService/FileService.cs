namespace ConsoleSharpTemplate.Helpers.FileService;

// This help to mock File class in tests
public class FileService : IFileService {
    public bool Exists(string path) => File.Exists(path);
}