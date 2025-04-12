namespace ManyToOneExample
{

    public class Server2
    {
        public delegate void MessagesReceivedEventHandler(List<string> messages, string senderId);
        public event MessagesReceivedEventHandler OnMessagesReceived;

        public virtual void RaiseMessagesReceivedEvent(List<string> messages, string senderId)
        {
            OnMessagesReceived?.Invoke(messages, senderId);
        }

        public void HandleMessages(List<string> messages, string senderId)
        {
            Console.WriteLine($"Server received all messages from Client {senderId}:");
            foreach (var message in messages)
            {
                Console.WriteLine($"  - {message}");
            }
        }

        public Server2()
        {
            OnMessagesReceived += HandleMessages;
        }
    }

    public class Client2
    {
        private readonly string _clientId;
        private readonly Server2 _server;
        public string ClientId => _clientId;

        public Client2(string id, Server2 server)
        {
            _clientId = id;
            _server = server;
        }

        public void GatherAndSendMessages()
        {
            Console.WriteLine($"Client {_clientId} gathering messages...");
            List<string> messages = new List<string>
        {
            $"Client {_clientId} - Message 1 - Timestamp: {DateTime.Now.Ticks}",
            $"Client {_clientId} - Message 2 - Timestamp: {DateTime.Now.Ticks}",
            $"Client {_clientId} - Message 3 - Timestamp: {DateTime.Now.Ticks}"
        };
            Console.WriteLine($"Client {_clientId} sending all messages.");
            _server.RaiseMessagesReceivedEvent(messages, _clientId);
        }


    }

    public class ManyToOneBatchExample
    {
        public static void Main(string[] args)
        {
            Server2 ServerInstance = new Server2();

            List<Client2> clients = new List<Client2>();
            for (int i = 1; i <= 3; i++)
            {
                clients.Add(new Client2(i.ToString(),
                                        ServerInstance));
            }

            List<Thread> clientThreads = new List<Thread>();
            foreach (var client in clients)
            {
                Thread thread = new Thread(() =>
                {
                    client.GatherAndSendMessages();
                });
                clientThreads.Add(thread);
                thread.Start();
            }

            foreach (var thread in clientThreads)
            {
                thread.Join();
            }

            Console.WriteLine("\nMany-to-One communication example (batch) finished.");
        }
    }
}
