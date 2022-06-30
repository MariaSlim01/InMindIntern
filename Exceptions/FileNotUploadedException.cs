namespace WebApplication1.Exceptions;

public class FileNotUploadedException:Exception
{
    public string errorMessage { get; set; } = "No file uploaded";
}