using System;
using System.Data.SqlClient;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace BirthdayBot
{
    class Program
    {
        private static TelegramBotClient botClient;
        private static SqlConnection sqlConnection;

        static void Main()
        {
            string botToken = "  ";
            string connectionString = " ";

            botClient = new TelegramBotClient(botToken);
            sqlConnection = new SqlConnection(connectionString);

            botClient.OnMessage += BotClient_OnMessage;
            botClient.StartReceiving();
            CheckBirthdays();

            Console.WriteLine("Bot started. Press any key to exit.");
            Console.ReadKey();

            botClient.StopReceiving();
            sqlConnection.Close();
        }

        
        private static void BotClient_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                if (e.Message.Text.StartsWith("/start"))
                {
                    // Додати чат до бази даних
                    AddChatToDatabase(e.Message.Chat.Id);
                    botClient.SendTextMessageAsync(e.Message.Chat.Id, "Привіт! Відправ мені свою дату народження у форматі ДД-ММ-РРРР.");
                }
                else if (DateTime.TryParse(e.Message.Text, out DateTime birthday))
                {
                    // Записати дату народження до бази даних
                    AddBirthdayToDatabase(e.Message.Chat.Id, e.Message.From.Id, birthday);
                    botClient.SendTextMessageAsync(e.Message.Chat.Id, "Дякую! Твоя дата народження збережена.");
                }
                else
                {
                    botClient.SendTextMessageAsync(e.Message.Chat.Id, "Введена некоректна дата. Будь ласка, використовуй формат ДД-ММ-РРРР.");
                }
            }
        }

        private static void AddChatToDatabase(long chatId)
        {
            try
            {
                sqlConnection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Chats (ChatId) VALUES (@ChatId)", sqlConnection))
                {
                    command.Parameters.AddWithValue("@ChatId", chatId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding chat to database: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private static void AddBirthdayToDatabase(long chatId, long userId, DateTime birthday)
        {
            try
            {
                sqlConnection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Birthdays (ChatId, UserId, Birthday) VALUES (@ChatId, @UserId, @Birthday)", sqlConnection))
                {
                    command.Parameters.AddWithValue("@ChatId", chatId);
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@Birthday", birthday);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding birthday to database: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private static void CheckBirthdays()
        {
            try
            {
                sqlConnection.Open();

                // Отримати поточну дату
                DateTime currentDate = DateTime.Now.Date;

                // Запит для отримання днів народжень, що співпадають з поточною датою
                string query = "SELECT ChatId, UserId FROM Birthdays WHERE Birthday = @CurrentDate";

                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.AddWithValue("@CurrentDate", currentDate);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long chatId = (long)reader["ChatId"];
                            long userId = (long)reader["UserId"];

                            // Отримати повідомлення привітання для користувача
                            string message = GetGreetingMessage(userId);

                            // Надіслати привітання у чат
                            botClient.SendTextMessageAsync(chatId,  message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking birthdays: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private static string GetGreetingMessage(long Id)
        {
            // Ваш код для отримання повідомлення привітання
            // Можете використовувати різні повідомлення в залежності від ситуації або обраного шаблону
            // Наприклад, згенеруйте випадкове привітання зі списку, або використайте шаблон з параметрами дати та імені

            return $"З {Id} Днем народження! 🎉";
        }
    }
}
