using System.Net.WebSockets;
using System.Net;
using System.Text;
using MySqlConnector;
using SchoolworkOrganizerUtils;
using SkiaSharp;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;

namespace SchoolworkOrganizerServer
{
    internal class Program
    {
        //dotnet publish --os linux --arch x64 -p:PublishProfile=DefaultContainer -c Release
        static void Main(string[] args)
        {
            StartServer();
            string? command = "";
            while (command != "stop")
            {
                command = Console.ReadLine();
                switch (command)
                {
                    case "stop":
                        Console.WriteLine("Stopping server...");
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    case "sql":
                        Console.Write("Enter SQL query: ");
                        MakeSqlQuery(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }

            }
        }
        private async static void StartServer()
        {
            Console.WriteLine("Starting server...");

            HttpListener httpListener = new HttpListener();
            httpListener.Prefixes.Add(Utilities.WebHost);
            httpListener.Start();
            Console.WriteLine($"WebSocket server started at {Utilities.WebHost}");

            while (true)
            {
                HttpListenerContext context = httpListener.GetContext();
                if (context.Request.IsWebSocketRequest)
                {
                    HttpListenerWebSocketContext webSocketContext = await context.AcceptWebSocketAsync(null);
                    WebSocket webSocket = webSocketContext.WebSocket;
                    ClientHandler client = new ClientHandler(webSocket);
                    Console.WriteLine("Client" + client.socketID + " has connected");
                    ThreadPool.QueueUserWorkItem(async _ =>
                    {
                        await client.Start();
                    });
                }
                else
                {
                    context.Response.StatusCode = 400;
                    context.Response.Close();
                }
            }
        }

        private static async void MakeSqlQuery(string? query)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
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
                                    Console.Write(reader[i] + " ");
                                }
                                Console.WriteLine();
                            }
                        }

                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, "Error");
            }

        }
    }
}
