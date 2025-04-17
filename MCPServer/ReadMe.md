# 🐒 MonkeyMCP – A C# Model Context Protocol Server

MonkeyMCP is a C# implementation of a Model Context Protocol (MCP) server that provides structured access to monkey-related data. It integrates seamlessly with tools like GitHub Copilot Agent Mode, enabling AI assistants to interact with external data sources and tools.

## 🚀 What is MCP?

The Model Context Protocol (MCP) is an open standard developed by Anthropic to facilitate communication between AI assistants and external tools, systems, and data sources. It allows AI models to execute functions, access data, and handle contextual prompts in a standardized manner. [Learn more about MCP](https://modelcontextprotocol.io/introduction).

## 🧰 Features

- **Monkey Data Access**: Retrieve information about various monkey species, including names, locations, and other details.
- **MCP Tools**: Expose functionalities like `GetMonkeys` and `GetMonkey` as MCP tools for AI assistants to invoke.
- **Integration with AI Assistants**: Designed to work with tools like GitHub Copilot Agent Mode, allowing for natural language interactions.

## 🛠️ Getting Started

### Prerequisites

- .NET 9.0 SDK or later
- Visual Studio Code with GitHub Copilot extension

### Running the Server

1. **Clone the Repository**:
```bash
git clone https://github.com/yourusername/MonkeyMCP.git
cd MonkeyMCP
```

2. **Build the Project**:
```bash
dotnet build
```

3. **Run the Server**:
```bash
dotnet run --project MonkeyMCP
```

### Configuring in VS Code

To integrate with GitHub Copilot Agent Mode, add the following configuration to your `mcp.json` file:

```json
{
"inputs": [],
"servers": {
"MonkeyMCP": {
"type": "stdio",
"command": "dotnet",
"args": [
"run",
"--project",
"path/to/MonkeyMCP.csproj"
]
}
}
}
```

Replace `"path/to/MonkeyMCP.csproj"` with the actual path to your project file.

## 🧪 Available MCP Tools

- **GetMonkeys**: Returns a list of all available monkeys in JSON format.
- **GetMonkey**: Retrieves detailed information about a specific monkey by name.

## 📺 Visual Studio Code Agent Mode

GitHub Copilot's Agent Mode allows AI assistants to perform multi-step coding tasks autonomously. By integrating MonkeyMCP, you can enable AI-driven interactions with your monkey data. Learn more about Agent Mode here:

[VS Code Agent Mode Just Changed Everything](https://www.youtube.com/watch?v=gwDZNSQjbwk)

## 📚 Learn More

- **MCP Overview**: https://modelcontextprotocol.io/
- **Build a Model Context Protocol (MCP) server in C#**: https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/

## 📝 License

This project is licensed under the MIT License.
