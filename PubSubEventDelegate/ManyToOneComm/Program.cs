///<summary>
///Many-To-One Communication Event Handling Example
/// Real - World Example: Sensor Data Aggregation
///Imagine a system monitoring environmental conditions in a large building or across a campus.
///Many: Numerous sensors(temperature, humidity, light levels, motion detectors) are deployed throughout the area. Each sensor acts as a sender.
///One: A central server or data logger acts as the receiver. This server is responsible for collecting, storing, and potentially processing the data from all the sensors.
///Each sensor periodically sends its readings to the central server. The server receives these data points from multiple sources and aggregates them for analysis, visualization, or triggering alerts.
///Pros of Many-to-One Communication (in this context):
///Centralized Data Management: All the data from various sources is collected in one place, making it easier to manage, query, and analyze. This simplifies tasks like generating reports, creating dashboards, and identifying trends.
///Simplified Processing Logic: The complex logic for data aggregation, analysis, and decision-making can be concentrated on the central server. Individual sensors can be simpler and less resource-intensive as they primarily focus on data acquisition and transmission.
///Single Point of Control: Configuration, updates, and maintenance can be managed centrally on the server, rather than having to interact with each individual sensor.
///Cons of Many-to-One Communication (in this context):
///Single Point of Failure: If the central server fails, the entire data collection system goes down. No new data will be recorded, and any real-time monitoring or alerting will cease. This can be a critical issue depending on the application.
///Potential Bottleneck: The central server can become a bottleneck if the number of sensors and the frequency of data transmission are very high. It might struggle to handle the volume of incoming data, leading to delays or data loss. Careful capacity planning and efficient processing are crucial.
///Network Dependency: The system relies heavily on network connectivity between the sensors and the central server. If the network infrastructure is unreliable or has limited bandwidth, it can impact data delivery and system performance.
/// </summary>

public class Server
{
    // Define a delegate for the message received event
    public delegate void MessageReceivedEventHandler(string message, string senderId);

    // Define the event based on the delegate
    public event MessageReceivedEventHandler OnMessageReceived;

    // Method to be called when a message is received
    public virtual void RaiseMessageReceivedEvent(string message, string senderId)
    {
        OnMessageReceived?.Invoke(message, senderId);
    }

    // Handler for the message received event
    public void HandleMessage(string message, string senderId)
    {
        Console.WriteLine($"Server handled message from Client {senderId}: {message}");
    }

    // Constructor to subscribe to the event
    public Server()
    {
        OnMessageReceived += HandleMessage;
    }
}

public class Client
{
    private readonly string _clientId;
    private readonly Server _server;

    // Public property to access the client ID
    public string ClientId => _clientId;

    public Client(string id, Server server)
    {
        _clientId = id;
        _server = server;
    }

    public void SendMessage(string message)
    {
        Console.WriteLine($"Client {_clientId} sending message: {message}");
        // Correctly raising the event
        _server.RaiseMessageReceivedEvent(message, _clientId);
    }
}

public class ManyToOneEventExample
{
    //public static void Main(string[] args)
    //{
    //    Server centralServer = new Server();

    //    // Create multiple clients
    //    List<Client> clients = new List<Client>();
    //    for (int i = 1; i <= 3; i++)
    //    {
    //        clients.Add(new Client(i.ToString(), centralServer));
    //    }

    //    // Simulate clients sending messages concurrently
    //    List<Thread> clientThreads = new List<Thread>();
    //    foreach (var client in clients)
    //    {
    //        Thread thread = new Thread(() =>
    //        {
    //            client.SendMessage($"Hello from Client {client.ClientId} (via event)");
    //            Thread.Sleep(100); // Simulate some work
    //            client.SendMessage($"Another message from Client {client.ClientId} (via event)");
    //        });
    //        clientThreads.Add(thread);
    //        thread.Start();
    //    }

    //    // Wait for all client threads to finish
    //    foreach (var thread in clientThreads)
    //    {
    //        thread.Join();
    //    }

    //    Console.WriteLine("\nMany-to-One communication example using events finished.");
    //}
}



