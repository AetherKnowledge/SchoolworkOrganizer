using SkiaSharp;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Object = System.Object;

namespace SchoolworkOrganizerUtils
{
    public class Message
    {
        public MessageType Type { get; set; }
        private JsonObject Json = new JsonObject();

        public object? Data { get; private set; }

        public Message(MessageType type, object? data)
        {
            Type = type;
            Data = data;

            Json = ConvertToJson(Data);
            Json["type"] = type.ToString();
        }

        public Message(string rawData)
        {
            Json = JsonNode.Parse(rawData) as JsonObject ?? throw new ArgumentNullException("Json is not a JsonObject");
            Type = ToMessageType(Json["type"]?.ToString());
            Data = ParseJson();
        }

        private object? ParseJson()
        {
            try
            {
                if (Json == null) throw new ArgumentNullException("Json is null");
                switch (Type)
                {
                    case MessageType.Login:
                        return ParseLogin(Json);
                    case MessageType.Logout:
                        return null;
                    case MessageType.Register:
                        return ParseRegister(Json);
                    case MessageType.UpdateUser:
                        return ParseUpdateUser(Json);
                    case MessageType.UpdateSubject:
                        return null;
                    case MessageType.UpdateActivity:
                        return null;
                    case MessageType.DeleteUser:
                        return null;
                    case MessageType.DeleteSubject:
                        return null;
                    case MessageType.DeleteActivity:
                        return null;
                    case MessageType.FetchUser:
                        return ParseFetchUser(Json);
                    case MessageType.FetchSubjects:
                        return null;
                    case MessageType.FetchActivities:
                        return null;
                    case MessageType.Status:
                        return ParseStatus(Json);
                    default:
                        throw new ArgumentException("Invalid MessageType");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private JsonObject ConvertToJson(object? data)
        {
            try
            {
                if (data == null) throw new ArgumentNullException("Data is null");
                switch (Type)
                {
                    case MessageType.Login:
                        return ConvertLogin(data);
                    case MessageType.Logout:
                        return new JsonObject();
                    case MessageType.Register:
                        return ConvertRegister(data);
                    case MessageType.UpdateUser:
                        return ConvertUpdateUser(data);
                    case MessageType.UpdateSubject:
                        return new JsonObject();
                    case MessageType.UpdateActivity:
                        return new JsonObject();
                    case MessageType.DeleteUser:
                        return new JsonObject();
                    case MessageType.DeleteSubject:
                        return new JsonObject();
                    case MessageType.DeleteActivity:
                        return new JsonObject();
                    case MessageType.FetchUser:
                        return ConvertFetchUser(data);
                    case MessageType.FetchSubjects:
                        return new JsonObject();
                    case MessageType.FetchActivities:
                        return new JsonObject();
                    case MessageType.Status:
                        return ConvertStatus(data);
                    default:
                        throw new ArgumentException("Invalid MessageType");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new JsonObject();
            }
        }

        private JsonObject ConvertRegister(object? data)
        {
            if (data is not User user) throw new ArgumentException("Type and Data mismatch");
            return user.ToJson();
        }

        private User ParseRegister(JsonObject json)
        {
            return User.ParseJson(json);
        }

        private JsonObject ConvertLogin(object? data)
        {
            if (data is not Dictionary<string, string> loginData) throw new ArgumentException("Type and Data mismatch");
            JsonObject json = new JsonObject();
            json["username"] = loginData["username"];
            json["password"] = loginData["password"];

            return json;
        }

        private object? ParseLogin(JsonObject json)
        {
            Dictionary<string, string> loginData = new Dictionary<string, string>();
            loginData["username"] = json["username"]?.ToString() ?? throw new ArgumentNullException("username");
            loginData["password"] = json["password"]?.ToString() ?? throw new ArgumentNullException("password");
            return loginData;
        }

        private JsonObject ConvertStatus(object? data)
        {
            if (data is not Status) throw new ArgumentException("Type and Data mismatch");
            JsonObject json = new JsonObject();
            json["status"] = data switch
            {
                Status.Success => "Success",
                Status.Failure => "Failure",
                _ => throw new ArgumentException("Invalid Status")
            };
            return json;
        }

        private Status ParseStatus(JsonObject json)
        {
            Status status = json["status"]?.ToString() switch
            {
                "Success" => Status.Success,
                "Failure" => Status.Failure,
                _ => throw new ArgumentException("Invalid Status")
            };
            return status;
        }

        private JsonObject ConvertFetchUser(object? data)
        {
            if (data is not User user) throw new ArgumentException("Type and Data mismatch");
            JsonObject json = new JsonObject();
            json = user.ToJson();
            json["type"] = Type.ToString();

            return json;
        }

        private User ParseFetchUser(JsonObject json)
        {
            return User.ParseJson(json);
        }

        private JsonObject ConvertUpdateUser(object? data)
        {
            if (data is not Dictionary<string, User> updateData) throw new ArgumentException("Type and Data mismatch");
            JsonObject json = new JsonObject();

            var user = updateData.Values.FirstOrDefault();
            if (user == null) throw new ArgumentException("No user found in the dictionary");

            json["oldUsername"] = updateData.Keys.FirstOrDefault();
            json["type"] = Type.ToString();
            AddToJson(json, user.ToJson());

            return json;
        }

        private Dictionary<string, User> ParseUpdateUser(JsonObject json)
        {
            string oldUsername = json["oldUsername"]?.ToString() ?? throw new ArgumentNullException(nameof(oldUsername));
            Dictionary<string, User> updateData = new Dictionary<string, User>();
            updateData[oldUsername] = User.ParseJson(json);
            return updateData;
        }

        public string ToJson()
        {
            string json = JsonSerializer.Serialize(Json, new JsonSerializerOptions { WriteIndented = true });
            return json;
        }

        public string ToJsonNoImage()
        {
            JsonObject json = Json;
            json["imageData"] = Json["imageData"] == null ? "Has Image" : "No Image";
            return JsonSerializer.Serialize(json, new JsonSerializerOptions { WriteIndented = true });
        }

        private static MessageType ToMessageType(string? type)
        {
            if (type == null) throw new ArgumentNullException("Type is null");

            switch (type)
            {
                case "Login":
                    return MessageType.Login;
                case "Logout":
                    return MessageType.Logout;
                case "Register":
                    return MessageType.Register;
                case "UpdateUser":
                    return MessageType.UpdateUser;
                case "UpdateSubject":
                    return MessageType.UpdateSubject;
                case "UpdateActivity":
                    return MessageType.UpdateActivity;
                case "DeleteUser":
                    return MessageType.DeleteUser;
                case "DeleteSubject":
                    return MessageType.DeleteSubject;
                case "DeleteActivity":
                    return MessageType.DeleteActivity;
                case "FetchUser":
                    return MessageType.FetchUser;
                case "FetchSubjects":
                    return MessageType.FetchSubjects;
                case "FetchActivities":
                    return MessageType.FetchActivities;
                case "Status":
                    return MessageType.Status;
                default:
                    throw new ArgumentException("Invalid DataType");
            }
            
        }

        private void AddToJson(JsonObject to, JsonObject from)
        {
            foreach (var item in from)
            {
                to[item.Key] = item.Value?.DeepClone();
            }
        }

    }
}
