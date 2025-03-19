using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBotAspNetCore.Controllers
{
    class InlineKeyboardController : Controller
    {
        //private readonly ITelegramBotClient _telegramBotClient;
        //public string Operation {  get; protected set; }
        //public InlineKeyboardController(ITelegramBotClient telegramBotClient, DB _db)
        //{
        //    _telegramBotClient = telegramBotClient;
        //    //Operation = operation;
        //}
        //Operation = callbacakQuery.Data;
        //if (Operation == "")
        //{
        //    //запрос списка заявок из БД
        //    var list = await _db.TableTask.ToListAsync();
        //    await _telegramBotClient.SendMessage(callbackQuery.From.Id, "Текст" + list)
        //}

        public IActionResult Index()
        {
            return View();
        }
    }
}
