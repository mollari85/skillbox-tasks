using Microsoft.VisualBasic;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot
{

    class Program
    {
       // static TelegramBotClient bot = new TelegramBotClient("5694291268:AAHywUh_dKklgXyBku9vnlOzUpeDBb1eU3c");


        static void Main(string[] args)
        {
            TelegramBotClient bot = new TelegramBotClient("5694291268:AAHywUh_dKklgXyBku9vnlOzUpeDBb1eU3c");
            bot.StartReceiving(Update,Error);
            Console.ReadLine();
        }

        async private static Task Update(ITelegramBotClient botClient, Update update, CancellationToken arg3)
        {
            var message = update.Message;
            if (message!=null)
            if (message.Text != null)
            {
                if (message.Text.Contains("hi"))
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Back off");

            }
        }



         private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            Console.WriteLine(arg2.Message);
            return (null);
            
        }
    }
}