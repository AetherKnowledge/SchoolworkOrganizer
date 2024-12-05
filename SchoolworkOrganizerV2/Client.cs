using SchoolworkOrganizerUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Policy;
using System.Text;
using Message = SchoolworkOrganizerUtils.Message;

namespace SchoolworkOrganizer
{
    internal class Client
    {
        private readonly ClientWebSocket socket = new ClientWebSocket();
        private readonly Uri uri;
        private TaskCompletionSource<bool>? loginTcs;
        private TaskCompletionSource<bool>? registerTcs;

        public Client(Uri uri)
        {
            this.uri = uri;
        }

        public async Task ConnectAsync()
        {
            await socket.ConnectAsync(uri, default);
            Console.WriteLine("Connected to the server.");
            await ReceiveMessagesAsync();
        }

        public async Task<bool> Login(string username, string password)
        {
            loginTcs = new TaskCompletionSource<bool>();

            Dictionary<string, string> loginData = new Dictionary<string, string>();
            loginData["username"] = username;
            loginData["password"] = password;

            Message message = new Message(MessageType.Login, loginData);
            SendMessageAsync(message);

            return await loginTcs.Task;
        }

        public async Task<bool> Register(User user)
        {
            registerTcs = new TaskCompletionSource<bool>();

            Message message = new Message(MessageType.Register, user);
            SendMessageAsync(message);

            return await registerTcs.Task;
        }

        public void UpdateUser(string oldUsername, User user)
        {
            Dictionary<string, User> updateData = new Dictionary<string, User>();
            updateData[oldUsername] = user;

            Message message = new Message(MessageType.UpdateUser, updateData);
            SendMessageAsync(message);
        }

        private async void SendMessageAsync(Message message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message.ToJson());
            await socket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
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
                    
                    Message message = new Message(receivedMessage);
                    if (message != null)
                    {
                        HandleMessageAsync(message);
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
                socket.Dispose();
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
                Console.WriteLine(e.Message);
            }
        }

        private async void HandleMessageAsync(Message message)
        {
            switch (message.Type)
            {
                case MessageType.Status:
                    HandleStatus(message);
                    break;
                case MessageType.FetchUser:
                    await HandleFetchUser(message);
                    break;
                // Handle other message types here
                default:
                    break;
            }
        }

        private async void HandleStatus(Message message)
        {
            if (message.Data is Status status)
            {
                if (loginTcs != null)
                {
                    loginTcs.SetResult(status == Status.Success);
                    loginTcs = null;
                }
                if (registerTcs != null)
                {
                    registerTcs.SetResult(status == Status.Success);
                    registerTcs = null;
                }

                //MessageBox.Show("Status: " + status);
            }
        }

        private async Task HandleFetchUser(Message message)
        {
            if (message.Data is User user)
            {
                User.currentUser = user;
            }
        }
    }
}

