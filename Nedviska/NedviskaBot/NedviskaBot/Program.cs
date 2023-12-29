using AngleSharp.Dom.Events;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using NedviskaBot;
using NedviskaBot.Database;
using NedviskaBot.Migrations;
using NedviskaBot.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.Text;
using Telegram.Bot.Types.ReplyMarkups;
using AngleSharp;
using AngleSharp.Dom;

var botclient = new TelegramBotClient("токен бота это личное :) ");
using CancellationTokenSource cts = new();



// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
};

     botclient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);

var me = await botclient.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

// Send cancellation request to stop bot
cts.Cancel();

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    // Only process Message updates: https://core.telegram.org/bots/api#message
    if (update.Message is not { } message)
        return; 
    // Only process  text messages

    if (message.Text is not { } messageText)
        return;

    var chatId = message.Chat.Id;

    Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");
    
   
    /// Comands 



    if (messageText == "/start")
      {
        await botClient.SendTextMessageAsync(message.Chat, "\"Приветствую! 🌟 Ищешь свою идеальную работу? Не теряй время на бесконечные поиски – доверь это мне! " +
            " я предоставлю тебе список подходящих вакансий прямо в Telegram,просто выбери что тебе нужно из вакансий и вбей в поиск на хабре " +
            "Успехов в поиске карьерных возможностей! 🚀", 
        replyMarkup: KeyboardButtons.CreateMainKeyboard()); 
     
      }

      if (messageText == "/help")
      {
        await botClient.SendTextMessageAsync(message.Chat, "Cписок базовых команд: /start - описание бота \n/account - ваш аккаунт /subscription - премиум подписка ");
      }
  
       if ( messageText == "/account")
       {
            
        var userId = message.From.Id;

        var DbContext = new BotDbContext();

        var user = DbContext.Users.FirstOrDefault(u => u.TelegramUserId == userId);

        if (user != null)
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, $"Тип подписки: {user.Subscription}\n" +
                    $"Количество запросов за день: {user.RequestsPerDay}");
                  
        } 
        else
        {
            user = new NedviskaBot.Database.User
            {
                TelegramUserId = userId,
                Subscription = "Standart",
                RequestsPerDay = 5
            };
             DbContext.Users.Add(user);
             DbContext.SaveChanges();


            await botClient.SendTextMessageAsync(
           message.Chat.Id,
           "Повторите запрос еще раз.");
          



        }
       }

    if (messageText == "It-вакансии(habr)")
    {  
        string parsedData = await Parser.ParseWebsiteAsync();

        await botClient.SendTextMessageAsync(message.Chat.Id, parsedData);

      
    } 

    if(messageText == "Разные вакансии(hh.uz)")
    {
          string parsedData = await Parser.ParseWebsiteAsync();

        await botClient.SendTextMessageAsync(message.Chat.Id, parsedData);
    }

    
    async Task SendMessage(Chat chatId, string messageText, CancellationToken cancellationToken)
    {
        await botClient.SendTextMessageAsync(chatId: chatId,
         text: messageText,
         cancellationToken: cancellationToken);

            
    }
}

  Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}


 

