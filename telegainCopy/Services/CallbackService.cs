using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using telegainCopy.Keyboard;
using telegainCopy.Models.Orders;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace telegainCopy.Services
{
    public class CallbackService
    {
        private string sentMessage = "";


        Markups markups = new Markups();
        public string MainMarkups(string query, out string title, out string callbackTitle)
        {
            title = "";
            callbackTitle = "";
            if (query == "postOrder")
            {
                sentMessage = "👁 Наш бот предлагает Вам возможность накрутки просмотров на любые посты\r\n\r\n👁 1 просмотр - 0.024₽\r\n💳 Рекламный баланс - 0₽\r\n📊 Его хватит на 0 просмотров\r\n\r\n⏱ Активных заказов: 0\r\n✅ Завершённых заказов: 0";
                title = "👁 Добавить пост";
                callbackTitle = "Post";
            }
            if (query == "channelOrder")
            {
                sentMessage = "📢 Наш бот предлагает Вам возможность накрутки подписчиков на Ваш канал\r\n\r\n👤 1 подписчик - 0.3₽\r\n💳 Рекламный баланс - 0₽\r\n📊 Его хватит на 0 подписчиков\r\n\r\n⏱ Активных заказов: 0\r\n✅ Завершённых заказов: 0\r\n\r\n❗️ Наш бот @telegainflowbot должен быть администратором продвигаемого канала";
                title = "📢 Добавить канал";
                callbackTitle = "Channel";
            }
            if (query == "botOrder")
            {
                sentMessage = "🤖 Наш бот предлагает Вам уникальную возможность накрутки переходов на любой бот\r\n\r\n👤 1 переход - 0.4₽\r\n💳 Рекламный баланс - 0₽\r\n📊 Его хватит на 0 переходов\r\n\r\n⏱ Активных заказов: 0\r\n✅ Завершённых заказов: 0\r\n\r\n❗️ Возможно продвижение реферальных ссылок";
                title = "🤖 Добавить бота";
                callbackTitle = "Bot";
            }
            if (query == "groupOrder")
            {
                sentMessage = "👥 Наш бот предлагает Вам уникальную возможность накрутки участников в группу\r\n\r\n👤 1 участник - 0.35₽\r\n💳 Рекламный баланс - 0₽\r\n📊 Его хватит на 0 переходов\r\n\r\n⏱ Активных заказов: 0\r\n✅ Завершённых заказов: 0";
                title = "👥 Добавить группу";
                callbackTitle = "Group";
            }
            return sentMessage;
        }
        public string AddQuantityMessage (string query, out string type) {
            type = string.Empty;
            if (query == "addPost")
            {
                sentMessage = "📝 Введите количество просмотров:";
                type = "Post";
            }
            if (query == "addChannel")
            {
                sentMessage = "📝 Введите количество подписчиков:";
                type = "Channel";
            }
            if (query == "addBot")
            {
                sentMessage = "📝 Введите количество переходов:";
                type = "Bot";
            }
            if (query == "addGroup")
            {
                sentMessage = "📝 Введите количество участников:";
                type = "Group";
            }
            return sentMessage;
        }
    }
}
