using SchoolworkOrganizerUtils.MessageTypes;
using SchoolworkOrganizerUtils;
using SchoolWorkOrganizerServer.Handlers;

namespace SchoolworkOrganizerServer
{
    internal partial class ClientHandler
    {
        private async void HandleUpdateUser(Message message)
        {
            try
            {
                Console.WriteLine("Attempting to update a user");
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not UserMessage) throw new ArgumentException("Invalid message type");
                else if (message.Type != MessageType.UpdateUser) throw new ArgumentException("Invalid message type");
                UserMessage updateMessage = (UserMessage)message;

                if (this.currentUsername == null || updateMessage.PreviousUsername != this.currentUsername) throw new ArgumentException("Cannot update if different users");
                Console.WriteLine("Updating user" + currentUsername);
                await UserHandler.UpdateToDatabase(updateMessage);
                currentUsername = updateMessage.Username;
                Console.WriteLine("Updated user" + currentUsername);
            }
            catch (Exception e)
            {
                if (Utilities.Debug) Console.WriteLine(e.StackTrace); 
                Console.WriteLine(e.Message);
            }
        }

        private async void HandleLogin(Message message)
        {
            try
            {
                Console.WriteLine("Attempting to login");
                if (message == null) throw new ArgumentNullException(nameof(message));
                if (message is not LoginMessage) throw new ArgumentException("Invalid message type");
                LoginMessage loginData = (LoginMessage)message;
                Console.WriteLine("Attempting to login with " + loginData.Username);
                string username = loginData.Username;
                string password = loginData.Password;

                UserMessage? userMessage = await UserHandler.AttemptLogin(username, password);

                if (userMessage != null)
                {
                    currentUsername = username;
                    Message statusMessage = new StatusMessage(Status.Success);
                    Message userInfoMessage = userMessage;
                    Message userDataMessage = new UserDataMessage(username, await SubjectHandler.GetSubjects(username));

                    await SendAsync(statusMessage);
                    Console.WriteLine($"Sent to {socketID}: " + statusMessage.Type);
                    await SendAsync(userInfoMessage);
                    Console.WriteLine($"Sent to {socketID}: " + userInfoMessage.Type);
                    await SendAsync(userDataMessage);
                    Console.WriteLine($"Sent to {socketID}: " + userDataMessage.Type);

                    Console.WriteLine("Logged in with " + currentUsername);
                }
                else
                {
                    Message statusMessage = new StatusMessage(Status.Failure);
                    await SendAsync(statusMessage);
                    Console.WriteLine($"Sent to {socketID}: " + statusMessage.Type);
                    Console.WriteLine("Failed to login");
                }
            }
            catch (Exception e)
            {
                if (Utilities.Debug) Console.WriteLine(e.StackTrace); 
                Console.WriteLine(e.Message);
            }

        }

        private async void HandleRegister(Message message)
        {
            try
            {
                Console.WriteLine("Attempting to register");
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not UserMessage) throw new ArgumentException("Invalid message type");
                else if (message.Type != MessageType.Register) throw new ArgumentException("Invalid message type");
                UserMessage registerMessage = (UserMessage)message;
                Console.WriteLine("Attempting to register with " + registerMessage.Username);

                if (!(await UserHandler.DoesUserExist(registerMessage.Username)))
                {
                    UserHandler.AddToDatabase(registerMessage);
                    Message statusMessage = new StatusMessage(Status.Success);
                    await SendAsync(statusMessage);
                    Console.WriteLine($"Sent to {socketID}: " + statusMessage.Type);
                    Console.WriteLine("Registered with " + registerMessage.Username);
                }
                else
                {
                    Message statusMessage = new StatusMessage(Status.Failure);
                    await SendAsync(statusMessage);
                    Console.WriteLine($"Sent to {socketID}: " + statusMessage.Type);
                    Console.WriteLine("Failed to register with " + registerMessage.Username);
                }

            }
            catch (Exception e)
            {
                if (Utilities.Debug) Console.WriteLine(e.StackTrace); 
                Console.WriteLine(e.Message);
                Message statusMessage = new StatusMessage(Status.Failure);
                await SendAsync(statusMessage);
                Console.WriteLine($"Sent to {socketID}: " + statusMessage.Type);
                Console.WriteLine("Failed to register");
            }

        }

    }
}
