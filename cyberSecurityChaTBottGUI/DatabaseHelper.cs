/*using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace cyberSecurityChaTBottGUI
{
    internal class DatabaseHelper
    {
        // Update this with your MySQL password before running
        private static string connectionString =
            "Server=localhost;Database=cyberbot_db;User ID=root;Password=51M04A70EAj#;";

        // Creates the tasks table if it does not already exist
        public static void InitialiseDatabase()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();

                string sql = "CREATE TABLE IF NOT EXISTS tasks (" +
                             "id INT AUTO_INCREMENT PRIMARY KEY," +
                             "title VARCHAR(255)," +
                             "reminder VARCHAR(255)," +
                             "is_completed TINYINT(1) DEFAULT 0);";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
            }
        }

        // Saves a new task to the database
        public static string AddTask(string title, string reminder)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();

                string sql = "INSERT INTO tasks (title, reminder) VALUES (@title, @reminder);";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@reminder", reminder);
                cmd.ExecuteNonQuery();

                conn.Close();

                ActivityLog.Log("Task added: " + title);

                if (reminder != "")
                    return "Task added: '" + title + "'. Reminder: " + reminder;
                else
                    return "Task added: '" + title + "'.";
            }
            catch (Exception ex)
            {
                return "Error saving task: " + ex.Message;
            }
        }

        // Loads and returns all tasks as a readable string
        public static string GetAllTasks()
        {
            string result = "=== YOUR TASKS ===\n";
            bool found = false;

            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();

                string sql = "SELECT id, title, reminder, is_completed FROM tasks;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    found = true;

                    int id = reader.GetInt32(0);
                    string title = reader.GetString(1);
                    string reminder = reader.GetString(2);
                    bool completed = reader.GetBoolean(3);

                    string status = completed ? "[DONE]" : "[PENDING]";
                    result += status + " #" + id + " - " + title;

                    if (reminder != "")
                        result += "\n     Reminder: " + reminder;

                    result += "\n\n";
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                return "Error loading tasks: " + ex.Message;
            }

            if (!found)
                return "No tasks yet. Try: 'add task review privacy settings'";

            return result;
        }

        // Marks a task as done using its ID number
        public static string CompleteTask(int id)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();

                string sql = "UPDATE tasks SET is_completed = 1 WHERE id = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                int rows = cmd.ExecuteNonQuery();
                conn.Close();

                if (rows == 0)
                    return "No task found with ID #" + id;

                ActivityLog.Log("Task #" + id + " completed");
                return "Task #" + id + " marked as done!";
            }
            catch (Exception ex)
            {
                return "Error completing task: " + ex.Message;
            }
        }
    }
}/*