using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot;

namespace TelegramBotAspNetCore
{
    //public class Bot
    //{
        
    //}
    //public class TelegramHandler : IUpdateHandler
    public class Bot : IUpdateHandler
    {
        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                //disable internet connection at this point

                if (update.Type == UpdateType.Message)
                    await botClient.SendTextMessageAsync(update.Message.Chat.Id, "test");
            }
            catch { }
        }

        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            //this will be called in endless loop, while internet is off
            Console.WriteLine("error");
            return Task.CompletedTask;
        }
    }
}
