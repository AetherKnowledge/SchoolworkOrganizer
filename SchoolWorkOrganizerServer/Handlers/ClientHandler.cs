using SchoolworkOrganizerUtils;
using SchoolworkOrganizerUtils.MessageTypes;
using System.Net.WebSockets;
using System.Text;

namespace SchoolworkOrganizerServer
{
    internal partial class ClientHandler
    {
        private static List<ClientHandler> handlers = new List<ClientHandler>();
        private WebSocket socket;
        internal string socketID;
        private string? currentUsername;

        public ClientHandler(WebSocket socket)
        {
            this.socket = socket;
            this.socketID = Guid.NewGuid().ToString();
            handlers.Add(this);
            Console.WriteLine("Client count is now " + handlers.Count);
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
                        if (Utilities.ShowDataStream) Console.WriteLine(message.ToJsonNoData());
                    }
                }

                await socket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
            }
            catch (Exception e)
            {
                if (Utilities.Debug) Console.WriteLine(e.StackTrace); 
                Console.WriteLine(e.Message);
                socket.Abort();
            }
            finally
            {
                if (socket.State == WebSocketState.Open) socket.Dispose();
                handlers.Remove(this);
                Console.WriteLine($"Client {socketID} has disconnected");
                Console.WriteLine("Client count is now " + handlers.Count);
            }
        }

        internal async Task SendAsync(Message message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message.ToString());
            if (Utilities.ShowDataStream) Console.WriteLine(message.ToJsonNoData());
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
                case MessageType.AddActivity:
                    HandleAddActivity(message);
                    break;
                case MessageType.UpdateActivity:
                    HandleUpdateActivity(message);
                    break;
                case MessageType.DeleteActivity:
                    HandleDeleteActivity(message);
                    break;
                case MessageType.AddReviewer:
                    HandleAddReviewer(message);
                    break;
                case MessageType.UpdateReviewer:
                    HandleUpdateReviewer(message);
                    break;
                case MessageType.DeleteReviewer:
                    HandleDeleteReviewer(message);
                    break;
                default:
                    break;
            }
        }
    }

}
