using SchoolworkOrganizerUtils;
using SchoolworkOrganizerUtils.MessageTypes;
using SkiaSharp;
using System.Drawing;

namespace Tester
{
    internal class Program
    {
        private static Client client = new Client();
        static void Main(string[] args)
        {
            _ = client.ConnectAsync();
            Console.WriteLine($"Connecting to the server at {Utilities.WebSocket}");
            _ = client.Login("wew", "test");

            bool running = true;
            string input = "";
            while(running)
            {
                input = Console.ReadLine() ?? "";

                switch (input.ToLower())
                {
                    case "stop":
                    case "exit":
                        running = false;
                        break;
                    case "login":
                        _ = client.Login("test", "test");
                        break;
                    case "logout":
                        client.Logout();
                        break;
                    case "register":
                        Console.Write("How many users would you like to register? : ");
                        int count;
                        if (!int.TryParse(Console.ReadLine(), out count)) count = 1;
                        RegisterMultiple(count);
                        break;
                    case "debug":
                        Utilities.Debug = !Utilities.Debug;
                        Console.WriteLine($"Debug mode is now {Utilities.Debug}");
                        break;
                    case "datastream":
                        Utilities.ShowDataStream = !Utilities.ShowDataStream;
                        Console.WriteLine($"Data stream is now {Utilities.ShowDataStream}");
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    case "help":
                        Console.WriteLine("Commands: " +
                            "login - Attempt login" +
                            "logout - Logout" +
                            "register - Register random accounts must put ammount" +
                            "debug - Shows stack trace" +
                            "datastream - Shows incoming and outgoing data" +
                            "help - Shows all commands" +
                            "stop/exit - Exits program " +
                            "clear - Clears the console");
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }
        }

        private static void RegisterMultiple(double count)
        {
            double completed = 0;

            for (int i = 0; i < count; i++)
            {
                new Thread(async () =>
                {
                    await Register();
                    completed++;
                    Console.WriteLine($"Completed {completed} in {count} : {(completed/count)*100}%");
                }).Start();
            }
        }

        private static async Task Register()
        {
            Client client = new Client();
            await client.ConnectAsync();
            Random random = new Random();

            string randText = "test" + random.Next(1000, 9999);
            Image? image = Properties.Resources.ResourceManager.GetObject("ayaya") as Image;
            byte[]? bytes = image != null ? Utilities.ImageToByteArray(image) : null;
            SKImage? skImage = bytes != null ? Utilities.ByteArrayToSKImage(bytes) : null;

            User user = new User(randText, randText, randText, skImage);
            UserMessage message = new UserMessage(MessageType.Register, user);

            await client.SendMessageAsync(message);
        }

    }
}
