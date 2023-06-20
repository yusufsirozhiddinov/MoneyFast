using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace telegainCopy.Keyboard
{
    public class Markups
    {
        public InlineKeyboardMarkup CallOrderMarkup(string title, string callbackTitle)
        {
            return new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData(title, $"add{callbackTitle}")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("⏱ Активных заказов"),
                    InlineKeyboardButton.WithCallbackData("✅ Завершенные заказы")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("◀️ Назад")
                }
            });
        }
        public ReplyKeyboardMarkup primaryMarkup = new(new[]
        {
            new KeyboardButton[] { "💸 Заработать", "📢 Продвигать" },
            new KeyboardButton[] { "📱 Мой кабинет"},
            new KeyboardButton[] { "👥 Партнеры", "📚 О боте" }
        })
        {
            ResizeKeyboard = true
        };

        public InlineKeyboardMarkup promoteOptionsMarkup = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("👁 Пост", "postOrder" ),
                InlineKeyboardButton.WithCallbackData("📢 Канал", "channelOrder")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("🤖 Бота", "botOrder" ),
                InlineKeyboardButton.WithCallbackData("👥 Группу", "groupOrder")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("📝 Расширенное задание", "extendedOrder" )
            }
        });


        public InlineKeyboardMarkup extendedOrderMarkup = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("📢 Создать задание", "createExtendedOrder"),
                InlineKeyboardButton.WithCallbackData("Мои задание", "myExtendedOrders")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("◀️ Назад", "goPromoteOptions")
            }
        });

        public ReplyKeyboardMarkup toMainMarkup = new(new[]
        {
            new KeyboardButton[] { "На главную" }
        })
        {
            ResizeKeyboard = true
        };
    }
}
