using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SchoolworkOrganizerUtils
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MessageType
    {
        Login,
        Logout,
        Register,
        AddSubject,
        AddActivity,
        AddReviewer,
        UpdateUser,
        UpdateSubject,
        UpdateActivity,
        UpdateReviewer,
        DeleteUser,
        DeleteSubject,
        DeleteActivity,
        DeleteReviewer,
        FetchUser,
        FetchUserData,
        Status
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status
    {
        Success,
        Failure
    }
}
