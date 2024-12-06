using Newtonsoft.Json.Linq;
using SchoolworkOrganizerUtils;

namespace Tester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _ = Client.ConnectAsync();
            Console.WriteLine($"Connecting to the server at {Utilities.WebSocket}");
            _ = Client.Login("test", "test");

            string input = "";
            while(input != "stop")
            {
                input = Console.ReadLine() ?? "";

                if (input == "login")
                {
                    _ = Client.Login("test", "test");
                }
            }

        }
    }
}
