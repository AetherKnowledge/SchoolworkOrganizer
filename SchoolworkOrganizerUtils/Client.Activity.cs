using SchoolworkOrganizerUtils.MessageTypes;

namespace SchoolworkOrganizerUtils
{
    public partial class Client
    {
        internal async Task<bool> AddActivity(Activity activity)
        {
            ActivityMessage message = new ActivityMessage(MessageType.AddActivity, activity, true);
            await this.SendMessageAsync(message);

            return true;
        }

        internal async Task<bool> UpdateActivity(Activity activity, string previousName = "")
        {
            if (previousName == "") previousName = activity.Name;
            bool withFile = false;
            if (File.Exists(activity.FilePath) && activity.LastUpdated < File.GetLastWriteTime(activity.FilePath))
            {
                withFile = true;
                activity.LastUpdated = File.GetLastWriteTime(activity.FilePath);
            }

            ActivityMessage message = new ActivityMessage(MessageType.UpdateActivity, activity, withFile, previousName);
            await this.SendMessageAsync(message);

            return true;
        }

        internal async Task<bool> DeleteActivity(Activity activity)
        {
            ActivityMessage message = new ActivityMessage(MessageType.DeleteActivity, activity);
            await this.SendMessageAsync(message);

            return true;
        }
    }
}
