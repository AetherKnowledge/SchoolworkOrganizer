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

        private void HandleAddSubject(Message message)
        {
            try
            {
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not SubjectMessage) throw new ArgumentException("Invalid data type");

                SubjectMessage subjectMessage = (SubjectMessage)message;

                if (this.currentUsername == null || subjectMessage.Username != this.currentUsername) throw new ArgumentException("Cannot add subject to different user");
                SubjectHandler.AddToDatabase(subjectMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private void HandleUpdateSubject(Message message)
        {
            try
            {
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not SubjectMessage) throw new ArgumentException("Invalid data type");

                SubjectMessage subjectMessage = (SubjectMessage)message;
                if (this.currentUsername == null || subjectMessage.Username != this.currentUsername) throw new ArgumentException("Cannot update subject of different user");

                SubjectHandler.UpdateToDatabase(subjectMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void HandleDeleteSubject(Message message)
        {
            try
            {
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not SubjectMessage) throw new ArgumentException("Invalid data type");

                SubjectMessage subjectMessage = (SubjectMessage)message;
                if (this.currentUsername == null || subjectMessage.Username != this.currentUsername) throw new ArgumentException("Cannot delete subject of different user");

                SubjectHandler.DeleteFromDatabase(subjectMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

    }
}
