
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NedviskaBot.Database
{
    public class User
    {
        public long TelegramUserId { get; set; }
        public int Id { get; set; }
        public string Subscription { get; set; }
        public int RequestsPerDay { get; set; }

    }
}
