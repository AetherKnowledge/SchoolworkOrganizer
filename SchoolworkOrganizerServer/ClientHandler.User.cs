using SchoolworkOrganizerUtils.MessageTypes;
using SchoolworkOrganizerUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolworkOrganizerServer
{
    internal partial class ClientHandler
    {
        private async void HandleUpdateUser(Message message)
        {
            try
            {
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not UserMessage) throw new ArgumentException("Invalid message type");
                else if (message.Type != MessageType.UpdateUser) throw new ArgumentException("Invalid message type");
                UserMessage updateMessage = (UserMessage)message;

                if (this.currentUsername == null || updateMessage.PreviousUsername != this.currentUsername) throw new ArgumentException("Cannot update if different users");
                await UserHandler.UpdateToDatabase(updateMessage);
                currentUsername = updateMessage.Username;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace); 
                Console.WriteLine(e.Message);
            }
        }

        private async void HandleLogin(Message message)
        {
            try
            {
                if (message == null) throw new ArgumentNullException(nameof(message));
                if (message is not LoginMessage) throw new ArgumentException("Invalid message type");
                LoginMessage loginData = (LoginMessage)message;

                string username = loginData.Username;
                string password = loginData.Password;

                User? user = await UserHandler.AttemptLogin(username, password);

                if (user != null)
                {
                    currentUsername = username;
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
                Console.WriteLine(e.StackTrace); 
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
                Console.WriteLine(e.StackTrace); 
                Console.WriteLine(e.Message);
                Message statusMessage = new StatusMessage(Status.Failure);
                await Send(statusMessage);
                Console.WriteLine($"Sent to {socketID}: " + statusMessage.Type);
            }

        }

    }
}
