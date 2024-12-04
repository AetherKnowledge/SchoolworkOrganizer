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

        private async void SendMessageAsync(Message message)
        {
            string messageJson = message.ToJson();
            byte[] buffer = Encoding.UTF8.GetBytes(messageJson);
            await socket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private async Task ReceiveMessagesAsync()
        {
            byte[] buffer = new byte[Utilities.BufferSize];
            while (socket.State == WebSocketState.Open)
            {
                WebSocketReceiveResult result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Console.WriteLine("Received: " + receivedMessage);

                Message message = new Message(receivedMessage);
                HandleMessageAsync(message);
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
                // Handle other message types here
                default:
                    break;
            }
        }

        private void HandleStatus(Message message)
        {
            if (message.Data is Status status)
            {
                if (loginTcs != null)
                {
                    loginTcs.SetResult(status == Status.Success);
                    loginTcs = null;
                }
                //MessageBox.Show("Status: " + status);
            }
        }

        private void HandleFetchUser(Message message)
        {
            if (message.Data is User user)
            {
                User.currentUser = user;
            }
        }
    }
}

