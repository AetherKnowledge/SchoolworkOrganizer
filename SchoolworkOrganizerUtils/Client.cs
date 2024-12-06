using SchoolworkOrganizerUtils.MessageTypes;
using System.Net.WebSockets;
using System.Text;

namespace SchoolworkOrganizerUtils
{
    public static class Client
    {
        private static ClientWebSocket socket = new ClientWebSocket();
        private static readonly Uri uri = new Uri(Utilities.WebSocket);
        private static TaskCompletionSource<bool>? loginTcs;
        private static TaskCompletionSource<bool>? registerTcs;
        private static TaskCompletionSource<bool>? connectionTcs;

        public static async Task ConnectAsync()
        {
            try
            {
                await socket.ConnectAsync(uri, default);
                if (connectionTcs != null) connectionTcs.SetResult(true);

                Console.WriteLine("Connected to the server.");
                await ReceiveMessagesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(5000);
                socket = new ClientWebSocket();
                ConnectAsync().Wait();
            }
            
        }

        public static async Task<bool> Login(string username, string password)
        {
            loginTcs = new TaskCompletionSource<bool>();
            Message message = new LoginMessage(username, password);
            SendMessageAsync(message);

            return await loginTcs.Task;
        }

        public static async Task<bool> Register(User user)
        {
            registerTcs = new TaskCompletionSource<bool>();

            Message message = new UserMessage(MessageType.Register, user);
            SendMessageAsync(message);

            return await registerTcs.Task;
        }

        public static void UpdateUser(string oldUsername, User user)
        {
            Message message = new UserMessage(MessageType.UpdateUser, user, oldUsername);
            SendMessageAsync(message);
        }

        internal static async void SendMessageAsync(Message message)
        {
            if (socket.State != WebSocketState.Open) {
                Console.WriteLine("Please wait while trying to connect");

                connectionTcs = new TaskCompletionSource<bool>();
                await connectionTcs.Task;
            }

            byte[] buffer = Encoding.UTF8.GetBytes(message.ToString());
            await socket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private static async Task ReceiveMessagesAsync()
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
                        await Task.Run(() => HandleMessageAsync(message));
                    }
                }

                await socket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(5000);
                socket = new ClientWebSocket();
                ConnectAsync().Wait();
            }

        }

        public static void Disconnect()
        {
            try
            {
                socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client disconnected", CancellationToken.None).Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void HandleMessageAsync(Message message)
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

        private static void HandleStatus(Message message)
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

        private static void HandleFetchUser(Message message)
        {
            if (message is not UserMessage) return;
            if (message.Type != MessageType.FetchUser) return;
            UserMessage userMessage = (UserMessage)message;

            User.currentUser = userMessage.GetUser();
        }

        private static void HandleFetchUserData(Message message)
        {
            if (User.currentUser == null) return;
            if (message is not UserDataMessage) return;
            UserDataMessage userDataMessage = (UserDataMessage)message;

            User.currentUser.Subjects = userDataMessage.Subjects;
        }
    }
}

