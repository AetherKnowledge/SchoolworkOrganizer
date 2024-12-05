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
                WebSocketReceiveResult? result = null;
                StringBuilder receivedMessageBuilder = new StringBuilder();
                string receivedMessage = receivedMessageBuilder.ToString();

                while (result == null || !result.CloseStatus.HasValue)
                {
                    receivedMessageBuilder.Clear();
                    do
                    {
                        result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                        receivedMessageBuilder.Append(Encoding.UTF8.GetString(buffer, 0, result.Count));
                    } while (!result.EndOfMessage);

                    if (result.CloseStatus.HasValue) break;

                    receivedMessage = receivedMessageBuilder.ToString();
                    Message message = new Message(receivedMessage);
                    if (message != null)
                    {
                        HandleMessage(message);
                        Console.WriteLine($"Sent to {socketID}: " + message.Type);
                        Console.WriteLine(message.ToJsonNoImage());
                    }
                }

                await socket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                socket.Abort();
            }
            finally
            {
                Console.WriteLine($"Client {socketID} has disconnected");
                socket.Dispose();
                handlers.Remove(this);
            }
        }

        internal async Task Send(Message message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message.ToJson());
            Console.WriteLine(message.ToJsonNoImage());
            await socket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private void HandleMessage(Message message)
        {
            switch (message.Type)
            {
                case MessageType.Login:
                    HandleLogin(message);
                    break;
                case MessageType.Register:
                    HandleRegister(message);
                    break;
                case MessageType.UpdateUser:
                    HandleUpdateUser(message);
                    break;
                // Handle other message types here
                default:
                    break;
            }
        }

        private async void HandleUpdateUser(Message message)
        {
            try
            {
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message.Data == null) throw new ArgumentNullException(nameof(message.Data));
                else if (message.Data is not Dictionary<string, User>) throw new ArgumentException("Invalid data type");

                Dictionary<string, User> userData = (Dictionary<string, User>)message.Data;
                User updatedUser = userData.FirstOrDefault().Value;
                string previousUsername = userData.FirstOrDefault().Key;
                if (previousUsername != this.user.Username) throw new ArgumentException("Cannot update if different users");
                
                if (await UserHandler.UpdateToDatabase(updatedUser, user.Username))
                {
                    User.Users.Remove(user);
                    User.Users.Add(updatedUser);
                    user = updatedUser;
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private async void HandleLogin(Message message)
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

        private async void HandleRegister(Message message)
        {
            try
            {
                if (message.Data == null) throw new ArgumentNullException(nameof(message.Data));
                else if (message.Data is not User) throw new ArgumentException("Invalid data type");

                User user = (User)message.Data;
                if (!UserHandler.DoesUserExist(user.Username))
                {
                    User.Users.Add(user);
                    UserHandler.AddToDatabase(user);

                    Message statusMessage = new Message(MessageType.Status, Status.Success);
                    await Send(statusMessage);
                    Console.WriteLine($"Sent to {socketID}: " + statusMessage.Type);
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
                Message statusMessage = new Message(MessageType.Status, Status.Failure);
                await Send(statusMessage);
                Console.WriteLine($"Sent to {socketID}: " + statusMessage.Type);
            }

        }

    }

}
