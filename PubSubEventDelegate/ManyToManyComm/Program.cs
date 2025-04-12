using System;
using System.Collections.Generic;

// Message Payload
public class MessageEventArgs : EventArgs
{
    public string Publisher { get; }
    public string Message { get; }

    public MessageEventArgs(string publisher, string message)
    {
        Publisher = publisher;
        Message = message;
    }
}

// Topic-based Event Hub
public static class TopicEventHub
{
    private static readonly Dictionary<string, EventHandler<MessageEventArgs>> topics = new();

    public static void Subscribe(string topic, EventHandler<MessageEventArgs> handler)
    {
        if (!topics.ContainsKey(topic))
        {
            topics[topic] = delegate { };
        }

        topics[topic] += handler;
    }

    public static void Publish(string topic, string publisher, string message)
    {
        if (topics.ContainsKey(topic))
        {
            topics[topic]?.Invoke(null, new MessageEventArgs(publisher, message));
        }
    }

    public static void Unsubscribe(string topic, EventHandler<MessageEventArgs> handler)
    {
        if (topics.ContainsKey(topic))
        {
            topics[topic] -= handler;
        }
    }
}

// Publisher
public class Publisher
{
    public string Name { get; }

    public Publisher(string name)
    {
        Name = name;
    }

    public void Send(string topic, string message)
    {
        TopicEventHub.Publish(topic, Name, message);
    }
}

// Subscriber
public class Subscriber
{
    public string Name { get; }

    public Subscriber(string name)
    {
        Name = name;
    }

    public void SubscribeTo(string topic)
    {
        TopicEventHub.Subscribe(topic, HandleMessage);
    }

    private void HandleMessage(object sender, MessageEventArgs e)
    {
        Console.WriteLine($"[{Name}] received from {e.Publisher}: {e.Message}");
    }
}

// Main Program
public class Program
{
    public static void Main()
    {
        var pub1 = new Publisher("Pub1");
        var pub2 = new Publisher("Pub2");

        var sub1 = new Subscriber("Sub1");
        var sub2 = new Subscriber("Sub2");

        // Subscriptions
        sub1.SubscribeTo("news");
        sub2.SubscribeTo("alerts");

        // Pub1 sends to "news" topic
        pub1.Send("news", "Breaking: New Pub/Sub system live!");

        // Pub2 sends to "alerts" topic
        pub2.Send("alerts", "Alert: High CPU usage detected.");

        // Pub2 sends to "news" again
        pub2.Send("news", "Update: CPU usage normalized.");
    }
}
