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
        DeleteUser,
        DeleteSubject,
        DeleteActivity,
        FetchUser,
        FetchUserData,
        FetchActivities,
        Status
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status
    {
        Success,
        Failure
    }
}
