/// <summary>
/// This is One-To-Many Communication Event Handling Example
/// Example: Social Media Platforms: When someone posts an update, it's broadcast to their followers (one-to-many).
/// </summary>

// Step 1: Define the Publisher
public class MessageBroadcaster
{
    // Define the event using Action<string> delegate
    // This event will carry the string message to subscribers
    public event Action<string> OnMessagePublished;

    // Method to publish a message
    public void PublishMessage(string message)
    {
        Console.WriteLine($"\nBroadcaster: Publishing message -> '{message}'");

        // Trigger the event, notifying all subscribers
        // Using ?.Invoke ensures it only runs if there are subscribers
        OnMessagePublished?.Invoke(message);
    }
}

// Step 2: Define the Subscriber
public class MessageListener
{
    public string Name { get; private set; }

    public MessageListener(string name)
    {
        Name = name;
    }

    // This method matches the Action<string> delegate signature
    public void HandleMessage(string message)
    {
        Console.WriteLine($"  >> Listener '{Name}' received: {message}");
    }
}

// Step 3: Main Program Logic to wire everything up
public class Program
{
    public static void Main(string[] args)
    {
        // Create the broadcaster (Publisher)
        MessageBroadcaster broadcaster = new MessageBroadcaster();

        // Create listener instances (Subscribers)
        MessageListener listener1 = new MessageListener("Listener Alpha");
        MessageListener listener2 = new MessageListener("Listener Beta");
        MessageListener listener3 = new MessageListener("Listener Gamma");

        // Subscribe listeners to the broadcaster's event
        Console.WriteLine("Subscribing listeners Started to Listen");
        broadcaster.OnMessagePublished += listener1.HandleMessage;
        broadcaster.OnMessagePublished += listener2.HandleMessage;
        broadcaster.OnMessagePublished += listener3.HandleMessage;
        Console.WriteLine("Subscriptions complete.");

        // Publish some messages
        broadcaster.PublishMessage("Hello World!");
        Thread.Sleep(500); // Pause briefly for readability
        broadcaster.PublishMessage("This is the second message.");

        // Unsubscribe one listener
        Console.WriteLine("\nUnsubscribing Listener Beta...");
        broadcaster.OnMessagePublished -= listener2.HandleMessage;
        Console.WriteLine("Unsubscription complete.");

        // Publish another message - Listener Beta should not receive it
        broadcaster.PublishMessage("Final message after unsubscribing Beta.");

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }
}
