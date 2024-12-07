using SchoolWorkOrganizerServer.Handlers;
using SchoolworkOrganizerUtils;
using SchoolworkOrganizerUtils.MessageTypes;

namespace SchoolworkOrganizerServer
{
    internal partial class ClientHandler
    {
        private void HandleAddSubject(Message message)
        {
            try
            {
                Console.WriteLine("Attempting to add a subject");
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not SubjectMessage) throw new ArgumentException("Invalid data type");

                SubjectMessage subjectMessage = (SubjectMessage)message;

                if (this.currentUsername == null || subjectMessage.Username != this.currentUsername) throw new ArgumentException("Cannot add subject to different user");
                SubjectHandler.AddToDatabase(subjectMessage);
                Console.WriteLine($"Added subject '{subjectMessage.SubjectName}' for user {currentUsername}");
            }
            catch (Exception e)
            {
                if (Utilities.Debug) Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }
        }

        private void HandleUpdateSubject(Message message)
        {
            try
            {
                Console.WriteLine("Attempting to update a subject");
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not SubjectMessage) throw new ArgumentException("Invalid data type");

                SubjectMessage subjectMessage = (SubjectMessage)message;
                if (this.currentUsername == null || subjectMessage.Username != this.currentUsername) throw new ArgumentException("Cannot update subject of different user");

                SubjectHandler.UpdateToDatabase(subjectMessage);
                Console.WriteLine($"Updated subject '{subjectMessage.SubjectName}' for user {currentUsername}");
            }
            catch (Exception e)
            {
                if (Utilities.Debug) Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }
        }

        private void HandleDeleteSubject(Message message)
        {
            try
            {
                Console.WriteLine("Attempting to delete a subject");
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not SubjectMessage) throw new ArgumentException("Invalid data type");

                SubjectMessage subjectMessage = (SubjectMessage)message;
                if (this.currentUsername == null || subjectMessage.Username != this.currentUsername) throw new ArgumentException("Cannot delete subject of different user");

                SubjectHandler.DeleteFromDatabase(subjectMessage);
                Console.WriteLine($"Deleted subject '{subjectMessage.SubjectName}' for user {currentUsername}");
            }
            catch (Exception e)
            {
                if (Utilities.Debug) Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }
        }
    }
}
