using SchoolworkOrganizerUtils.MessageTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SchoolworkOrganizerUtils
{
    public partial class Client
    {

        internal async Task<bool> AddReviewer(Reviewer reviewer)
        {
            ReviewerMessage message = new ReviewerMessage(MessageType.AddReviewer, reviewer, true);
            await this.SendMessageAsync(message);

            return true;
        }

        internal async Task<bool> UpdateReviewer(Reviewer reviewer, string previousName = "")
        {
            if (previousName == "") previousName = reviewer.Name;
            bool withFile = false;
            if (File.Exists(reviewer.FilePath) && reviewer.LastUpdated < File.GetLastWriteTime(reviewer.FilePath))
            {
                withFile = true;
                reviewer.LastUpdated = File.GetLastWriteTime(reviewer.FilePath);
            }
            
            ReviewerMessage message = new ReviewerMessage(MessageType.UpdateReviewer, reviewer, withFile, previousName);
            await this.SendMessageAsync(message);

            return true;
        }

        internal async Task<bool> DeleteReviewer(Reviewer reviewer)
        {
            ReviewerMessage message = new ReviewerMessage(MessageType.DeleteReviewer, reviewer);
            await this.SendMessageAsync(message);

            return true;
        }

    }
}
