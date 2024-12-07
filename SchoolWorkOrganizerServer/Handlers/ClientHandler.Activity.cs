using SchoolWorkOrganizerServer.Handlers;
using SchoolworkOrganizerUtils.MessageTypes;

namespace SchoolworkOrganizerServer
{
    internal partial class ClientHandler
    {
        private void HandleAddActivity(Message message)
        {
            try
            {
                Console.WriteLine("Attempting to add an activity");
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not ActivityMessage) throw new ArgumentException("Invalid data type");

                ActivityMessage activityMessage = (ActivityMessage)message;

                if (this.currentUsername == null || activityMessage.Username != this.currentUsername) throw new ArgumentException("Cannot add activity to different user");
                ActivityHandler.AddToDatabase(activityMessage);
                Console.WriteLine($"Added activity '{activityMessage.Name}' for subject '{activityMessage.Name}' and user '{currentUsername}'");
            }
            catch (Exception e)
            {
                if (Utilities.Debug) Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }
        }

        private void HandleUpdateActivity(Message message)
        {
            try
            {
                Console.WriteLine("Attempting to update an activity");
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not ActivityMessage) throw new ArgumentException("Invalid data type");

                ActivityMessage activityMessage = (ActivityMessage)message;
                if (this.currentUsername == null || activityMessage.Username != this.currentUsername) throw new ArgumentException("Cannot update activity of different user");

                ActivityHandler.UpdateToDatabase(activityMessage);
                Console.WriteLine($"Updated activity '{activityMessage.Name}' for subject '{activityMessage.Name}' and user '{currentUsername}'");
            }
            catch (Exception e)
            {
                if (Utilities.Debug) Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }
        }

        private void HandleDeleteActivity(Message message)
        {
            try
            {
                Console.WriteLine("Attempting to delete an activity");
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not ActivityMessage) throw new ArgumentException("Invalid data type");

                ActivityMessage activityMessage = (ActivityMessage)message;
                if (this.currentUsername == null || activityMessage.Username != this.currentUsername) throw new ArgumentException("Cannot delete activity of different user");

                ActivityHandler.DeleteFromDatabase(activityMessage);
                Console.WriteLine($"Deleted activity '{activityMessage.Name}' for subject '{activityMessage.Name}' and user '{currentUsername}'");
            }
            catch (Exception e)
            {
                if (Utilities.Debug) Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }
        }
    }
}
