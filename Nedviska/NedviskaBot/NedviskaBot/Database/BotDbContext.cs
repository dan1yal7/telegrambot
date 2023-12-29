using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NedviskaBot.Database
{
    public  class BotDbContext : DbContext 
    { 
        public DbSet<User> Users { get; set; }
     


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=C:\\Users\\admin\\source\\repos\\Nedviska\\NedviskaBot\\NedviskaBot\\bot_database.db";

            optionsBuilder.UseSqlite(connectionString);


        }

    }
}
