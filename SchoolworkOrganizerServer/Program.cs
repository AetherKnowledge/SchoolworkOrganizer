﻿using System.Net.WebSockets;
using System.Net;
using System.Text;
using MySqlConnector;
using SchoolworkOrganizerUtils;
using SkiaSharp;

namespace SchoolworkOrganizerServer
{
    internal class Program
    {
        private static bool isUpdating = false;
        static void Main(string[] args)
        {
            LoadUsers().Wait();
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
            httpListener.Prefixes.Add("http://localhost:5000/ws/");
            httpListener.Start();
            Console.WriteLine("WebSocket server started at ws://localhost:5000/ws/");

            while (true)
            {
                HttpListenerContext context = httpListener.GetContext();
                if (context.Request.IsWebSocketRequest)
                {
                    HttpListenerWebSocketContext webSocketContext = await context.AcceptWebSocketAsync(null);
                    WebSocket webSocket = webSocketContext.WebSocket;
                    ClientHandler client = new ClientHandler(webSocket);
                    Console.WriteLine(client.socketID + " connected");
                    await client.Start();
                }
                else
                {
                    context.Response.StatusCode = 400;
                    context.Response.Close();
                }
            }
        }

        internal static async Task LoadUsers(bool hasUpdated = false)
        {
            if (isUpdating && !hasUpdated) return;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT username, password, email, imageData FROM `users`";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            User.Users.Clear();
                            while (await reader.ReadAsync())
                            {
                                string username = reader.GetString("username");
                                string password = reader.GetString("password");
                                string email = reader.GetString("email");
                                byte[]? imageData = reader.IsDBNull(reader.GetOrdinal("imageData")) ? null : (byte[])reader["imageData"];
                                SKImage? userImage = imageData != null ? await Utilities.ByteArrayToSKImageAsync(imageData) : null;

                                User user = new User(email, username, password, userImage);
                                User.Users.Add(user);
                                LoadSubjects(user);
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

        private static async void LoadSubjects(User user)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT name FROM `subjects` WHERE username = @Username";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", user.Username);
                        using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                string name = reader.GetString("name");
                                Subject subject = new Subject(user, name);
                                user.Subjects.Add(subject);
                                LoadActivities(subject);
                                LoadReviewers(subject);
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

        private static async void LoadActivities(Subject subject)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT name, dueDate, status, filename FROM `activities` WHERE username = @Username AND subject = @Subject";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", subject.User.Username);
                        command.Parameters.AddWithValue("@Subject", subject.Name);
                        using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                string name = reader.GetString("name");
                                DateTime dueDate = reader.GetDateTime("dueDate");
                                string status = reader.GetString("status");
                                string filename = reader.GetString("filename");
                                string filePath = subject.FolderPath + "/Activity/" + filename;

                                if (subject.Activities.Count > 0 && subject.Activities.Any(activity => activity.FilePath == filePath))
                                {
                                    Activity activity = subject.Activities.First(activity => activity.Name == name && activity.FilePath == filePath);
                                    activity.DueDate = dueDate;
                                    activity.Status = status;
                                    activity.Name = name;
                                }
                                else
                                {
                                    Activity activity = new Activity(name, subject, filename, dueDate, status);
                                    subject.Activities.Add(activity);
                                }

                            }
                        }
                    }
                }

                subject.CheckForActivities();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, "Error");
            }
        }

        private static async void LoadReviewers(Subject subject)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT name, filename FROM `reviewers` WHERE username = @Username AND subject = @Subject";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", subject.User.Username);
                        command.Parameters.AddWithValue("@Subject", subject.Name);
                        using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                string name = reader.GetString("name");
                                string filename = reader.GetString("filename");
                                string filePath = subject.FolderPath + "/Reviewer/" + filename;
                                if (subject.Reviewers.Count > 0 && subject.Reviewers.Any(reviewer => reviewer.FilePath == filePath))
                                {
                                    Reviewer reviewer = subject.Reviewers.First(reviewer => reviewer.Name == name && reviewer.Subject.Name == subject.Name);
                                    reviewer.Name = name;
                                }
                                else
                                {
                                    Reviewer reviewer = new Reviewer(name, subject, filename);
                                    subject.Reviewers.Add(reviewer);
                                }
                            }
                        }
                    }
                }

                subject.CheckForReviewers();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, "Error");
            }
        }

        
    }
}
