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

        private void HandleAddReviewer(Message message)
        {
            try
            {
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not ReviewerMessage) throw new ArgumentException("Invalid data type");

                ReviewerMessage reviewerMessage = (ReviewerMessage)message;

                if (this.currentUsername == null || reviewerMessage.Username != this.currentUsername) throw new ArgumentException("Cannot add reviewer to different user");
                ReviewerHandler.AddToDatabase(reviewerMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void HandleUpdateReviewer(Message message)
        {
            try
            {
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not ReviewerMessage) throw new ArgumentException("Invalid data type");

                ReviewerMessage reviewerMessage = (ReviewerMessage)message;
                if (this.currentUsername == null || reviewerMessage.Username != this.currentUsername) throw new ArgumentException("Cannot update reviewer of different user");

                ReviewerHandler.UpdateToDatabase(reviewerMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void HandleDeleteReviewer(Message message)
        {
            try
            {
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not ReviewerMessage) throw new ArgumentException("Invalid data type");

                ReviewerMessage reviewerMessage = (ReviewerMessage)message;
                if (this.currentUsername == null || reviewerMessage.Username != this.currentUsername) throw new ArgumentException("Cannot delete reviewer of different user");

                ReviewerHandler.DeleteFromDatabase(reviewerMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
