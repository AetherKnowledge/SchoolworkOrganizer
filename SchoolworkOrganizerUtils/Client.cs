using SchoolworkOrganizerUtils.MessageTypes;
using System.Net.WebSockets;
using System.Text;

namespace SchoolworkOrganizerUtils
{
    public partial class Client
    {
        private ClientWebSocket socket = new ClientWebSocket();
        private readonly Uri uri = new Uri(Utilities.WebSocket);
        private TaskCompletionSource<bool>? connectionTcs;

        //public static Client MainClient = new Client();

        public async Task ConnectAsync()
        {
            try
            {
                Console.WriteLine($"Connecting to the server at {uri.ToString()}");
                await socket.ConnectAsync(uri, default);
                if (connectionTcs != null) connectionTcs.SetResult(true);
                connectionTcs = null;

                Console.WriteLine("Connected to the server.");
                await ReceiveMessagesAsync();
            }
            catch (Exception e)
            {
                Logout();
                Console.WriteLine(e.StackTrace); 
                Console.WriteLine(e.Message);
                socket.Dispose();
                Thread.Sleep(5000);
                socket = new ClientWebSocket();
                ConnectAsync().Wait();
            }
            
        }

        private async Task ReceiveMessagesAsync()
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

                    receivedMessage = receivedMessageBuilder.ToString();
                    if (receivedMessage == "") continue;
                    
                    Message? message = Message.Parse(receivedMessage);
                    if (message != null)
                    {
                        if (Utilities.ShowDataStream) Console.WriteLine(message.ToJsonNoData());
                        await Task.Run(() => HandleMessageAsync(message));
                    }
                }

                await socket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
            }
            catch (Exception e)
            {
                Logout();
                Console.WriteLine(e.StackTrace); 
                Console.WriteLine(e.Message);
                //socket.Dispose();
                //Thread.Sleep(5000);
                //socket = new ClientWebSocket();
                //ConnectAsync().Wait();
            }

        }

        public void Disconnect()
        {
            try
            {
                socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client disconnected", CancellationToken.None).Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace); 
                Console.WriteLine(e.Message);
            }
        }

        private void HandleMessageAsync(Message message)
        {
            switch (message.Type)
            {
                case MessageType.Status:
                    HandleStatus(message);
                    break;
                case MessageType.FetchUser:
                    HandleFetchUser(message);
                    break;
                case MessageType.FetchUserData:
                    HandleFetchUserData(message);
                    break;
                default:
                    break;
            }
        }

        private void HandleStatus(Message message)
        {
            if (message is StatusMessage statusMessage)
            {
                if (loginTcs != null)
                {
                    loginTcs.SetResult(statusMessage.Status == Status.Success);
                    Console.WriteLine("Logged in.");
                    loginTcs = null;
                }
                if (registerTcs != null)
                {
                    registerTcs.SetResult(statusMessage.Status == Status.Success);
                    registerTcs = null;
                }

                //MessageBox.Show("Status: " + status);
            }
        }

        public void CheckForUpdates()
        {
            if (user == null)
            {
                Console.WriteLine("User is null");
                return;
            }
            foreach (Subject subject in user.Subjects)
            {
                subject.CheckForUpdates();
            }
        }

    }
}

