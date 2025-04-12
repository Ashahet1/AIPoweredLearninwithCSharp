# Many-to-One Communication in C# using Events

This project demonstrates a **many-to-one communication pattern** in C#, modeled after real-world systems like **sensor-to-server data aggregation**. It uses **event-based messaging** to simulate multiple clients (sensors) sending messages to a central server.

---

## 📘 Real-World Analogy

### **Scenario: Sensor Data Aggregation**
- **Many**: Multiple sensors (clients) like temperature, humidity, and motion detectors
- **One**: A central server collects and processes all incoming data

This is a typical setup in systems like smart buildings, industrial monitoring, or IoT deployments.

---

## 🔧 Project Structure

- `Server1`, `Client1` – Basic event-based communication where each message is sent and received individually.
- `Server2`, `Client2` – Batch-based message communication where multiple messages are sent together.
- `ManyToOneEventExample` – Demonstrates the standard many-to-one message flow.
- `ManyToOneBatchExample` – Demonstrates sending grouped (batch) messages from clients to the server.

---

## 🧠 Key Concepts

### ✅ Many-to-One Communication
- **Clients**: Multiple senders independently generate and send messages.
- **Server**: A single receiver processes all incoming messages using event handlers.

### ✅ Use of Delegates and Events
- Clients trigger messages via events.
- The server handles them with dedicated handlers registered during construction.

---

## 🚀 How It Works

### Basic Flow (`Server1` / `Client1`)
```csharp
client.SendMessage("Hello from Client 1");
```
The server receives and logs:
```bash
Server handled message from Client 1: Hello from Client 1
```

### Batch Flow (`Server2` / `Client2`)
```csharp
client.GatherAndSendMessages();
```
The server receives:
```bash
Server received all messages from Client 2:
  - Client 2 - Message 1 - Timestamp: ...
  - Client 2 - Message 2 - Timestamp: ...
```

---

## 💡 Benefits of Many-to-One Communication

✅ **Centralized Data Management**  
✅ **Simplified Client Logic**  
✅ **Unified Processing & Monitoring**

---

## ⚠️ Trade-Offs

⚠️ **Single Point of Failure**  
⚠️ **Potential Server Bottlenecks**  
⚠️ **High Network Dependency**

---

## 🛠 Requirements

- .NET SDK 6.0 or later
- C# 10+

---

## 📁 Run the Project

1. Clone the repository
2. Open in Visual Studio or VS Code
3. Uncomment the `Main` method in either `ManyToOneEventExample` or `ManyToOneBatchExample`
4. Build and run:

```bash
dotnet build
dotnet run
```

---

## 📚 License

This project is for learning/demo purposes. Feel free to build on it for more advanced simulations.

---

## 👩‍💻 Author

Built by **Riddhi Shah**  
Let’s connect on [LinkedIn](https://www.linkedin.com/riddhishah65) or [GitHub](https://github.com/)

