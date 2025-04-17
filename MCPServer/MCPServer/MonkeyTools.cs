using System;
using System.ComponentModel;
using System.Text.Json;
using ModelContextProtocol.Server;

namespace MCPServer
{
    [McpServerToolType]
    public class MonkeyTools 
    {
        [McpServerTool, Description("Get a List of monekeys")]
        public static async Task<string> GetMonkeyList(MonkeyService monkeyService)
        {
            var monkeys = await monkeyService.GetMonkeys();
            return JsonSerializer.Serialize(monkeys);
        }
    
        [McpServerTool, Description("Get a monkey by name.")]
        public static async Task<string?> GetMonkeyName(MonkeyService monkeyService, string name)
        {
            var monkey = await monkeyService.GetMonkey(name);
            return monkey != null ? JsonSerializer.Serialize(monkey) : null;
        }

    }
}