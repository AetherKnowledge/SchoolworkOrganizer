using MySqlConnector;
using SchoolworkOrganizerServer;
using SchoolworkOrganizerUtils;
using System.Net.WebSockets;
using System.Text;

namespace SchoolworkOrganizerServerV2
{
    public class Program
    {
        //docker build --platform linux/amd64 -f "SchoolWorkOrganizerServerV2/Dockerfile" -t aetherknowledge/swoserver:v2 .
        private static Thread commandLine = new Thread(() => CommandLine());
        private static WebApplication? app;
        public static readonly string SqlConnectionString;
        private static readonly string WebHost;
        private static readonly bool HaveCommandLine = !Console.IsInputRedirected;

        static Program()
        {
            WebHost = Environment.GetEnvironmentVariable("WebHost") ?? "";
            if (string.IsNullOrEmpty(WebHost))
            {
                WebHost = Utilities.WebHost;
                Console.WriteLine($"WebHost environment variable not set. Using default value: {WebHost}");
            }
            if (string.IsNullOrEmpty(WebHost)) throw new InvalidOperationException("WebHost environment variable is not set.");

            SqlConnectionString = Environment.GetEnvironmentVariable("SqlConnectionString") ?? "";
            if (string.IsNullOrEmpty(SqlConnectionString))
            {
                SqlConnectionString = Utilities.SqlConnectionString;
                Console.WriteLine($"SqlConnectionString environment variable not set. Using default value: {SqlConnectionString}");
            }
            if (string.IsNullOrEmpty(SqlConnectionString)) throw new InvalidOperationException("SqlConnectionString environment variable is not set.");
        }


        public static async Task Main(string[] args)
        {
            if (HaveCommandLine) commandLine.Start();

            Console.WriteLine("Starting server...");
            var builder = WebApplication.CreateBuilder(args);
            app = builder.Build();

            var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();
            lifetime.ApplicationStopping.Register(() => Environment.Exit(0));

            app.UseWebSockets();

            app.Map("/", async context =>
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                    Console.WriteLine("WebSocket connection established");
                    ClientHandler client = new ClientHandler(webSocket);
                    Console.WriteLine($"Client {client.socketID} has connected");
                    await client.Start();
                }
                else
                {
                    string responseString = "<html><body>Hello, HTTP!</body></html>";
                    await context.Response.WriteAsync(responseString);
                }
            });

            Console.WriteLine($"Server started. Listening on {WebHost}");
            await app.RunAsync(WebHost);
        }

        private async static void CommandLine()
        {
            bool running = true;
            string? command = "";

            while (running)
            {
                command = Console.In.ReadLine();
                switch (command)
                {
                    case "stop" or "close":
                        running = false;
                        Console.WriteLine("Stopping server...");
                        if (app != null) app?.StopAsync();
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    case "sql":
                        Console.Write("Enter SQL query: ");
                        string result = await MakeSqlQuery(Console.ReadLine() ?? "");
                        Console.WriteLine(result);
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }

        private static async Task<string> MakeSqlQuery(string query)
        {
            StringBuilder result = new StringBuilder();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(SqlConnectionString))
                {
                    await connection.OpenAsync();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    result.Append(reader[i] + " ");
                                }
                                result.AppendLine();
                            }
                        }
                    }
                }
            }
            catch (MySqlException e)
            {
                return $"SQL Error: {e.Message}";
            }
            return result.ToString();
        }
    }
}