# 🔍 AI Codebase Navigator (MCP + C#)

This project is a developer productivity tool built using the [Model Context Protocol (MCP)](https://modelcontextprotocol.dev), designed to let AI assistants interact with a local C# codebase through structured tools. It enables intelligent codebase exploration via search, file reading, and basic summarization — ideal for integrating with tools like **GitHub Copilot Agent Mode**.

---

## 🚀 Features

- 🔎 **SearchCodebase** — Locate keywords, function names, or class definitions across `.cs` files.
- 📂 **ReadFile** — View the full content of any file path within the codebase.
- 🧠 **SummarizeFile** — Get a high-level summary (first 10 lines) of any C# file.

---

## 🧠 Use Case

Ask an LLM agent:  
> _"Where is the `ConfigureServices` method defined?"_

The agent will:
1. Call `SearchCodebase` to locate the file and line.
2. Call `ReadFile` to show code content.
3. Optionally call `SummarizeFile` to preview the file.

Great for:
- Onboarding new developers
- Searching legacy codebases
- Boosting productivity in large C# projects

---

## 🧰 Tech Stack

| Component                  | Description                         |
|---------------------------|-------------------------------------|
| 🖥️ C# .NET                 | MCP Server backend                  |
| 📦 Model Context Protocol | Exposes structured tools to the AI  |
| 🤖 GitHub Copilot Agent Mode | Conversational interface         |

---

## 🏗️ Project Structure

```
/MCPServer
├── Program.cs               # Registers and runs MCP server
├── CodeSearchService.cs     # Core logic for search/read/summarize
├── CodebaseTools.cs         # MCP tool definitions
├── mcp.json                 # Agent Mode config
```

---

## ⚙️ Setup Instructions

### 1. Clone this repo

```bash
git clone https://github.com/Ashahet1/C-Project/tree/master/MCPServer/AICodeNavigator.git
cd AI-Codebase-Navigator
```

### 2. Set your root search path

Edit this line in `Program.cs`:

```csharp
string rootCodeDirectory = @"C:\Path\To\Your\Codebase";
```

### 3. Run the MCP Server

```bash
dotnet run --project MCPServer
```

---

## 🤖 MCP + Agent Mode Setup

Create a file named `mcp.json` in the project root:

```json
{
  "inputs": [],
  "servers": {
    "CodebaseNavigator": {
      "type": "stdio",
      "command": "dotnet",
      "args": [
        "run",
        "--project",
        "MCPServer"
      ]
    }
  }
}
```

---

## 🧪 Example MCP Tools

### `SearchCodebase`

```json
{
  "keyword": "ConfigureServices"
}
```

### `ReadFile`

```json
{
  "filePath": "Services/UserService.cs"
}
```

### `SummarizeFile`

```json
{
  "filePath": "Startup.cs"
}
```

---

## 📊 Architecture Diagram

```
User → GitHub Copilot Agent Mode → MCP Server (C#):
    - SearchCodebase()
    - ReadFile()
    - SummarizeFile()
          ↓
     Local File System (.cs files)
```

---

## 📖 Learn More

- [MCP Overview](https://modelcontextprotocol.dev/)
- [GitHub Copilot Agent Mode](https://docs.github.com/en/copilot/copilot-in-the-cli/using-github-copilot-in-the-cli)
- [MCP Blog by Microsoft](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)

---

## 📄 License

MIT © 2024 [Riddhi Shah]

