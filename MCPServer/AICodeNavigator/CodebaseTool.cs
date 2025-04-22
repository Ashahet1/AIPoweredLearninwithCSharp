using McpDotNet.Server;
using System.ComponentModel;
using System.Text.Json;

namespace AICodeNavigator
{
    [McpToolType] // Fixed attribute usage to match the provided type signature  
    public class CodebaseTools
    {
        [McpTool, Description("Search C# files for a specific function, class, or keyword.")]
        public static async Task<string> SearchCodebase(CodeSearchService codeSearchService, string keyword)
        {
            var results = await codeSearchService.Search(keyword);
            return JsonSerializer.Serialize(results);
        }

        [McpTool, Description("Read and return the content of a specific file.")]
        public static async Task<string?> ReadFile(CodeSearchService codeSearchService, string filePath)
        {
            var content = await codeSearchService.ReadFile(filePath);
            return content;
        }

        [McpTool, Description("Summarize the content of a C# file.")]
        public static async Task<string?> SummarizeFile(CodeSearchService codeSearchService, string filePath)
        {
            var summary = await codeSearchService.SummarizeFile(filePath);
            return summary;
        }
    }
}