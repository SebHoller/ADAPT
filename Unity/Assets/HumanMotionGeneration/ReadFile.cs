public class ReadFile
{
    public static string[] ReadLines(string path)
    {
        return System.IO.File.ReadAllLines(path);
    }
}
