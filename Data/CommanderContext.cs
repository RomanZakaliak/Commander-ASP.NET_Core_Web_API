using System;
using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    class CommanderContext : DbContext
    {
        public DbSet<Command> Commands {get; set;}

        public string DbPath { get; private set; }

        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}commands.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}