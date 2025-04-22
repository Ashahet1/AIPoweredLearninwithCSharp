using System.Text;
using System.Text.RegularExpressions;

namespace AICodeNavigator;

public class CodeSearchService
{
    private readonly string rootDirectory;

    public CodeSearchService(string rootDirectory)
    {
        this.rootDirectory = rootDirectory;
    }

    public async Task<List<CodeSearchResult>> Search(string keyword)
    {
        var results = new List<CodeSearchResult>();
        var files = Directory.EnumerateFiles(rootDirectory, "*.cs", SearchOption.AllDirectories);

        foreach (var file in files)
        {
            var lines = await File.ReadAllLinesAsync(file);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(new CodeSearchResult
                    {
                        FilePath = file,
                        LineNumber = i + 1,
                        LineContent = lines[i].Trim()
                    });
                }
            }
        }

        return results;
    }

    public async Task<string> ReadFile(string filePath)
    {
        if (!File.Exists(filePath))
            return $"File not found: {filePath}";

        return await File.ReadAllTextAsync(filePath);
    }

    public async Task<string> SummarizeFile(string filePath)
    {
        if (!File.Exists(filePath))
            return $"File not found: {filePath}";

        var lines = await File.ReadAllLinesAsync(filePath);
        int count = Math.Min(10, lines.Length); // just return top 10 lines as a mock "summary"
        var summary = string.Join(Environment.NewLine, lines.Take(count));
        return $"Summary of {Path.GetFileName(filePath)}:\n\n{summary}";
    }
}

public class CodeSearchResult
{
    public string FilePath { get; set; } = "";
    public int LineNumber { get; set; }
    public string LineContent { get; set; } = "";
}
