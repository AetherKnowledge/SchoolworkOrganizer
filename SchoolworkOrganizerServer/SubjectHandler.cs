using MySqlConnector;
using Newtonsoft.Json.Linq;
using SchoolworkOrganizerUtils;
using SchoolworkOrganizerUtils.MessageTypes;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace SchoolworkOrganizerServer
{
    internal class SubjectHandler
    {

        internal static async Task<JObject> GetSubjects(string username)
        {
            JObject json = new JObject();
            json.Add("username", username);
            json.Add("type", MessageType.FetchUserData.ToString());

            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT * FROM `subjects` WHERE username = @Username";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                string subjectName = reader.GetString("subjectName");
                                JObject subjectJson = new JObject();
                                
                                subjectJson.Add("Activities", await LoadActivities(username, subjectName));
                                subjectJson.Add("Reviewers", await LoadReviewers(username, subjectName));
                                json.Add(subjectName, subjectJson);
                            }
                        }
                    }
                }

                return json;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, "Error");
                return json;
            }
        }

        internal static async Task<JObject> LoadActivities(string username, string subjectName)
        {
            JObject json = new JObject();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT * FROM `activities` WHERE username = @Username AND subjectName = @SubjectName";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@SubjectName", subjectName);
                        using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                JObject activity = new JObject();

                                string name = reader.GetString("name");
                                DateTime dueDate = reader.GetDateTime("dueDate");
                                string status = reader.GetString("status");
                                string fileName = reader.GetString("filename");
                                DateTime lastUpdated = reader.GetDateTime("lastUpdated");
                                byte[]? fileData = reader.IsDBNull(reader.GetOrdinal("fileData")) ? null : (byte[])reader["fileData"];

                                activity.Add("DueDate", dueDate);
                                activity.Add("Status", status);
                                activity.Add("FileName", fileName);
                                activity.Add("LastUpdated", lastUpdated);
                                activity.Add("FileData", Convert.ToBase64String(fileData ?? new byte[0]));

                                json.Add(name, activity);
                            }
                        }
                    }
                }
            }

            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, "Error");

            }

            return json;
        }

        internal static async Task<JObject> LoadReviewers(string username, string subjectName)
        {
            JObject json = new JObject();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT * FROM `reviewers` WHERE username = @Username AND subjectName = @SubjectName";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@SubjectName", subjectName);
                        using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                JObject reviewer = new JObject();

                                string name = reader.GetString("name");
                                string fileName = reader.GetString("filename");
                                DateTime lastUpdated = reader.GetDateTime("lastUpdated");
                                byte[]? fileData = reader.IsDBNull(reader.GetOrdinal("fileData")) ? null : (byte[])reader["fileData"];

                                reviewer.Add("FileName", fileName);
                                reviewer.Add("LastUpdated", lastUpdated);
                                reviewer.Add("FileData", Convert.ToBase64String(fileData ?? new byte[0]));

                                json.Add(name, reviewer);
                            }
                        }
                    }
                }
            }

            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, "Error");

            }

            return json;
        }

        public static async void AddToDatabase(SubjectMessage message)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "INSERT INTO `subjects` (username, subjectName) VALUES (@Username, @SubjectName)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", message.Username);
                        command.Parameters.AddWithValue("@SubjectName", message.SubjectName);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, "Error");
            }

        }

        public static async void UpdateToDatabase(SubjectMessage message)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "UPDATE `subjects` SET subjectName = @SubjectName WHERE username = @Username AND subjectName = @OldSubjectName";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", message.Username);
                        command.Parameters.AddWithValue("@SubjectName", message.SubjectName);
                        command.Parameters.AddWithValue("@OldSubjectName", message.PreviousSubjectName);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, "Error");
            }
        }

        public static async void DeleteFromDatabase(SubjectMessage message)
        {
            //foreach (var reviewer in subject.Reviewers) reviewer.DeleteFromDatabase();
            //foreach (var activity in subject.Activities) activity.DeleteFromDatabase();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "DELETE FROM `subjects` WHERE username = @Username AND subjectName = @SubjectName";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", message.Username);
                        command.Parameters.AddWithValue("@SubjectName", message.SubjectName);

                        await command.ExecuteNonQueryAsync();
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
