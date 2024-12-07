using SchoolWorkOrganizerServerV2.Handlers;
using SchoolworkOrganizerUtils.MessageTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolworkOrganizerServer
{
    internal partial class ClientHandler
    {

        private void HandleAddActivity(Message message)
        {
            try
            {
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not ActivityMessage) throw new ArgumentException("Invalid data type");

                ActivityMessage activityMessage = (ActivityMessage)message;

                if (this.currentUsername == null || activityMessage.Username != this.currentUsername) throw new ArgumentException("Cannot add activity to different user");
                ActivityHandler.AddToDatabase(activityMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }
        }

        private void HandleUpdateActivity(Message message)
        {
            try
            {
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not ActivityMessage) throw new ArgumentException("Invalid data type");

                ActivityMessage activityMessage = (ActivityMessage)message;
                if (this.currentUsername == null || activityMessage.Username != this.currentUsername) throw new ArgumentException("Cannot update activity of different user");

                ActivityHandler.UpdateToDatabase(activityMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }
        }

        private void HandleDeleteActivity(Message message)
        {
            try
            {
                if (message == null) throw new ArgumentNullException(nameof(message));
                else if (message is not ActivityMessage) throw new ArgumentException("Invalid data type");

                ActivityMessage activityMessage = (ActivityMessage)message;
                if (this.currentUsername == null || activityMessage.Username != this.currentUsername) throw new ArgumentException("Cannot delete activity of different user");

                ActivityHandler.DeleteFromDatabase(activityMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }
        }

    }
}
