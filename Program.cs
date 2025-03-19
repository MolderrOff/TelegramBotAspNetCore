using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;
using Microsoft.Data.SqlClient;
using System.Text;
using TelegramBotAspNetCore;
using TelegramBotAspNetCore.Controllers;
//using Lucene.Net.Support;
using ServiceStack.Configuration;


//учебный дополнен на основе рабочего TelegramBotVer4_8
namespace TelegramBotAspNetCore;
internal class Program
{
    const string TOKEN = "7169505210:AAEBnzeSX666BGha_gG3O3l0VaU3zogdCQI";
    const string connectionString = "Server=localhost\\SQLEXPRESS;Database=DB;Trusted_Connection=True;TrustServerCertificate=True;";


    public static async Task Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
          

        Console.OutputEncoding = Encoding.Unicode;
        //Объект, отвечающий за постоянный жизненный цикл приложения
        var host = new HostBuilder()
            .ConfigureServices((hostContext, services) => ConfigureServices(services )) //задаём конфигурацию
            .UseConsoleLifetime() // позволяет поддерживать  приложение активным в консоли
            .Build(); //собираем


        Console.WriteLine("Сервис запущен");

        await host.RunAsync(); //запускаем сервис
        var environment = Environment.GetEnvironmentVariable(TOKEN);

        Console.WriteLine("Сервис остановлен");



        static void ConfigureServices(IServiceCollection services)
        {
            AppSettings appSettings = BuildAppSettings();
            services.AddSingleton(appSettings);

            //Подключем контроллеры сообщений и кнопок
            services.AddTransient<DefaultMessageController>();
            services.AddTransient<TaskMessageController>();
            services.AddTransient<InlineKeyboardController>();

            //регистрируем объект TelegramBotClient  с токеном подключения
            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient(appSettings.BotToken));

            //Регистрируем постоянно активный сервис бота
            services.AddHostedService<Bot>();
        }

        static AppSettings BuildAppSettings()
        {
            return new AppSettings()
            {
                BotToken = TOKEN
            };
        }

        // Add services to the container.
        builder.Services.AddRazorPages();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();

































    }
   


}




