namespace ConsoleSharpTemplate.Helpers.FileService;

// This help to mock File class in tests
public interface IFileService {
    public bool Exists(string path);
}