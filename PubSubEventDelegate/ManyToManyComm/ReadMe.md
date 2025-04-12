# Many-to-Many Communication in C# using Topic-Based Pub/Sub

This project demonstrates a **many-to-many communication model** using the **Publisher-Subscriber (Pub/Sub)** pattern in C#, enhanced with **topic-based filtering**. It simulates how multiple publishers can send messages to various topics, and how multiple subscribers can selectively subscribe to only the topics they care about.

---

## 🔧 Project Structure

- `MessageEventArgs.cs` – Defines the structure of the message payload.
- `TopicEventHub.cs` – Static event hub that manages topic-based subscriptions.
- `Publisher.cs` – Represents a message sender that publishes messages to a topic.
- `Subscriber.cs` – Represents a message receiver that subscribes to one or more topics.
- `Program.cs` – Demonstrates many-to-many communication through sample publishers and subscribers.

---

## 🧠 Key Concepts

### ✅ Many-to-Many Communication
- **Multiple Publishers** can send messages to multiple topics.
- **Multiple Subscribers** can subscribe to different or overlapping topics.
- **Decoupled Architecture** allows for flexible communication without tight coupling between senders and receivers.

### ✅ Topic-Based Filtering
Subscribers only receive messages from the topics they are interested in. This mimics real-world message brokers like Kafka, Azure Event Grid, and RabbitMQ.

---

## 🚀 How It Works

### 1. Publishers Send Messages
Each publisher sends messages to a specific topic via `TopicEventHub`.

```csharp
pub1.Send("news", "Breaking: Pub/Sub system live!");
```

### 2. Subscribers Subscribe to Topics
Subscribers register a handler only for topics they're interested in.

```csharp
sub1.SubscribeTo("news");
sub2.SubscribeTo("alerts");
```

### 3. Event Hub Dispatches
When a message is published to a topic, only subscribers registered for that topic receive it.

---

## 💡 Sample Output

```bash
[Sub1] received from Pub1: Breaking: Pub/Sub system live!
[Sub2] received from Pub2: Alert: High CPU usage detected.
[Sub1] received from Pub2: Update: CPU usage normalized.
```

---

## 🔄 Potential Enhancements

- [ ] Multiple topic subscriptions per subscriber
- [ ] Wildcard or pattern-based topic matching
- [ ] Async message delivery
- [ ] Logging and metrics
- [ ] GUI or Web API integration

---

## 🛠 Requirements

- .NET SDK 6.0 or later
- C# 10+

---

## 📁 Run the Project

1. Clone the repository
2. Open in Visual Studio or VS Code
3. Build and run the `Program.cs` file

```bash
dotnet build
dotnet run
```

---

## 📚 License

This project is for educational/demo purposes. Feel free to fork and enhance it for your needs!

---

## 👩‍💻 Author

Built by **Riddhi Shah**  
Let’s connect on [LinkedIn](https://www.linkedin.com/) or [GitHub](https://github.com/).
