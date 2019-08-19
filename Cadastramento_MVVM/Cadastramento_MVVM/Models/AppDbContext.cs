using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cadastramento_MVVM.Models {
    class AppDbContext : DbContext {
        public DbSet<Client> Clients { get; set; }

        private string _databasePath;

        public AppDbContext(string databasePath) {
            _databasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}