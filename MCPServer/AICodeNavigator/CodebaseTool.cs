using System;
using System.ComponentModel;
using System.Text.Json;
using ModelContextProtocol.Server;

namespace AICodeNavigator
{
    [McpServerToolType]
    public class CodebaseTools
    {
        [McpServerTool, Description("Search C# files for a specific function, class, or keyword.")]
        public static async Task<string> SearchCodebase(CodeSearchService codeSearchService, string keyword)
        {
            var results = await codeSearchService.Search(keyword);
            return JsonSerializer.Serialize(results);
        }

        [McpServerTool, Description("Read and return the content of a specific file.")]
        public static async Task<string?> ReadFile(CodeSearchService codeSearchService, string filePath)
        {
            var content = await codeSearchService.ReadFile(filePath);
            return content;
        }

        [McpServerTool, Description("Summarize the content of a C# file.")]
        public static async Task<string?> SummarizeFile(CodeSearchService codeSearchService, string filePath)
        {
            var summary = await codeSearchService.SummarizeFile(filePath);
            return summary;
        }
    }
}