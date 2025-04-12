# C# Many-to-One Communication using Events and Delegates

This project demonstrates the **Many-to-One communication pattern** in C#, using the built-in event handling mechanism (`delegate` and `event`). It showcases how multiple independent **Clients** (senders) can communicate with a single **Server** (receiver) by raising events.

---

## 📘 Scenario: Sensor Data Aggregation

Imagine a system monitoring environmental conditions across a large building:

- **Many**: Multiple sensors (clients) like temperature, humidity, and motion detectors send data.
- **One**: A central server collects, logs, or processes this data for dashboards, alerts, and long-term storage.

This is a classic many-to-one pattern often seen in **IoT, monitoring systems, and telemetry platforms**.

---

## 🧱 Components

### ✅ Server

- Defines one or more events using custom delegates (e.g., `MessageReceivedEventHandler`)
- Subscribes to its own events for handling
- Can receive single messages or batches from any number of clients

### ✅ Client

- Sends one or multiple messages to the server
- Triggers the server’s event handlers with data (e.g., temperature readings, alerts)

### ✅ Batch Mode (Advanced)

- Demonstrates sending a list of messages at once
- Useful for optimizing communication and reducing event invocation overhead

---

## 🧠 Key Features

- Event-driven messaging with strong C# typing
- Multi-threaded client simulation using `Thread` for concurrency
- Two versions:
  - **Single message per client** (`Client1`, `Server1`)
  - **Batch message from client** (`Client2`, `Server2`)

---

## ⚖️ Pros & Cons

### ✅ Pros
- Centralized processing
- Clean separation of concerns (sensors vs aggregator)
- Easier to scale or manage updates centrally

### ⚠️ Cons
- Potential single point of failure (the server)
- Requires handling for high-volume event throughput
- Network dependency across clients

---

## 🚀 How to Run

1. Clone the repo
2. Open the project in Visual Studio or VS Code
3. Uncomment either `Main` method from:
   - `ManyToOneEventExample` (for single-message)
   - `ManyToOneBatchExample` (for batch-message)
4. Run:

```bash
dotnet build
dotnet run
```

---

## 🛠 Requirements

- .NET SDK 6.0+
- C# 10+

---

## 🔄 Possible Extensions

- Asynchronous event processing with `async/await`
- Logging and metrics (e.g., message count, timestamps)
- Web-based dashboard or REST API server simulation
- Fault-tolerant queue or retry mechanism

---

## 👩‍💻 Author

Built by **Riddhi Shah**  
Let’s connect on [LinkedIn](https://www.linkedin.com/) or [GitHub](https://github.com/)

---

## 📚 License

This project is intended for learning and demonstration purposes. Feel free to fork and build upon it.
