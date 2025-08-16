# 🚀 Microsoft.Extensions.AI Learning Sandbox

This repository is a **hands-on sandbox** for exploring [`Microsoft.Extensions.AI`](https://learn.microsoft.com/en-us/dotnet/ai/microsoft-extensions-ai?utm_source=chatgpt.com), a new set of .NET libraries that provide **abstractions, tooling, and evaluation support** for building AI-powered applications.  

We start with two simple incident simulation examples (**DNS Failure** and **Rate Limit 429**) and use them as a **vehicle to learn the API surface**: chat clients, tool calling, caching, telemetry, evaluation, and more.

---

## 🎯 Project Goals

- Learn **what capabilities `Microsoft.Extensions.AI` exposes**  
- Practice using **all available fields, types, and extension methods**  
- Keep scenarios small & focused (DNS + 429) so we can clearly see how the package works  
- Build a **reference repo** that others can use to get started with the library  

---

## 🛠️ Capabilities of `Microsoft.Extensions.AI`

From [Microsoft’s official docs](https://learn.microsoft.com/en-us/dotnet/ai/microsoft-extensions-ai?utm_source=chatgpt.com) and [intro blog post](https://devblogs.microsoft.com/dotnet/introducing-microsoft-extensions-ai-preview/?utm_source=chatgpt.com):

- **Unified Abstractions for AI Services**  
  - Interfaces like `IChatClient` and `IEmbeddingGenerator<TInput, TEmbedding>` standardize across OpenAI, Azure OpenAI, Ollama, and others.

- **Tool / Function Invocation Middleware**  
  - Define methods as `AIFunction`s and let the model invoke them automatically with typed inputs.

- **Composable Middleware Pipeline**  
  - Wrap AI clients with caching, logging, telemetry, or custom policies using `DelegatingChatClient`.

- **Caching Support**  
  - Use `DistributedCachingChatClient` to cache responses and avoid repeated expensive calls.

- **Telemetry Integration (OpenTelemetry)**  
  - Built-in hooks via `UseOpenTelemetry` for tracing model usage and latency.

- **Dependency Injection Ready**  
  - Register with `.AddChatClient` and inject wherever needed, just like other ASP.NET Core services.

- **Streaming & Synchronous Chat Support**  
  - Get both blocking responses (`GetResponseAsync`) and real-time streaming output (`GetStreamingResponseAsync`).

- **Embedding Generation Abstraction**  
  - Generate embeddings with a consistent interface across providers (`IEmbeddingGenerator<string, Embedding<float>>`).

- **Evaluation Libraries (`Microsoft.Extensions.AI.Evaluation`)**  
  - Run **agent quality evaluators**, **NLP similarity tests**, and **safety checks**.  
  - Use CLI tools (`dotnet aieval`) for structured evaluation and reporting.  
  - Docs: [Evaluation Libraries Overview](https://learn.microsoft.com/en-us/dotnet/ai/conceptual/evaluation-libraries?utm_source=chatgpt.com).

- **Provider-Agnostic Design**  
  - Switch AI backends without rewriting your app logic.

---

## ✅ Current Scenarios (Completed)

| Scenario | Simulation | What we Learn |
|----------|------------|---------------|
| **DNS Failure** | `curl`/`dig` errors for NXDOMAIN | Tool-calling contract, structured results, concise remediation |
| **Rate Limit (429)** | Mock API or Nginx returning 429 + Retry-After | Evidence-grounded output, actionable recommendations |

---
## 📚 References

- 📖 [Microsoft.Extensions.AI Overview](https://learn.microsoft.com/en-us/dotnet/ai/microsoft-extensions-ai?utm_source=chatgpt.com)  
- 📰 [Introducing Microsoft.Extensions.AI (Preview) – DevBlogs](https://devblogs.microsoft.com/dotnet/introducing-microsoft-extensions-ai-preview/?utm_source=chatgpt.com)  
- 📖 [Evaluation Libraries Documentation](https://learn.microsoft.com/en-us/dotnet/ai/conceptual/evaluation-libraries?utm_source=chatgpt.com)

---
### Run scenarios
```bash
# Restore & build
dotnet build

# DNS scenario
dotnet run -- dns

# Rate-limit scenario
dotnet run -- rate-limit
