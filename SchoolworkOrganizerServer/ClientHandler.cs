using SchoolworkOrganizerUtils;
using System.Linq;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using Object = System.Object;

namespace SchoolworkOrganizerServer
{
    internal class ClientHandler
    {
        private List<ClientHandler> handlers = new List<ClientHandler>();

        private WebSocket socket;
        internal string socketID;
        private User? user;

        public ClientHandler(WebSocket socket)
        {
            this.socket = socket;
            this.socketID = Guid.NewGuid().ToString();
        }

        internal async Task Start()
        {
            try
            {
                byte[] buffer = new byte[Utilities.BufferSize];
                WebSocketReceiveResult result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                while (!result.CloseStatus.HasValue)
                {
                    string receivedMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    Console.WriteLine($"Received from {socketID}: " + receivedMessage);

                    Message message = new Message(receivedMessage);
                    if (message != null)
                    {
                        await HandleMessage(message);
                    }

                    result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                }

                handlers.Remove(this);
                await socket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
                handlers.Remove(this); 
                Console.WriteLine($"Client {socketID} has disconnected");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await socket.CloseAsync(WebSocketCloseStatus.EndpointUnavailable, $"Client {socketID} has disconnected", CancellationToken.None);
                handlers.Remove(this);
            }
        }

        internal async Task Send(Message message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message.ToJson());
            await socket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private async Task HandleMessage(Message message)
        {
            switch (message.Type)
            {
                case MessageType.Login:
                    await HandleLogin(message);
                    break;
                // Handle other message types here
                default:
                    break;
            }
        }

        private async Task HandleLogin(Message message)
        {
            try
            {
                if (message.Data == null) throw new ArgumentNullException(nameof(message.Data));
                else if (message.Data is not Dictionary<string, string>) throw new ArgumentException("Invalid data type");

                Dictionary<string, string> loginData = (Dictionary<string, string>)message.Data;

                if (User.Users.Any(user => user.Username == loginData["username"] && user.Password == loginData["password"]))
                {
                    user = User.Users.First(u => u.Username == loginData["username"] && u.Password == loginData["password"]);
                    Message statusMessage = new Message(MessageType.Status, Status.Success);
                    Message dataMessage = new Message(MessageType.FetchUser, user);

                    await Send(statusMessage);
                    Console.WriteLine($"Sent to {socketID}: " + statusMessage.Type);
                    await Send(dataMessage);
                    Console.WriteLine($"Sent to {socketID}: " + dataMessage.Type);
                }
                else
                {
                    Message statusMessage = new Message(MessageType.Status, Status.Failure);
                    await Send(statusMessage);
                    Console.WriteLine($"Sent to {socketID}: " + statusMessage.Type);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

    }

}
