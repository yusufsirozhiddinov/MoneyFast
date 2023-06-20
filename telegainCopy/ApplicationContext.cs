using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using telegainCopy.Models;
using telegainCopy.Models.Orders;

namespace telegainCopy
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { } 
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=telegain;Username=postgres;Password=2008");
        }
        public DbSet<User> users { get; set; }
        public DbSet<PostOrder> PostOrders { get; set; }
        public DbSet<ChannelOrder> ChannelOrders { get; set; }
        public DbSet<BotOrder> BotOrders { get; set; }
        public DbSet<GroupOrder> GroupOrders { get; set; }
        public DbSet<ExtendedOrder> ExtendedOrders { get; set; }
    }
}
