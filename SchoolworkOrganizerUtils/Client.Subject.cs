using SchoolworkOrganizerUtils.MessageTypes;

namespace SchoolworkOrganizerUtils
{
    public partial class Client
    {
        internal async Task<bool> AddSubject(Subject subject)
        {
            SubjectMessage message = new SubjectMessage(MessageType.AddSubject, subject.SubjectName, subject.User.Username);
            await this.SendMessageAsync(message);

            return true;
        }

        internal async Task<bool> UpdateSubject(Subject subject, string previousName)
        {
            SubjectMessage message = new SubjectMessage(MessageType.UpdateSubject, subject.SubjectName, subject.User.Username, previousName);
            await this.SendMessageAsync(message);

            return true;
        }

        internal async Task<bool> DeleteSubject(Subject subject)
        {
            SubjectMessage message = new SubjectMessage(MessageType.DeleteSubject, subject.SubjectName, subject.User.Username);
            await this.SendMessageAsync(message);

            return true;
        }
    }
}

