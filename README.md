* # C# Examples – Caching, Threading, Pub/Sub, MCP Server

This repository contains a collection of **minimal, focused C# examples** demonstrating key concepts in modern application development: **Caching**, **Threading**, the **Publisher-Subscriber (Pub/Sub)** pattern using events and delegates, and **MCP Server interaction**.

These examples are intentionally simple to serve as a learning aid, reference point, or interview prep material. Each module is self-contained and illustrates one core idea at a time.

---

## 🔧 Contents

### 1. 🗂️ Caching
Demonstrates how to implement basic in-memory caching strategies in C# using dictionaries, lazy loading, and time-based expiration.

**Key concepts:**
- Manual and time-based cache invalidation
- Lazy cache loading
- Performance gain through repeated lookups

### 2. 🧵 Threading
Covers basic multi-threading concepts using `Thread`, `Thread.Sleep`, and `Thread.Join`.

**Key concepts:**
- Creating and managing threads
- Simulating concurrent operations
- Synchronization and timing considerations

### 3. 📣 Pub/Sub (Publisher-Subscriber)
Implements one-to-many, many-to-one, and many-to-many communication patterns using C# `event`, `delegate`, and `EventHandler`.

**Key concepts:**
- Decoupling publisher and subscriber logic
- Real-world analogies like sensor aggregation and message broadcasting
- Topic-based filtering for many-to-many scenarios

---

### 4. 🐒 MCP Server with Monkey App
Demonstrates interaction with a Minecraft Protocol (MCP) server to manage and retrieve information about in-world entities referred to as "monkeys." Provides tools to list all monkeys and get specific details by name.

**Key concepts:**
- Interacting with a Minecraft server using the MCP.
- Retrieving lists of entities within the game world.
- Querying specific entity details by their identifier.
- Server administration and monitoring through custom tools.

---

## 🚀 How to Run

1. Clone the repository
2. Open in Visual Studio or VS Code
3. Navigate to the project folder you'd like to explore
4. Uncomment and run the appropriate `Main()` method

```bash
dotnet build
dotnet run
```

---

## 🧠 Why These Examples?

These modules serve as the foundation for more complex systems such as:
- In-memory caching layers in web APIs
- Real-time messaging systems
- Concurrent data processing pipelines

By understanding the toy version, it's easier to scale to production-grade implementations with `MemoryCache`, `Task`/`async`, or real message brokers.

---

## 📚 Learning Goals

- Grasp foundational system programming concepts
- Learn by doing with clean, readable C# code
- Use these as building blocks for advanced architectures

---

## 👩‍💻 Author

Built by **Riddhi Shah**  
Let’s connect on [LinkedIn](https://www.linkedin.com/in/riddhishah65/) or [GitHub](https://github.com/)

---

## 📜 License

This repository is open for educational and demo purposes. Feel free to fork, clone, or build on top of it.
