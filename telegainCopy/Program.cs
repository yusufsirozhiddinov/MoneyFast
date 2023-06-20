using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using telegainCopy.Keyboard;
using telegainCopy.Models;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using telegainCopy;
using Telegram.Bot.Requests;
using System.Threading;
using telegainCopy.Services;

var botClient = new TelegramBotClient("6227943543:AAHn_sDXe-lkZh-_oLQcBKsmIEx08saRDdk");
Markups markups = new Markups();

using CancellationTokenSource cts = new();
using ApplicationContext db = new ApplicationContext();
var callbackService = new CallbackService();
string amount = "hello";


ReceiverOptions receiverOptions = new ReceiverOptions()
{
    AllowedUpdates = Array.Empty<UpdateType>(),
};

botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);

Console.ReadLine();
cts.Cancel();
async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    if (update.Type == UpdateType.Message && update?.Message?.Text != null)
    {
        await HandleMessage(botClient, update.Message, cancellationToken);
        return;
    }

    if (update.Type == UpdateType.CallbackQuery)
    {
        await HandleCallBackQuery(botClient, update.CallbackQuery);
        return;
    }


}

async Task HandleMessage(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
{
    Message sentMessage;

    var user = db.users.Where(u => u.chat_id == message.Chat.Id).FirstOrDefault();
    int totalTasks = 0;

    
    if (message.Text == "/start")
    {

        sentMessage = await botClient.SendTextMessageAsync(text: "Добро пожаловать 🚀", chatId: message.Chat.Id, replyMarkup: markups.primaryMarkup, cancellationToken: cancellationToken);
        if (user == null)
        {
            db.users.Add(new telegainCopy.Models.User { chat_id = (int)message.Chat.Id, tg_posts = 1, registrationDate = DateTime.UtcNow });
            db.SaveChanges();
        }
        if (user != null)
        {
            totalTasks = user.tg_subs + user.tg_links + user.tg_groups + user.tg_bots + user.tg_posts;
        }
    }
    if (message.Text == "📱 Мой кабинет")
    {
        sentMessage = await botClient.SendTextMessageAsync(text: $"📱 Ваш кабинет:\r\n➖➖➖➖➖➖➖➖➖\r\n🆔 Мой ID: {message.Chat.Id}\r\n🕜 Дней в боте: {DateTime.UtcNow.Day - user.registrationDate.Day}\r\n➖➖➖➖➖➖➖➖➖\r\n✅ Выполнено:\r\n👥 Подписок в группы: {user.tg_subs}\r\n👁 Просмотров постов: {user.tg_posts}\r\n🤖 Переходов в боты: {user.tg_bots}\r\n👤 Вступлений в группы: {user.tg_groups}\r\n🔗 Переходов по ссылкам: {user.tg_links}\r\n📝 Выполнено заданий: {totalTasks}\r\n🎁 \n➖➖➖➖➖➖➖➖➖\r\n 💵 Заработано:\r\n👤 Заработано с рефералов: {user.earned_from_partners}₽\r\n💷 Всего: {user.total}₽", chatId: message.Chat.Id, cancellationToken: cancellationToken);
    }
    if (message.Text == "📢 Продвигать")
    {
        sentMessage = await botClient.SendTextMessageAsync(text: $"📢 Что вы хотите продвинуть?\r\n\r\n💳 Рекламный баланс: 0₽", chatId: message.Chat.Id, replyMarkup: markups.promoteOptionsMarkup, cancellationToken: cancellationToken);
    }
    if (amount == "Post")
    {
        if (user.AdBalance > 0)
        {
            await botClient.SendTextMessageAsync(text: $"{message.Text} просмотров ✖️ 0.024₽ = {0.024 * Convert.ToDouble(message.Text)}", chatId: message.Chat.Id);
        }
        await botClient.SendTextMessageAsync(text: $"{message.Text} просмотров ✖️ 0.024₽ = {0.024 * Convert.ToDouble(message.Text)} \n\n ❗️ Недостаточно средств на балансе! Введите другое число:", chatId: message.Chat.Id);

        Console.WriteLine(amount.Substring(4));
    }
}

async Task HandleCallBackQuery(ITelegramBotClient botClient, CallbackQuery callbackQuery)
{
    string query = callbackQuery.Data;
    if (query.Substring(query.Length - 5) == "Order")
    {
        await botClient.SendTextMessageAsync(text: callbackService.MainMarkups(query, out string title, out string callbackTitle), chatId: callbackQuery.Message.Chat.Id, replyMarkup: markups.CallOrderMarkup(title, callbackTitle));
    }
    if (query.Substring(0, 3) == "add")
    {
        await botClient.SendTextMessageAsync(text: callbackService.AddQuantityMessage(query, out string type), chatId: callbackQuery.Message.Chat.Id, replyMarkup: markups.toMainMarkup);
        amount = $"{type}";
    }
    Console.WriteLine(query.Substring(0, 3));
}

Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception ex, CancellationToken cancellationToken)
{
    var ErrorMessage = ex switch
    {
        ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => ex.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return System.Threading.Tasks.Task.CompletedTask;
}


