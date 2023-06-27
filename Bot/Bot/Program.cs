

using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

class Program
{
    static ITelegramBotClient botClient;

    static void Main()
    {
        botClient = new TelegramBotClient("");

        botClient.OnMessage += Bot_OnMessage;

        botClient.StartReceiving();

        Console.WriteLine("Bot is running...");
        Console.ReadLine();

        botClient.StopReceiving();
    }




    static async void Bot_OnMessage(object sender, MessageEventArgs e)
    {

        var message = e.Message;

        var firstKeyboard = new ReplyKeyboardMarkup(new[]
           {
             new []
             {
              new KeyboardButton("Я - студент старшого курсу ІТ-факультету")
              
             },
             new []
             {
             new KeyboardButton("Я - першокурсник ІТ-факультету")
             },
             new []
             {
             new KeyboardButton("Я обираю спеціальність та виш для вступу")
             }
           });

        var secondKeyboard = new ReplyKeyboardMarkup(new[]
            {
                  new []
             {
              new KeyboardButton("Вибір спеціальностей")

             },
             new []
             {
             new KeyboardButton("Матеріально технічна база ІТ факультету")
             },
             new []
             {
             new KeyboardButton("Канали комунікації")
             },
                  new []
                    {
                     
                     new KeyboardButton("Назад")
                  }
            });


        ReplyKeyboardMarkup currentKeyboard = firstKeyboard;
        // Настройка свойств клавиатуры
        firstKeyboard.OneTimeKeyboard = true; // Отключение повторного отображения клавиатуры



        if (message.Text != null)
        {
            Console.WriteLine($"Received a message from {message.Chat.Username}: {message.Text}");

            if (message.Text == "/start")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, $"Привіт,  {message.Chat.FirstName} я Біл, твій віртуальний помічник з факультету ІТ НУБіП України. Пропоную познайомитися з факультетом та отримати тут корисну інформацію.", replyMarkup: firstKeyboard);
            }
        }
        //else if (message.Photo != null)
        //{
        //    Console.WriteLine($"Received a photo from {message.Chat.Username}");

        // Очікування відповіді користувача
        //*****************************************************************************************************
        //////Update[] updates = await botClient.GetUpdatesAsync();
        //////Message receivedMessage = updates[updates.Length-1 ].Message;

        //////// Перевірка вибраної кнопки після отримання повідомлення
        //////string selectedButton = receivedMessage.Text;


        if (message.Text == "Я обираю спеціальність та виш для вступу")
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, "Чудово! Я готовий поділитися корисною інформацією та поділитися крутими івентами та інсайтами.");
            await botClient.SendTextMessageAsync(message.Chat.Id, "Вперед!");
            await botClient.SendTextMessageAsync(message.Chat.Id, "Факультет ІТ здійснює підготовку " +
                "за 7 освітніми програмами на рівні ОС «Бакалавр», 5 освітніми програмами – " +
                "ОС «Магістр», а також наявний перший науковий ступінь «Доктор філософії». " +
                " Потужна матеріальна-технічна база, професійний колектив однодумців-викладачів, " +
                "широкі можливості для самоозвитку кожного та студенти, думка яких є дійсно цінною – " +
                "це те, що робить нас особливими з-понад інших. Обери, що найбільше цікавить");

            // Відправлення повідомлення з другою клавіатурою
            await botClient.SendTextMessageAsync(message.Chat.Id, "Обери що найбільше цікавить:", replyMarkup: secondKeyboard);
            
        }

        if (message.Text == "Кнопка 5")
        {
            // Зміна клавіатури на першу клавіатуру
            currentKeyboard = firstKeyboard;

            // Відправлення повідомлення з першою клавіатурою
            await botClient.SendTextMessageAsync(message.Chat.Id, "Новий текст повідомлення", replyMarkup: firstKeyboard);
        }

        if (message.Text  == "Кнопка 1")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Вы выбрали Кнопку 1");
            // Отправка фото, связанного с Кнопкой 1
            string filePath = "C:/Users/user/source/repos/Bot/Bot/Img/unnamed.jpg";
                await botClient.SendPhotoAsync(message.Chat.Id, new InputOnlineFile(new FileStream(filePath, FileMode.Open)), "Описание фото 1");
            }
            else if (message.Caption == "Кнопка 2")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Вы выбрали Кнопку 2");
                // Отправка фото, связанного с Кнопкой 2
                await botClient.SendPhotoAsync(message.Chat.Id, new InputOnlineFile("path_to_photo_2.jpg"), "Описание фото 2");
            }
        //}
    }
}

