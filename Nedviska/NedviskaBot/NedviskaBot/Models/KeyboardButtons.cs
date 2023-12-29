using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace NedviskaBot.Models
{
    public static class KeyboardButtons
    {   



        public static  ReplyKeyboardMarkup CreateMainKeyboard()
        {
            return new ReplyKeyboardMarkup(new[]
            {
            new KeyboardButton[] { "It-вакансии(habr)", "Разные вакансии(hh.uz)" },
        })
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = false

            }; 
          
        }          
    }
}