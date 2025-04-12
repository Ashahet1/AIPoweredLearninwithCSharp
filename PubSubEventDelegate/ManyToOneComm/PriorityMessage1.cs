namespace ManyToOneExample
{

    public class Server1
    {
        public delegate void MessageReceivedEventHandler(string message, string senderId);
        public event MessageReceivedEventHandler OnMessageReceived;

        public virtual void RaiseMessageReceivedEvent(string message, string senderId)
        {
            OnMessageReceived?.Invoke(message, senderId);
        }

        public void HandleMessage(string message, string senderId)
        {
            Console.WriteLine($"Server handled message from Client {senderId}: {message}");
        }

        public Server1()
        {
            OnMessageReceived += HandleMessage;
        }
    }

    public class Client1
    {
        private readonly string _clientId;
        private readonly Server1 _server;
        public string ClientId => _clientId;
        public Client1(string id, Server1 server)
        {
            _clientId = id;
            _server = server;
        }
        public void SendMessage(string message)
        {
            Console.WriteLine($"Client {_clientId} sending message: {message}");
            _server.RaiseMessageReceivedEvent(message, _clientId);
        }
    }


    public class ManyToOneEventExample
    {
        //public static void Main(string[] args)
        //{
        //    Server1 centralServer = new Server1();

        //    List<Client1> clients = new List<Client1>();
        //    for (int i = 1; i <= 3; i++)
        //    {
        //        clients.Add(new Client1(i.ToString(), centralServer));
        //    }

        //    List<Thread> clientThreads = new List<Thread>();
        //    foreach (var client in clients)
        //    {
        //        Thread thread = new Thread(() =>
        //        {
        //            client.SendMessage($"Hello from Client {client.ClientId} (via event) - Message 1"); // The chage is only here which is in the message string nothing more.
        //            Thread.Sleep(100); // Simulate some work
        //            client.SendMessage($"Hello from Client {client.ClientId} (via event) - Message 2");
        //        });
        //        clientThreads.Add(thread);
        //        thread.Start();
        //    }

        //    foreach (var thread in clientThreads)
        //    {
        //        thread.Join();
        //    }

        //    Console.WriteLine("\nMany-to-One communication example using events finished.");
        //}
    }
}