using SchoolWorkOrganizerServer.Handlers;
using SchoolworkOrganizerUtils;
using SchoolworkOrganizerUtils.MessageTypes;

namespace SchoolworkOrganizerServer
{
    internal partial class ClientHandler
    {
        private void HandleAddReviewer(Message message)
        {
            try
            {
                Console.WriteLine("Attempting to add a reviewer");
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not ReviewerMessage) throw new ArgumentException("Invalid data type");

                ReviewerMessage reviewerMessage = (ReviewerMessage)message;

                if (this.currentUsername == null || reviewerMessage.Username != this.currentUsername) throw new ArgumentException("Cannot add reviewer to different user");
                ReviewerHandler.AddToDatabase(reviewerMessage);
                Console.WriteLine($"Added reviewer '{reviewerMessage.Name}' for subject '{reviewerMessage.Name}' and user '{currentUsername}'");
            }
            catch (Exception e)
            {
                if (Utilities.Debug) Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }
        }

        private void HandleUpdateReviewer(Message message)
        {
            try
            {
                Console.WriteLine("Attempting to update a reviewer");
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not ReviewerMessage) throw new ArgumentException("Invalid data type");

                ReviewerMessage reviewerMessage = (ReviewerMessage)message;
                if (this.currentUsername == null || reviewerMessage.Username != this.currentUsername) throw new ArgumentException("Cannot update reviewer of different user");

                ReviewerHandler.UpdateToDatabase(reviewerMessage);
                Console.WriteLine($"Updated reviewer '{reviewerMessage.Name}' for subject '{reviewerMessage.Name}' and user '{currentUsername}'");
            }
            catch (Exception e)
            {
                if (Utilities.Debug) Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }
        }

        private void HandleDeleteReviewer(Message message)
        {
            try
            {
                Console.WriteLine("Attempting to delete a reviewer");
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not ReviewerMessage) throw new ArgumentException("Invalid data type");

                ReviewerMessage reviewerMessage = (ReviewerMessage)message;
                if (this.currentUsername == null || reviewerMessage.Username != this.currentUsername) throw new ArgumentException("Cannot delete reviewer of different user");

                ReviewerHandler.DeleteFromDatabase(reviewerMessage);
                Console.WriteLine($"Deleted reviewer '{reviewerMessage.Name}' for subject '{reviewerMessage.Name}' and user '{currentUsername}'");
            }
            catch (Exception e)
            {
                if (Utilities.Debug) Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }
        }
    }
}
