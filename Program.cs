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


//ó÷åáíûé äîïîëíåí íà îñíîâå ðàáî÷åãî TelegramBotVer4_8
namespace TelegramBotAspNetCore;
internal class Program
{
    const string TOKEN = "TOKEN";
    const string connectionString = "Server=localhost\\SQLEXPRESS;Database=DB;Trusted_Connection=True;TrustServerCertificate=True;";


    public static async Task Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
          

        Console.OutputEncoding = Encoding.Unicode;
        //Îáúåêò, îòâå÷àþùèé çà ïîñòîÿííûé æèçíåííûé öèêë ïðèëîæåíèÿ
        var host = new HostBuilder()
            .ConfigureServices((hostContext, services) => ConfigureServices(services )) //çàäà¸ì êîíôèãóðàöèþ
            .UseConsoleLifetime() // ïîçâîëÿåò ïîääåðæèâàòü  ïðèëîæåíèå àêòèâíûì â êîíñîëè
            .Build(); //ñîáèðàåì


        Console.WriteLine("Ñåðâèñ çàïóùåí");

        await host.RunAsync(); //çàïóñêàåì ñåðâèñ
        var environment = Environment.GetEnvironmentVariable(TOKEN);

        Console.WriteLine("Ñåðâèñ îñòàíîâëåí");



        static void ConfigureServices(IServiceCollection services)
        {
            AppSettings appSettings = BuildAppSettings();
            services.AddSingleton(appSettings);

            //Ïîäêëþ÷åì êîíòðîëëåðû ñîîáùåíèé è êíîïîê
            services.AddTransient<DefaultMessageController>();
            services.AddTransient<TaskMessageController>();
            services.AddTransient<InlineKeyboardController>();

            //ðåãèñòðèðóåì îáúåêò TelegramBotClient  ñ òîêåíîì ïîäêëþ÷åíèÿ
            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient(appSettings.BotToken));

            //Ðåãèñòðèðóåì ïîñòîÿííî àêòèâíûé ñåðâèñ áîòà
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




