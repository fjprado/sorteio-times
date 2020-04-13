using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorterioDeTimesNew
{
    public class SorteioDeTimesContext : DbContext
    {
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Equipe> Equipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;DataBase=SorteioDeTimesNewDB;Trusted_Connection=true");
        }
    }
}
