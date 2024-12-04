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
        public Object? Data { get; private set; }
        public Message(MessageType type, object? data)
        {
            Type = type;
            Data = data;

            Json["type"] = type.ToString();
            ConvertToJson(Data);
        }

        public Message(string rawData)
        {
            Json = JsonNode.Parse(rawData) as JsonObject ?? throw new ArgumentNullException("Json is not a JsonObject");
            Type = ToMessageType(Json["type"]?.ToString());
            ParseJson();
        }

        private void ParseJson()
        {
            try
            {
                if (Json == null) throw new ArgumentNullException("Json is null");
                switch (Type)
                {
                    case MessageType.Login:
                        ParseLogin(Json);
                        break;
                    case MessageType.Logout:
                        break;
                    case MessageType.Register:
                        break;
                    case MessageType.UpdateUser:
                        break;
                    case MessageType.UpdateSubject:
                        break;
                    case MessageType.UpdateActivity:
                        break;
                    case MessageType.DeleteUser:
                        break;
                    case MessageType.DeleteSubject:
                        break;
                    case MessageType.DeleteActivity:
                        break;
                    case MessageType.FetchUser:
                        ParseFetchUser(Json).Wait();
                        break;
                    case MessageType.FetchSubjects:
                        break;
                    case MessageType.FetchActivities:
                        break;
                    case MessageType.Status:
                        ParseStatus(Json);
                        break;
                    default:
                        throw new ArgumentException("Invalid MessageType");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ConvertToJson(object? data)
        {
            try
            {
                if (data == null) throw new ArgumentNullException("Data is null");
                switch (Type)
                {
                    case MessageType.Login:
                        ConvertLogin(data);
                        break;
                    case MessageType.Logout:
                        break;
                    case MessageType.Register:
                        break;
                    case MessageType.UpdateUser:
                        break;
                    case MessageType.UpdateSubject:
                        break;
                    case MessageType.UpdateActivity:
                        break;
                    case MessageType.DeleteUser:
                        break;
                    case MessageType.DeleteSubject:
                        break;
                    case MessageType.DeleteActivity:
                        break;
                    case MessageType.FetchUser:
                        ConvertFetchUser(data).Wait();
                        break;
                    case MessageType.FetchSubjects:
                        break;
                    case MessageType.FetchActivities:
                        break;
                    case MessageType.Status:
                        ConvertStatus(data);
                        break;
                    default:
                        throw new ArgumentException("Invalid MessageType");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ConvertLogin(object? data)
        {
            if (data is not Dictionary<string, string> loginData) throw new ArgumentException("Type and Data mismatch");
            Json["username"] = loginData["username"];
            Json["password"] = loginData["password"];
        }

        private void ParseLogin(JsonObject json)
        {
            Dictionary<string, string> loginData = new Dictionary<string, string>();
            loginData["username"] = json["username"]?.ToString() ?? throw new ArgumentNullException("username");
            loginData["password"] = json["password"]?.ToString() ?? throw new ArgumentNullException("password");
            Data = loginData;
        }

        private void ConvertStatus(object? data)
        {
            if (data is not Status) throw new ArgumentException("Type and Data mismatch");
            Json["status"] = data switch
            {
                Status.Success => "Success",
                Status.Failure => "Failure",
                _ => throw new ArgumentException("Invalid Status")
            };
        }

        private void ParseStatus(JsonObject json)
        {
            Status status = json["status"]?.ToString() switch
            {
                "Success" => Status.Success,
                "Failure" => Status.Failure,
                _ => throw new ArgumentException("Invalid Status")
            };
            Data = status;
        }

        private async Task ConvertFetchUser(object? data)
        {
            if (data is not User user) throw new ArgumentException("Type and Data mismatch");
            Json["username"] = user.Username;
            Json["password"] = user.Password;
            Json["email"] = user.Email;
            Json["imageData"] = user.UserImage != null ? Convert.ToBase64String(await Utilities.SKImageToByteArrayAsync(user.UserImage)) : null;
        }

        private async Task ParseFetchUser(JsonObject json)
        {
            string username = json["username"]?.ToString() ?? throw new ArgumentNullException(nameof(username));
            string password = json["password"]?.ToString() ?? throw new ArgumentNullException(nameof(password));
            string email = json["email"]?.ToString() ?? throw new ArgumentNullException(nameof(email));

            string imageDataBase64 = json["imageData"]?.ToString() ?? throw new ArgumentNullException("imageData");
            byte[] imageData = Convert.FromBase64String(imageDataBase64);
            SKImage? userImage;
            if (imageData != null) userImage = (await Utilities.ByteArrayToSKImageAsync(imageData)) ?? null;
            else userImage = null;

            Data = new User(username, password, email, userImage);
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(Json, new JsonSerializerOptions { WriteIndented = true });
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

    }
}
