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
        
        static void Main(string[] args)
        {
            StartServer();
            string? command = "";
            while (command != "stop")
            {
                command = Console.ReadLine();
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

    }
}
