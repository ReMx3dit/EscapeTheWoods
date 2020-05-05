using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class MonkeyDbContext : DbContext
    {
        public DbSet<ActionLog> ActionLogs { get; set; }
        public DbSet<TreeLog> TreeLogs { get; set; }
        public DbSet<MonkeyLog> MonkeyLogs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-R1\SQLEXPRESS;Initial Catalog=MonkeyDB;Integrated Security=True;Pooling=False");
        }
    }
}
