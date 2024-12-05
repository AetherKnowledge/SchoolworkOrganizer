using Newtonsoft.Json.Linq;
using SchoolworkOrganizerUtils;
using SchoolworkOrganizerUtils.MessageTypes;
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
        private User? currentUser;

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

                    Message? message = Message.Parse(receivedMessage);
                    if (message != null)
                    {
                        await Task.Run(() => HandleMessage(message));
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
            byte[] buffer = Encoding.UTF8.GetBytes(message.ToString());
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
                case MessageType.AddSubject:
                    HandleAddSubject(message);
                    break;
                case MessageType.UpdateSubject:
                    HandleUpdateSubject(message);
                    break;
                case MessageType.DeleteSubject:
                    HandleDeleteSubject(message);
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
                else if (message is not UserMessage) throw new ArgumentException("Invalid message type");
                else if (message.Type != MessageType.UpdateUser) throw new ArgumentException("Invalid message type");
                UserMessage updateMessage = (UserMessage)message;

                if (this.currentUser == null || updateMessage.PreviousUsername != this.currentUser.Username) throw new ArgumentException("Cannot update if different users");
                await UserHandler.UpdateToDatabase(updateMessage);
                currentUser = await UserHandler.GetUser(updateMessage.Username);
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
                if (message == null) throw new ArgumentNullException(nameof(message));
                if (message is not LoginMessage) throw new ArgumentException("Invalid message type");
                LoginMessage loginData = (LoginMessage) message;

                string username = loginData.Username;
                string password = loginData.Password;

                User? user = await UserHandler.AttemptLogin(username, password);

                if (user != null)
                {
                    currentUser = await UserHandler.GetUser(username);
                    Message statusMessage = new StatusMessage(Status.Success);
                    Message userInfoMessage = new UserMessage(MessageType.FetchUser, user);
                    Message userDataMessage = new UserDataMessage(username, await SubjectHandler.GetSubjects(username));

                    await Send(statusMessage);
                    Console.WriteLine($"Sent to {socketID}: " + statusMessage.Type);
                    await Send(userInfoMessage);
                    Console.WriteLine($"Sent to {socketID}: " + userInfoMessage.Type);
                    await Send(userDataMessage);
                    Console.WriteLine($"Sent to {socketID}: " + userDataMessage.Type);
                }
                else
                {
                    Message statusMessage = new StatusMessage(Status.Failure);
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
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not UserMessage) throw new ArgumentException("Invalid message type");
                else if (message.Type != MessageType.Register) throw new ArgumentException("Invalid message type");
                UserMessage registerMessage = (UserMessage)message;

                if (!(await UserHandler.DoesUserExist(registerMessage.Username)))
                {
                    UserHandler.AddToDatabase(registerMessage);
                    Message statusMessage = new StatusMessage(Status.Success);
                    await Send(statusMessage);
                    Console.WriteLine($"Sent to {socketID}: " + statusMessage.Type);
                }
                else
                {
                    Message statusMessage = new StatusMessage(Status.Failure);
                    await Send(statusMessage);
                    Console.WriteLine($"Sent to {socketID}: " + statusMessage.Type);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Message statusMessage = new StatusMessage(Status.Failure);
                await Send(statusMessage);
                Console.WriteLine($"Sent to {socketID}: " + statusMessage.Type);
            }

        }

        private void HandleAddSubject(Message message)
        {
            try
            {
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not SubjectMessage) throw new ArgumentException("Invalid data type");

                SubjectMessage subjectMessage = (SubjectMessage)message;

                if (this.currentUser == null || subjectMessage.Username != this.currentUser.Username) throw new ArgumentException("Cannot add subject to different user");
                SubjectHandler.AddToDatabase(currentUser, subjectMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private void HandleUpdateSubject(Message message)
        {
            try
            {
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not SubjectMessage) throw new ArgumentException("Invalid data type");
                
                SubjectMessage subjectMessage = (SubjectMessage)message;
                if (this.currentUser == null || subjectMessage.Username != this.currentUser.Username) throw new ArgumentException("Cannot update subject of different user");
                
                SubjectHandler.UpdateToDatabase(currentUser, subjectMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void HandleDeleteSubject(Message message)
        {
            try
            {
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not SubjectMessage) throw new ArgumentException("Invalid data type");

                SubjectMessage subjectMessage = (SubjectMessage)message;
                if (this.currentUser == null || subjectMessage.Username != this.currentUser.Username) throw new ArgumentException("Cannot delete subject of different user");

                SubjectHandler.DeleteFromDatabase(subjectMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }

}
